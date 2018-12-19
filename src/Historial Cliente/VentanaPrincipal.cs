using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Misc;
using System.Data.SqlClient;

namespace PalcoNet.Historial_Cliente
{
    public partial class historial : Form
    {

        #region Atributos

        private int resultadosPorPagina = 10;
        private int paginaActual;
        private int totalPaginas;
        int resultadosDePaginasAnteriores;

        DataTable tablaPaginaActual;

        string clienteID;
        public Session session { get; set; }

        #endregion Atributos

        #region Inicializacion

        public historial(Session session)
        {
            
            //Obtengo datos del usuario y la sesion
            this.session = session;
            clienteID = Database.getIdPorUsuario(session.user);

            InitializeComponent();

            //Configuro el DGV y le cargo los datos, arrancando en la primera pagina
            CalcularTotalDePaginas();
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            paginaActual = 1;
            ObtenerPaginaActualHistorial();

            //De por si, anulo los botones de navegacion hacia atras, y le pongo el texto correcto al label
            btnPagAnt.Enabled = false;
            btnPrimeraPag.Enabled = false;
            lbPagina.Text = "Pagina 1 de " + totalPaginas.ToString();

            //Si hubiera una sola pagina en total, tambien anulo los botones de navegacion hacia delante
            if (totalPaginas <= 1)
            {
                btnPagSig.Enabled = false;
                btnUltimaPag.Enabled = false;
            }

        }

        private void CalcularTotalDePaginas()
        {

            //Armo la query que me traera el historial de compras ENTERO del cliente logueado
            //En base a la cantidad de registros de esa query, obtengo la cantidad de filas y de paginas de la DGV
            String queryMasiva = "SELECT fecha_realizacion, publ_descripcion, fecha_funcion, fila, asiento, valor_entrada, ";
            queryMasiva += "(SELECT CASE WHEN tarjeta_id IS NULL THEN 'Desconocido'	ELSE 'Tarjeta de Credito' END), ";
            queryMasiva += "ISNULL(cantidad_puntos, 0) FROM SQLITO.Compras	JOIN SQLITO.Ubicaciones ON (ubicacion_id = ";
            queryMasiva += "id_ubicacion) JOIN SQLITO.Publicaciones ON (publicacion_id = cod_publicacion) WHERE ";
            queryMasiva += ("cliente_id = " + clienteID + " ORDER BY fecha_realizacion ASC");
            SqlCommand cmdMasiva = Database.createQuery(queryMasiva);
            DataTable tablaMasiva = Database.getTable(cmdMasiva);

            int cantidadResultados = tablaMasiva.Rows.Count;
            totalPaginas = cantidadResultados / resultadosPorPagina;
            //Si la cantidad de resultados no es multiplo de los resultados por pagina, entonces me va a quedar una pagina
            //mas, a medio llenar; como la division entera trunca, le sumo uno al total de paginas
            if ((cantidadResultados % resultadosPorPagina) != 0)
            {
                totalPaginas++;
            }

        }

        #endregion Inicializacion

        #region Paginacion

        private void LlenarDGV()
        {

            //Cargo los datos de la pagina actual (variable global) en la tabla
            dgvHistorial.DataSource = tablaPaginaActual;

            //Y luego formateo las columnas de la DGV, tanto por nombre como por contenido
            dgvHistorial.Columns[0].HeaderText = "Fecha de Compra";
            dgvHistorial.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHistorial.Columns[1].HeaderText = "Espectáculo";
            dgvHistorial.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHistorial.Columns[2].HeaderText = "Fecha de Función";
            dgvHistorial.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHistorial.Columns[3].HeaderText = "Fila";
            dgvHistorial.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHistorial.Columns[4].HeaderText = "Asiento";
            dgvHistorial.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHistorial.Columns[5].HeaderText = "Valor";
            dgvHistorial.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvHistorial.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistorial.Columns[6].HeaderText = "Medio de Pago";
            dgvHistorial.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvHistorial.Columns[7].HeaderText = "Puntos Otorgados";
            dgvHistorial.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvHistorial.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void ObtenerPaginaActualHistorial()
        {

            //Primero, calculo cuantos resultados deberia dejar atras en base a la pagina actual
            //Tener en cuenta que la query se ejecuta para cada pagina, no es una general para todo
            resultadosDePaginasAnteriores = (paginaActual - 1) * resultadosPorPagina;

            //Query que va a traer solo los resultados de la pagina seleccionada, sin contar los anteriores
            String queryPagina = "SELECT TOP " + resultadosPorPagina.ToString() + " fecha_realizacion, publ_descripcion,";
            queryPagina += " fecha_funcion, fila, asiento, valor_entrada, (SELECT CASE WHEN tarjeta_id IS NULL THEN 'Desconocido'";
            queryPagina += " ELSE 'Tarjeta de Credito' END), ISNULL(cantidad_puntos, 0) FROM SQLITO.Compras	JOIN SQLITO.";
            queryPagina += "Ubicaciones ON (ubicacion_id = id_ubicacion) JOIN SQLITO.Publicaciones ON (publicacion_id = ";
            queryPagina += "cod_publicacion) WHERE (cliente_id = @ClienteID) AND (id_compra NOT IN (SELECT TOP ";
            queryPagina += (resultadosDePaginasAnteriores.ToString() + " id_compra FROM SQLITO.Compras JOIN SQLITO.Ubicaciones");
            queryPagina += " ON (ubicacion_id = id_ubicacion) JOIN SQLITO.Publicaciones ON (publicacion_id = cod_publicacion)";
            queryPagina += " WHERE (cliente_id = @ClienteID))) ORDER BY fecha_realizacion ASC";

            //Lleno el DGV con las compras de la pagina actual
            SqlCommand cmdPagina = Database.createQuery(queryPagina);
            cmdPagina.Parameters.AddWithValue("@ClienteID", clienteID);
            tablaPaginaActual = Database.getTable(cmdPagina);
            LlenarDGV();

        }

        #endregion Paginacion

        #region Eventos

        private void btnPrimeraPag_Click(object sender, EventArgs e)
        {

            //Actualizo label y la pagina actual
            paginaActual = 1;
            lbPagina.Text = "Pagina 1 de " + totalPaginas.ToString();
            lbPagina.Visible = true;

            //Anulo botones de Primera Pagina y Pagina Anterior, y activo los de Pagina Siguiente y Ultima Pagina
            btnPrimeraPag.Enabled = false;
            btnPagAnt.Enabled = false;
            btnPagSig.Enabled = true;
            btnUltimaPag.Enabled = true;

            //Actualizo el DGV y muestro solo la primera pagina
            ObtenerPaginaActualHistorial();

        }

        private void btnPagAnt_Click(object sender, EventArgs e)
        {

            //Antes que nada, bajo en uno el numero de pagina actual, y ya lo muestro
            paginaActual--;
            lbPagina.Text = "Pagina " + paginaActual.ToString() + " de " + totalPaginas.ToString();
            lbPagina.Visible = true;

            //Muestro los botones de Pagina Siguiente y Ultima Pagina
            btnPagSig.Enabled = true;
            btnUltimaPag.Enabled = true;

            //Si ya retrocedi hasta la primer pagina, anulo los botones de Pagina Anterior y Primera Pagina
            if (paginaActual == 1)
            {
                btnPagAnt.Enabled = false;
                btnPrimeraPag.Enabled = false;
            }

            ObtenerPaginaActualHistorial();

        }

        private void btnPagSig_Click(object sender, EventArgs e)
        {

            //Antes que nada, subo en uno el numero de pagina actual, y ya lo muestro
            paginaActual++;
            lbPagina.Text = "Pagina " + paginaActual.ToString() + " de " + totalPaginas.ToString();
            lbPagina.Visible = true;

            //Muestro los botones de Pagina Anterior y Primera Pagina
            btnPagAnt.Enabled = true;
            btnPrimeraPag.Enabled = true;

            //Si ya avance hasta la ultima pagina, anulo los botones de Pagina Siguiente y Ultima Pagina
            if (paginaActual == totalPaginas)
            {
                btnPagSig.Enabled = false;
                btnUltimaPag.Enabled = false;
            }

            ObtenerPaginaActualHistorial();

        }

        private void btnUltimaPag_Click(object sender, EventArgs e)
        {

            //Antes que nada, pongo en ultimo el numero de pagina actual, y ya lo muestro
            paginaActual = totalPaginas;
            lbPagina.Text = "Pagina " + paginaActual.ToString() + " de " + totalPaginas.ToString();
            lbPagina.Visible = true;

            //Anulo los botones de Pagina Siguiente y Ultima Pagina; activo los de Primera Pagina y Pagina Anterior
            //Hago esto porque si pude tocar este boton es porque habia mas de una pagina para mostrar
            btnPrimeraPag.Enabled = true;
            btnPagAnt.Enabled = true;
            btnPagSig.Enabled = false;
            btnUltimaPag.Enabled = false;

            ObtenerPaginaActualHistorial();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Eventos
        
    }
}
