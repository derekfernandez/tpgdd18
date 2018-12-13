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

namespace PalcoNet.Editar_Publicacion
{
    public partial class EdicionPublicacion : Form
    {

        #region Atributos

        DateTime fechaConfig;

        public ParTipoTarifa[] paresTT;
        public List<Ubicacion> ubicacionesIngresadas;
        private ErrorProvider errorProvider;

        //ID de la empresa publicante, necesario para ir a buscar a la base de datos
        private string idEmpresa;
        private string idPublicacion;

        #endregion Atributos

        #region Inicializacion

        public EdicionPublicacion(String idEmpresa, String idPublicacion)
        {
            
            InitializeComponent();

            this.idEmpresa = idEmpresa;
            this.idPublicacion = idPublicacion;

            fechaConfig = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            errorProvider = new ErrorProvider();

            String queryDescripcion = "SELECT descripcion FROM SQLITO.Publicaciones WHERE cod_publicacion = '";
            queryDescripcion += (idPublicacion + "'");
            SqlCommand cmdDescripcion = Database.createQuery(queryDescripcion);
            tbDescripcion.Text = Database.getValue(cmdDescripcion);

            String queryDireccion = "SELECT direccion FROM SQLITO.Publicaciones WHERE cod_publicacion = '";
            queryDireccion += (idPublicacion + "'");
            SqlCommand cmdDireccion = Database.createQuery(queryDireccion);
            tbDireccion.Text = Database.getValue(cmdDireccion);
            if (tbDireccion.Text == "NULL")
            {
                tbDireccion.Text = "";
            }

            //Cargo los Rubros de la tabla al ComboBox
            String queryRubros = "SELECT id_rubro, descripcion FROM SQLITO.Rubros ORDER BY descripcion";
            SqlCommand cmdRubros = new SqlCommand(queryRubros, Database.getConnection());

            comboRubro.DataSource = Database.getTable(cmdRubros);
            comboRubro.DisplayMember = "descripcion";
            comboRubro.ValueMember = "id_rubro";
            //Pongo el valor que tenia guardado en la tabla
            queryRubros = "SELECT rubro_id FROM SQLITO.Publicaciones WHERE cod_publicacion = '" + idPublicacion + "'";
            cmdRubros = Database.createQuery(queryRubros);
            comboRubro.SelectedValue = Database.getValue(cmdRubros);

            //Cargo los Grados de la tabla, junto con el detalle de las comisiones, al ComboBox
            //En dos renglones, para que sea mas legible
            String queryGrados = "SELECT id_grado, (descripcion + ' (Comision del ' + CAST(comision as nvarchar(20))";
            queryGrados += "+ '%)') AS Detalle FROM SQLITO.Grados";
            SqlCommand cmdGrados = new SqlCommand(queryGrados, Database.getConnection());

            comboGrado.DataSource = Database.getTable(cmdGrados);
            comboGrado.DisplayMember = "Detalle";
            comboGrado.ValueMember = "id_grado";
            //Pongo el valor que tenia guardado en la tabla
            queryGrados = "SELECT grado_id FROM SQLITO.Publicaciones WHERE cod_publicacion = '" + idPublicacion + "'";
            cmdGrados = Database.createQuery(queryGrados);
            comboGrado.SelectedValue = Database.getValue(cmdGrados);

            String queryFecha = "SELECT fecha_funcion FROM SQLITO.Publicaciones WHERE cod_publicacion = '" + idPublicacion + "'";
            SqlCommand cmdFecha = Database.createQuery(queryFecha);
            //De arranque, deberia mostrar la fecha y el horario que tenia guardados en la base de datos
            DateTime fechaInicial = Convert.ToDateTime(Database.getValue(cmdFecha));
            //Formateo los dateTimePicker para tener fecha en uno y horario en otro
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy";
            dtpFecha.Value = fechaInicial.Date;
            dtpHorario.Format = DateTimePickerFormat.Custom;
            dtpHorario.CustomFormat = "HH:mm";
            dtpHorario.ShowUpDown = true;
            dtpHorario.Value = Convert.ToDateTime(fechaInicial.ToString("HH:mm"));

            InicializarPares(idPublicacion);
            ubicacionesIngresadas = new List<Ubicacion>();
            CargarUbicacionesCreadas(idPublicacion);

        }

        private void InicializarPares(String idPublicacion)
        {
            //Inicializo todos los pares vacios, en primera instancia; los IFs son una mierda pero no puedo sacarlos
            paresTT = new ParTipoTarifa[9];

            int i;
            for (i = 0; i < 9; i++)
            {
                //Los creo vacios asi no son null y, a la primera, arrancan como deben
                paresTT[i] = new ParTipoTarifa(new CheckBox(), new NumericUpDown());
                if (paresTT[i] != null)
                {
                    paresTT[i].nud.ReadOnly = true;
                    paresTT[i].nud.Controls[0].Visible = false;
                }
                if (paresTT[i] != null)
                {
                    paresTT[i].cb.Checked = false;
                }
            }

            //Obtengo los tipos de ubicaciones seleccionados y las tarifas de los mismos para las ubicaciones del borrador
            String queryPrecios = "SELECT tipo_id, precio FROM SQLITO.Ubicaciones WHERE publicacion_id = ";
            queryPrecios += (idPublicacion + " GROUP BY tipo_id, precio");
            SqlCommand cmdPrecios = Database.createQuery(queryPrecios);
            DataTable dt = Database.getTable(cmdPrecios);
            i = 0;

            //Leo esos precios por tipo de ubicacion, y los guardo en el array de pares, para que cuando se los
            //pase a la ventana de ubicaciones (por constructor) pueda arrancar con esos
            while (i < dt.Rows.Count)
            {
                int indice = Int32.Parse(dt.Rows[i]["tipo_id"].ToString())- 4446;
                paresTT[indice].nud.ReadOnly = false;
                paresTT[indice].nud.Controls[0].Visible = true;
                paresTT[indice].nud.Value = Decimal.Parse(dt.Rows[i]["precio"].ToString());
                paresTT[indice].cb.Checked = true;
                i++;
            }

        }

        //Carga en la lista de ubicaciones las que ya estaban creadas de cuando se guardo como borrador por primera vez
        private void CargarUbicacionesCreadas(String idPublicacion)
        {
            
            String queryUbicaciones = "SELECT fila, asiento, tipo_id FROM SQLITO.Ubicaciones ";
            queryUbicaciones += ("WHERE publicacion_id = '" + idPublicacion + "'");
            SqlCommand cmdUbicaciones = Database.createQuery(queryUbicaciones);
            DataTable tablaUbicaciones = Database.getTable(cmdUbicaciones);
            int i = 0;

            while (i < tablaUbicaciones.Rows.Count)
            {
                String queryTipo = "SELECT descripcion FROM SQLITO.TiposUbicacion WHERE id_tipo = ";
                queryTipo += tablaUbicaciones.Rows[i]["tipo_id"].ToString();
                String tipoUbicacion = Database.getValue(Database.createQuery(queryTipo));
                
                ubicacionesIngresadas.Add(new Ubicacion(tablaUbicaciones.Rows[i]["fila"].ToString(),
                                                        tablaUbicaciones.Rows[i]["asiento"].ToString(),
                                                        tipoUbicacion,
                                                        Int32.Parse(tablaUbicaciones.Rows[i]["tipo_id"].ToString()),
                                                        -1));                   //Tarifa basura
                i++;
            }
            

        }

        #endregion Inicializacion

        #region Coherencia

        //En base a los pares guardados en paresTT, busco el correspondiente al tipo pasado por parametro, y devuelvo su tarifa
        private Decimal ObtenerTarifa(int tipoId)
        {
            return paresTT[tipoId - 4446].nud.Value;
        }

        //Intento que la fecha de vencimiento sea 7 dias antes de la funcion; si esa fecha es anterior a la fecha de creacion,
        //entonces la fecha de vencimiento sera la fecha misma de la funcion
        private DateTime ObtenerFechaVencimiento(DateTime fechaFuncion, DateTime fechaCreacion)
        {
            DateTime fechaVenc = fechaFuncion.AddDays(-7);
            if (fechaVenc < fechaCreacion)
            {
                fechaVenc = fechaFuncion;
            }
            return fechaVenc;
        }

        #endregion Coherencia

        #region Eventos

        private void btnUbicaciones_Click(object sender, EventArgs e)
        {
            //Abro la ventana de Disposicion de Ubicaciones con los pares como estan guardados
            DisposicionUbicaciones disp = new DisposicionUbicaciones(paresTT, ubicacionesIngresadas);
            disp.ShowDialog();
            //Una vez que vuelve de la ventana auxiliar, actualizo el array de pares de esta ventana
            paresTT = disp.paresTT;
        }
        
        //Si apreto el boton "Descartar" vuelvo atras y pierdo todos los cambios de la sesion actual
        private void btnDescartar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            String descripcion;
            String direccion;
            String grado;
            String comision;
            String rubro;

            DateTime fechaElegida = dtpFecha.Value.Date + dtpHorario.Value.TimeOfDay;

            #region ManejoErrores
            errorProvider.Clear();

            if ((string.IsNullOrWhiteSpace(tbDescripcion.Text)))
            {
                errorProvider.SetError(tbDescripcion, "Debe ingresar una descripcion o nombre para la publicacion");
                return;
            }

            if(fechaElegida < fechaConfig)
            {
                errorProvider.SetError(dtpFecha, "No puede ingresar una fecha anterior al dia de hoy");
                return;
            }

            String queryFechas = "SELECT cod_publicacion FROM SQLITO.Publicaciones WHERE (descripcion = @Descripcion)";
            queryFechas += (" AND (fecha_funcion = @FechaFunc) AND (cod_publicacion) <> " + idPublicacion);
            SqlCommand cmdFechas = Database.createQuery(queryFechas);
            cmdFechas.Parameters.AddWithValue("@Descripcion", tbDescripcion.Text);
            cmdFechas.Parameters.Add("@FechaFunc", SqlDbType.DateTime).Value = fechaElegida;
            DataTable dt = Database.getTable(cmdFechas);

            if (dt.Rows.Count > 0)
            {
                errorProvider.SetError(dtpFecha, "Ya existe una funcion del espectaculo en ese horario; ingrese otra");
                return;
            }
            #endregion ManejoErrores

            #region ManejoCamposIncompletos
            
            if ((string.IsNullOrWhiteSpace(tbDireccion.Text)))
            {
                direccion = "NULL";
            }
            else
            {
                direccion = tbDireccion.Text;
            }

            if (comboGrado.SelectedIndex < 0)
            {
                grado = "NULL";
                comision = "NULL";
            }
            else
            {
                grado = comboGrado.SelectedValue.ToString();
                String query = "SELECT comision FROM SQLITO.Grados WHERE id_grado = " + grado;
                SqlCommand cmd = Database.createQuery(query);
                comision = Database.getValue(cmd);
            }

            if (comboRubro.SelectedIndex < 0)
            {
                rubro = "NULL";
            }
            else
            {
                rubro = comboRubro.SelectedValue.ToString();
            }

            #endregion ManejoCamposIncompletos

            descripcion = tbDescripcion.Text;

            #region Persistencia

            String queryUpdate;
            SqlCommand cmdUpdate;

            queryUpdate = "UPDATE SQLITO.Publicaciones SET descripcion = @Descripcion, fecha_funcion = @FechaFuncion, ";
            queryUpdate += "grado_id = @GradoID, direccion = @Direccion, comision = @Comision, rubro_id = @RubroID ";
            queryUpdate += ("WHERE cod_publicacion = " + idPublicacion);
            cmdUpdate = Database.createQuery(queryUpdate);
            cmdUpdate.Parameters.AddWithValue("@Descripcion", descripcion);
            cmdUpdate.Parameters.Add("@FechaFuncion", SqlDbType.DateTime).Value = fechaElegida;
            cmdUpdate.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = direccion;
            cmdUpdate.Parameters.AddWithValue("@GradoID", grado);
            cmdUpdate.Parameters.Add("@Comision", SqlDbType.Decimal).Value = Double.Parse(comision);
            cmdUpdate.Parameters.AddWithValue("@RubroID", rubro);
            //Luego de armar el INSERT individual de la fecha que estoy recorriendo, agrego la funcion en la misma
            Database.execQuery(cmdUpdate);

            String queryUbicacion;
            SqlCommand cmdUbicacion;

            //Primero, borro todas las ubicaciones que habia, porque pueden haber cambiado en la edicion
            queryUbicacion = "DELETE FROM SQLITO.Ubicaciones WHERE publicacion_id = " + idPublicacion;
            cmdUbicacion = Database.createQuery(queryUbicacion);
            Database.execQuery(cmdUbicacion);

            //Inserto las ubicaciones actualizadas (con tarifa y todo) de la publicacion editada y conservada como borrador
            foreach (var u in ubicacionesIngresadas)
            {
                queryUbicacion = "INSERT INTO SQLITO.Ubicaciones (fila, asiento, tipo_id, precio, publicacion_id)";
                queryUbicacion += "VALUES(@Fila, @Asiento, @TipoID, @Precio, @PublicacionID)";
                cmdUbicacion = Database.createQuery(queryUbicacion);
                cmdUbicacion.Parameters.AddWithValue("@Fila", u.Fila);
                cmdUbicacion.Parameters.AddWithValue("@Asiento", u.Asiento);
                cmdUbicacion.Parameters.Add("@Comision", SqlDbType.Decimal).Value = Double.Parse(comision);
                cmdUbicacion.Parameters.AddWithValue("@TipoID", u.TipoId.ToString());
                cmdUbicacion.Parameters.Add("@Precio", SqlDbType.Decimal).Value = ObtenerTarifa(u.TipoId);
                cmdUbicacion.Parameters.AddWithValue("@PublicacionID", idPublicacion);
                //Luego de armar el INSERT individual de la ubicacion que estoy recorriendo, la persisto
                Database.execQuery(cmdUbicacion);
            }

            #endregion Persistencia

            this.Close();
            
        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {

            DateTime fechaElegida = dtpFecha.Value.Date + dtpHorario.Value.TimeOfDay;
            
            #region ManejoErrores

            errorProvider.Clear();

            if ((string.IsNullOrWhiteSpace(tbDescripcion.Text)))
            {
                errorProvider.SetError(tbDescripcion, "Debe ingresar una descripcion o nombre para la publicacion");
                return;
            }
            if ((string.IsNullOrWhiteSpace(tbDireccion.Text)))
            {
                errorProvider.SetError(tbDireccion, "Debe ingresar la direccion en la que se llevara a cabo el espectaculo");
                return;
            }
            if (comboRubro.SelectedIndex < 0)
            {
                errorProvider.SetError(comboRubro, "Debe especificar el rubro al que pertenece el espectaculo");
                return;
            }
            if (comboGrado.SelectedIndex < 0)
            {
                errorProvider.SetError(comboGrado, "Debe especificar el grado de visibilidad de la publicacion");
                return;
            }
            if (ubicacionesIngresadas.Count == 0)
            {
                errorProvider.SetError(btnUbicaciones, "No ha ingresado ubicaciones. Debe especificar al menos una");
                return;
            }
            if (fechaElegida < fechaConfig)
            {
                errorProvider.SetError(dtpFecha, "No puede ingresar una fecha anterior al dia de hoy");
                return;
            }

            String queryFechas = "SELECT cod_publicacion FROM SQLITO.Publicaciones WHERE (descripcion = @Descripcion)";
            queryFechas += (" AND (fecha_funcion = @FechaFunc) AND (cod_publicacion) <> " + idPublicacion);
            SqlCommand cmdFechas = Database.createQuery(queryFechas);
            cmdFechas.Parameters.AddWithValue("@Descripcion", tbDescripcion.Text);
            cmdFechas.Parameters.Add("@FechaFunc", SqlDbType.DateTime).Value = fechaElegida;
            DataTable dt = Database.getTable(cmdFechas);
            if (dt.Rows.Count > 0)
            {
                errorProvider.SetError(dtpFecha, "Ya existe una funcion del espectaculo en ese horario; ingrese otra");
                return;
            }

            #endregion ManejoErrores

            #region ObtencionCampos

            String descripcion = tbDescripcion.Text;
            String direccion = tbDireccion.Text;
            String grado = comboGrado.SelectedValue.ToString();
            String queryComision = "SELECT comision FROM SQLITO.Grados WHERE id_grado = " + grado;
            SqlCommand cmdComision = Database.createQuery(queryComision);
            String comision = Database.getValue(cmdComision);
            String rubro = comboRubro.SelectedValue.ToString();

            #endregion ObtencionCampos

            #region Persistencia

            String queryUpdate;
            SqlCommand cmdUpdate;

            //El UPDATE es igual al de btnActualizar, solo que tambien le pone el estado en 2 (ya esta publicada)
            queryUpdate = "UPDATE SQLITO.Publicaciones SET descripcion = @Descripcion, fecha_funcion = @FechaFuncion, ";
            queryUpdate += "fecha_vencimiento = @FechaVenc, grado_id = @GradoID, direccion = @Direccion, comision = @Comision, ";
            queryUpdate += ("rubro_id = @RubroID, estado_id = 2 WHERE cod_publicacion = " + idPublicacion);
            cmdUpdate = Database.createQuery(queryUpdate);
            cmdUpdate.Parameters.AddWithValue("@Descripcion", descripcion);
            cmdUpdate.Parameters.Add("@FechaFuncion", SqlDbType.DateTime).Value = fechaElegida;
            DateTime fechaVenc = ObtenerFechaVencimiento(fechaElegida, fechaConfig);
            cmdUpdate.Parameters.Add("@FechaVenc", SqlDbType.DateTime).Value = fechaVenc;
            cmdUpdate.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = direccion;
            cmdUpdate.Parameters.AddWithValue("@GradoID", grado);
            cmdUpdate.Parameters.Add("@Comision", SqlDbType.Decimal).Value = Double.Parse(comision);
            cmdUpdate.Parameters.AddWithValue("@RubroID", rubro);
            //Luego de armar el INSERT individual de la fecha que estoy recorriendo, agrego la funcion en la misma
            Database.execQuery(cmdUpdate);

            String queryUbicacion;
            SqlCommand cmdUbicacion;

            //Primero, borro todas las ubicaciones que habia, porque pueden haber cambiado en la edicion
            queryUbicacion = "DELETE FROM SQLITO.Ubicaciones WHERE publicacion_id = " + idPublicacion;
            cmdUbicacion = Database.createQuery(queryUbicacion);
            Database.execQuery(cmdUbicacion);

            //Inserto las ubicaciones actualizadas (con tarifa y todo) de la publicacion editada y conservada como borrador
            foreach (var u in ubicacionesIngresadas)
            {
                queryUbicacion = "INSERT INTO SQLITO.Ubicaciones (fila, asiento, tipo_id, precio, publicacion_id)";
                queryUbicacion += "VALUES(@Fila, @Asiento, @TipoID, @Precio, @PublicacionID)";
                cmdUbicacion = Database.createQuery(queryUbicacion);
                cmdUbicacion.Parameters.AddWithValue("@Fila", u.Fila);
                cmdUbicacion.Parameters.AddWithValue("@Asiento", u.Asiento);
                cmdUbicacion.Parameters.Add("@Comision", SqlDbType.Decimal).Value = Double.Parse(comision);
                cmdUbicacion.Parameters.AddWithValue("@TipoID", u.TipoId.ToString());
                cmdUbicacion.Parameters.Add("@Precio", SqlDbType.Decimal).Value = ObtenerTarifa(u.TipoId);
                cmdUbicacion.Parameters.AddWithValue("@PublicacionID", idPublicacion);
                //Luego de armar el INSERT individual de la ubicacion que estoy recorriendo, la persisto
                Database.execQuery(cmdUbicacion);
            }

            #endregion Persistencia

            this.Close();

        }

        #endregion Eventos

    }
}
