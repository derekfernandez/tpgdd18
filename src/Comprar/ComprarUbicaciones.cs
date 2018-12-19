using PalcoNet.Generar_Publicacion;
using PalcoNet.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Comprar
{
    public partial class ComprarUbicaciones : Form
    {

        #region Atributos

        private String idPublicacion;
        private String idCliente;

        //Listas para llenar los DGVs de Disponibles y de Carrito
        private List<Ubicacion> ubicacionesDisponibles;
        private BindingList<Ubicacion> disponiblesBinding;
        private BindingSource disponiblesSource;
        private List<Ubicacion> ubicacionesElegidas;
        private BindingList<Ubicacion> elegidasBinding;
        private BindingSource elegidasSource;

        //Variables para los TextBoxes
        private decimal totalAcumulado;
        private int cantidadItems;

        private DateTime fechaActual;
        private ErrorProvider errorProvider;

        #endregion Atributos

        #region Inicializacion

        public ComprarUbicaciones(String idPublicacion, String idCliente)
        {
            
            InitializeComponent();

            this.idPublicacion = idPublicacion;
            this.idCliente = idCliente;

            fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);

            errorProvider = new ErrorProvider();

            //Ambas listas (futuras dataSource) inician vacias
            ubicacionesDisponibles = new List<Ubicacion>();
            ubicacionesElegidas = new List<Ubicacion>();

            cantidadItems = 0;
            totalAcumulado = 0;

            tbTotalAcumulado.ReadOnly = true;
            tbTotalAcumulado.Text = totalAcumulado.ToString();
            tbCantidad.ReadOnly = true;
            tbCantidad.Text = cantidadItems.ToString();

            CargarUbicacionesDisponibles();
            ActualizarDGVs();
            
        }

        private void CargarUbicacionesDisponibles()
        {

            //Traigo todas las ubicaciones DISPONIBLES de esa publicacion (que no aparezcan en ninguna compra)
            String queryUbicaciones = "SELECT id_ubicacion, fila, asiento, tipo_id, precio FROM SQLITO.Ubicaciones AS U LEFT ";
            queryUbicaciones += "JOIN SQLITO.Compras AS C ON (C.ubicacion_id = U.id_ubicacion) WHERE (publicacion_id = '";
            queryUbicaciones += (idPublicacion + "')" + " AND (U.id_ubicacion NOT IN (SELECT C1.ubicacion_id");
            queryUbicaciones += " FROM SQLITO.Compras AS C1))";

            SqlCommand cmdUbicaciones = Database.createQuery(queryUbicaciones);
            DataTable tablaUbicaciones = Database.getTable(cmdUbicaciones);
            int i = 0;

            while (i < tablaUbicaciones.Rows.Count)
            {
                String queryTipo = "SELECT descripcion FROM SQLITO.TiposUbicacion WHERE id_tipo = ";
                queryTipo += tablaUbicaciones.Rows[i]["tipo_id"].ToString();
                String tipoUbicacion = Database.getValue(Database.createQuery(queryTipo));

                ubicacionesDisponibles.Add(new Ubicacion(tablaUbicaciones.Rows[i]["fila"].ToString(),
                                                        tablaUbicaciones.Rows[i]["asiento"].ToString(),
                                                        tipoUbicacion,
                                                        Int32.Parse(tablaUbicaciones.Rows[i]["tipo_id"].ToString()),
                                                        Decimal.Parse(tablaUbicaciones.Rows[i]["precio"].ToString()),
                                                        Int32.Parse(tablaUbicaciones.Rows[i]["id_ubicacion"].ToString())));                   
                i++;
            }

        }

        #endregion Inicializacion

        #region Coherencia

        private void ActualizarDGVs()
        {

            disponiblesBinding = new BindingList<Ubicacion>(ubicacionesDisponibles);
            disponiblesSource = new BindingSource(disponiblesBinding, null);
            dgvDisponibles.DataSource = disponiblesSource;
            //Escondo el ID del tipo
            dgvDisponibles.Columns[3].Visible = false;
            dgvDisponibles.Columns[5].Visible = false;
            dgvDisponibles.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDisponibles.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDisponibles.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDisponibles.Columns[2].HeaderText = "Tipo";
            dgvDisponibles.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            elegidasBinding = new BindingList<Ubicacion>(ubicacionesElegidas);
            elegidasSource = new BindingSource(elegidasBinding, null);
            dgvCarrito.DataSource = elegidasSource;
            //Escondo el ID del tipo
            dgvCarrito.Columns[3].Visible = false;
            dgvCarrito.Columns[5].Visible = false;
            dgvCarrito.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCarrito.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCarrito.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCarrito.Columns[2].HeaderText = "Tipo";
            dgvCarrito.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void AgregarUbicacionALista(List<Ubicacion> lista, Ubicacion ubi)
        {
            lista.Add(ubi);
        }

        private void EliminarUbicacionDeLista(List<Ubicacion> lista, Ubicacion ubi)
        {

            lista.RemoveAll(u => u.Id == ubi.Id);

        }

        //Algoritmo para obtener puntos asociados a una compra. Puede cambiarse
        //Por ahora, es un punto cada $10, y un punto cada 5 superados los $500
        private Int64 ObtenerPuntos(decimal precio)
        {
            
            Int64 puntos = 0;
            puntos = (Int64) (precio / 10);
            if (precio > 500)
            {
                puntos += (Int64) ((precio - 500) / 5);
            }

            return puntos;

        }

        #endregion Coherencia

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            errorProvider.Clear();

            if (dgvDisponibles.CurrentRow == null)
            {
                errorProvider.SetError(dgvDisponibles, "Debe elegir una ubicacion para agregar");
                return;
            }

            Ubicacion aAgregar = new Ubicacion (dgvDisponibles.CurrentRow.Cells[0].Value.ToString(),
                                                dgvDisponibles.CurrentRow.Cells[1].Value.ToString(),
                                                dgvDisponibles.CurrentRow.Cells[2].Value.ToString(),
                                                Int32.Parse(dgvDisponibles.CurrentRow.Cells[3].Value.ToString()),
                                                Decimal.Parse(dgvDisponibles.CurrentRow.Cells[4].Value.ToString()),
                                                Int32.Parse(dgvDisponibles.CurrentRow.Cells[5].Value.ToString()));

            //Actualizo las listas y los DGVs
            EliminarUbicacionDeLista(ubicacionesDisponibles, aAgregar);
            AgregarUbicacionALista(ubicacionesElegidas, aAgregar);
            ActualizarDGVs();

            //Actualizo los contadores
            cantidadItems++;
            tbCantidad.Text = cantidadItems.ToString();
            totalAcumulado += aAgregar.Precio;
            tbTotalAcumulado.Text = totalAcumulado.ToString();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            errorProvider.Clear();

            if (dgvCarrito.CurrentRow == null)
            {
                errorProvider.SetError(dgvCarrito, "Debe elegir una ubicacion para eliminar");
                return;
            }

            Ubicacion aEliminar = new Ubicacion(dgvCarrito.CurrentRow.Cells[0].Value.ToString(),
                                                dgvCarrito.CurrentRow.Cells[1].Value.ToString(),
                                                dgvCarrito.CurrentRow.Cells[2].Value.ToString(),
                                                Int32.Parse(dgvCarrito.CurrentRow.Cells[3].Value.ToString()),
                                                Decimal.Parse(dgvCarrito.CurrentRow.Cells[4].Value.ToString()),
                                                Int32.Parse(dgvCarrito.CurrentRow.Cells[5].Value.ToString()));

            //Actualizo las listas y los DGVs
            EliminarUbicacionDeLista(ubicacionesElegidas, aEliminar);
            AgregarUbicacionALista(ubicacionesDisponibles, aEliminar);
            ActualizarDGVs();

            //Actualizo los contadores
            cantidadItems--;
            tbCantidad.Text = cantidadItems.ToString();
            totalAcumulado -= aEliminar.Precio;
            tbTotalAcumulado.Text = totalAcumulado.ToString();

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            #region ManejoErrores

            errorProvider.Clear();

            String queryTarjeta = "SELECT tarjeta_id FROM SQLITO.Clientes WHERE id_cliente = " + idCliente;
            SqlCommand cmdTarjeta = Database.createQuery(queryTarjeta);
            String idTarjeta = Database.getValue(cmdTarjeta);

            //Si no tiene una tarjeta asociada, abro el ABM de Registrar Tarjeta
            if (string.IsNullOrWhiteSpace(idTarjeta))
            {
                
                MessageBox.Show("Estimado cliente, no posee tarjetas asociadas a su cuenta. Para proceder, por favor registre una");
                RegistrarTarjeta rt = new RegistrarTarjeta(idCliente);
                rt.ShowDialog();

                //Me fijo que haya registrado una tarjeta (que no haya cerrado con la cruz); si no, le pido de nuevo que ingrese
                if (rt.targetaRegistrada == false)
                {
                    return;
                }

                idTarjeta = rt.idTarjeta;
            }

            #endregion ManejoErrores

            #region Persistencia

            String queryInsert;
            SqlCommand cmdInsert;
            String queryPuntos;
            SqlCommand cmdPuntos;
            //Hacemos que los puntos se venzan 30 dias luego de ser obtenidos
            DateTime fechaVencimientoPuntos = fechaActual.AddDays(30);

            foreach (var u in ubicacionesElegidas)
            {

                //Primero, inserto en la tabla de Compras la compra de la ubicacion, obteniendo los puntos por la misma              
                queryInsert = "INSERT INTO SQLITO.Compras (cliente_id, ubicacion_id, fecha_realizacion, valor_entrada, tarjeta_id";
                queryInsert += ", cantidad_puntos) VALUES (@ClienteID, @UbicacionID, @Fecha, @Valor, @TarjetaID, @CantPuntos)";
                cmdInsert = Database.createQuery(queryInsert);
                cmdInsert.Parameters.AddWithValue("@ClienteID", idCliente);
                cmdInsert.Parameters.AddWithValue("@UbicacionID", u.Id);
                cmdInsert.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = fechaActual;
                cmdInsert.Parameters.Add("@Valor", SqlDbType.Decimal).Value = u.Precio;
                cmdInsert.Parameters.AddWithValue("@TarjetaID", idTarjeta);

                Int64 puntos = ObtenerPuntos(u.Precio);
                cmdInsert.Parameters.Add("@CantPuntos", SqlDbType.BigInt).Value = puntos;

                Database.execQuery(cmdInsert);

                //Por ultimo, no me olvido de actualizar la tabla de Puntos con los puntos generados por la compra
                queryPuntos = "INSERT INTO SQLITO.Puntos (cantidad, cliente_id, fecha_vencimiento) VALUES";
                queryPuntos += "(@Cantidad, @ClienteID, @FechaVencimiento)";
                cmdPuntos = Database.createQuery(queryPuntos);
                cmdPuntos.Parameters.Add("@Cantidad", SqlDbType.BigInt).Value = puntos;
                cmdPuntos.Parameters.AddWithValue("@ClienteID", idCliente);
                cmdPuntos.Parameters.Add("@FechaVencimiento", SqlDbType.DateTime).Value = fechaVencimientoPuntos;
                Database.execQuery(cmdPuntos);


            }

            #endregion Persistencia

            this.Close();

        }

        #endregion Eventos

    }
}
