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

namespace PalcoNet.Generar_Publicacion
{
    public partial class VentanaPrincipal : Form
    {

        #region Atributos

        DateTime fechaConfig;

        //Lista de fechas de funcion, para mostrar en el dgv, y algunas listas auxiliares
        private List<DateTime> fechasFuncion;
        private BindingList<DateTime> fechasBinding;
        private BindingSource fechasSource;

        public ParTipoTarifa[] paresTT;
        public List<Ubicacion> ubicacionesIngresadas;
        private ErrorProvider errorProvider;

        //Campo con el ID del usuario pasado por constructor
        private string idUsuario;
        //ID de la empresa publicante, necesario para ir a buscar a la base de datos
        private string idEmpresa;
        Usuario user { get; set; }
        Session session { get; set; }

        #endregion Atributos

        #region Inicializacion

        public VentanaPrincipal(Session session)
        {
            this.session = session;
            user = session.user;
            InitializeComponent();

            fechaConfig = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);

            fechasFuncion = new List<DateTime>();
            errorProvider = new ErrorProvider();

            //Cargo los Rubros de la tabla al ComboBox
            String queryRubros = "SELECT id_rubro, r_descripcion FROM SQLITO.Rubros ORDER BY r_descripcion";
            SqlCommand cmdRubros = new SqlCommand(queryRubros, Database.getConnection());

            comboRubro.DataSource = Database.getTable(cmdRubros);
            comboRubro.DisplayMember = "r_descripcion";
            comboRubro.ValueMember = "id_rubro";

            //Cargo los Grados de la tabla, junto con el detalle de las comisiones, al ComboBox
            //En dos renglones, para que sea mas legible
            String queryGrados = "SELECT id_grado, (descripcion + ' (Comision del ' + CAST(comision as nvarchar(20))";
            queryGrados += "+ '%)') AS Detalle FROM SQLITO.Grados WHERE habilitado = 1";
            SqlCommand cmdGrados = new SqlCommand(queryGrados, Database.getConnection());

            comboGrado.DataSource = Database.getTable(cmdGrados);
            comboGrado.DisplayMember = "Detalle";
            comboGrado.ValueMember = "id_grado";

            //Formateo los dateTimePicker para tener fecha en uno y horario en otro
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy";
            dtpFecha.Value = fechaConfig;
            dtpHorario.Format = DateTimePickerFormat.Custom;
            dtpHorario.CustomFormat = "HH:mm";
            dtpHorario.ShowUpDown = true;
            dtpHorario.Value = Convert.ToDateTime("00:00");

            InicializarPares();
            ubicacionesIngresadas = new List<Ubicacion>();

            //Obtengo el id del usuario logeado, y con él busco el id de la Empresa que posee dicho usuario
            idUsuario = user.id;
            String queryID = "SELECT id_empresa FROM SQLITO.Empresas WHERE usuario_id = " + idUsuario;
            SqlCommand cmd = Database.createQuery(queryID);
            idEmpresa = Database.getValue(cmd);

        }

        private void InicializarPares()
        {
            //Inicializo todos los pares vacios, en primera instancia; los IFs son una mierda pero no puedo sacarlos
            paresTT = new ParTipoTarifa[9];

            for (int i = 0; i < 9; i++)
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
        }

        #endregion Inicializacion

        #region Coherencia

        //Para ocultar las columnas que no necesito de la DGV
        private void ocultarColumnasNoUtilizadas(DataGridView dgv)
        {
            int i;
            for (i = 1; i <= 12; i++)
            {
                if (i != 4 && i != 7)
                {
                    dgv.Columns[i].Visible = false;
                }
            }
        }

        //Para cargar de nuevo la DGV y con el formato necesario
        private void actualizarDatosDGV()
        {
            fechasBinding = new BindingList<DateTime>(fechasFuncion);
            fechasSource = new BindingSource(fechasBinding, null);
            dgvFechasElegidas.DataSource = fechasSource;
            //Uso las tres columnas, les pongo nombre y un tamaño autoajustable
            dgvFechasElegidas.Columns[0].HeaderText = "Fecha";
            dgvFechasElegidas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFechasElegidas.Columns[4].HeaderText = "Hora";
            dgvFechasElegidas.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFechasElegidas.Columns[7].HeaderText = "Minutos";
            dgvFechasElegidas.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //Para que tanto minutos como horas sean obligatoriamente dos digitos
            dgvFechasElegidas.Columns[4].DefaultCellStyle.Format = "00";
            dgvFechasElegidas.Columns[7].DefaultCellStyle.Format = "00";
            ocultarColumnasNoUtilizadas(dgvFechasElegidas);
        }

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

        private void btnFechaAgregar_Click(object sender, EventArgs e)
        {

            errorProvider.Clear();

            DateTime fechaIngresada = dtpFecha.Value.Date + dtpHorario.Value.TimeOfDay;
            
            //Siempre chequeo esto, haya cuantas fechas haya
            if (fechaIngresada < fechaConfig)
            {
                errorProvider.SetError(dtpFecha, "No puede ingresar una fecha anterior al dia de hoy");
                return;
            }

            //Verifico que no haya ninguna publicacion con el mismo nombre y rubro que tenga una funcion a esa hora
            String queryFechas = "SELECT cod_publicacion FROM SQLITO.Publicaciones WHERE (publ_descripcion = @Descripcion)";
            queryFechas += " AND (fecha_funcion = @FechaFunc) AND (rubro_id = @RubroID)";
            SqlCommand cmdFechas = Database.createQuery(queryFechas);
            cmdFechas.Parameters.AddWithValue("@Descripcion", tbDescripcion.Text);
            cmdFechas.Parameters.Add("@FechaFunc", SqlDbType.DateTime).Value = fechaIngresada;
            cmdFechas.Parameters.AddWithValue("@RubroID", comboRubro.SelectedValue.ToString());
            DataTable dt = Database.getTable(cmdFechas);
            if (dt.Rows.Count > 0)
            {
                errorProvider.SetError(dtpFecha, "Ya existe una funcion de un espectaculo homonimo en ese horario; ingrese otra");
                return;
            }

            //Si y solo si ya hay elementos en la lista (si ya se eligieron fechas de funciones)
            if (fechasFuncion.Count != 0)
            {
                //Manejo posibles errores (fecha ingresada no posterior, o dos funciones a la misma hora)
                if (fechaIngresada < fechasFuncion.Last())
                {
                    errorProvider.SetError(dtpFecha, "Ingrese una fecha posterior a la ultima ingresada");
                    return;
                }
                else if (fechaIngresada == fechasFuncion.Last())
                {
                    errorProvider.SetError(dtpFecha, "No puede ingresar dos funciones en la misma fecha y hora");
                    return;
                }

                fechasFuncion.Add(fechaIngresada);
                actualizarDatosDGV();

            }
            //Si no hay elementos en la lista, entonces ingreso la fecha, sea cual sea
            else
            {
                
                fechasFuncion.Add(fechaIngresada);
                actualizarDatosDGV();

            }

        }

        private void btnFechaEliminar_Click(object sender, EventArgs e)
        {

            if (fechasFuncion.Count == 0)
            {
                errorProvider.SetError(btnFechaEliminar, "No hay fechas para eliminar");
                return;
            }

            errorProvider.Clear();

            fechasFuncion.RemoveAt(fechasFuncion.Count - 1);
            actualizarDatosDGV();

        }

        private void btnUbicaciones_Click(object sender, EventArgs e)
        {
            //Abro la ventana de Disposicion de Ubicaciones con los pares como estan guardados
            DisposicionUbicaciones disp = new DisposicionUbicaciones(paresTT, ubicacionesIngresadas);
            disp.ShowDialog();
            //Una vez que vuelve de la ventana auxiliar, actualizo el array de pares de esta ventana
            paresTT = disp.paresTT;
        }

        private void btnBorrador_Click(object sender, EventArgs e)
        {

            String descripcion;
            String direccion;
            String grado;
            String comision;
            String rubro;

            //Manejo de errores
            errorProvider.Clear();
            if ((string.IsNullOrWhiteSpace(tbDescripcion.Text)))
            {
                errorProvider.SetError(tbDescripcion, "Debe ingresar una descripcion o nombre para la publicacion");
                return;
            }
            if (fechasFuncion.Count == 0)
            {
                errorProvider.SetError(dgvFechasElegidas, "No ha ingresado fechas de funcion. Debe especificar al menos una");
                return;
            }

            //Manejo de campos no completados
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

            descripcion = tbDescripcion.Text;

            String queryFecha;
            SqlCommand cmdFecha;

            foreach (var fecha in fechasFuncion)
            {
                queryFecha = "INSERT INTO SQLITO.Publicaciones (publ_descripcion, fecha_creacion, fecha_funcion, direccion, ";
                queryFecha += "empresa_id, grado_id, publ_comision, rubro_id, estado_id) VALUES(@Descripcion, @FechaCreacion, ";
                queryFecha += "@FechaFuncion, @Direccion, @EmpresaID, @GradoID, @Comision, @RubroID, 1)";
                cmdFecha = Database.createQuery(queryFecha);
                cmdFecha.Parameters.AddWithValue("@Descripcion", descripcion);
                cmdFecha.Parameters.Add("@FechaCreacion", SqlDbType.DateTime).Value = fechaConfig;
                cmdFecha.Parameters.Add("@FechaFuncion", SqlDbType.DateTime).Value = fecha;
                cmdFecha.Parameters.AddWithValue("@Direccion", direccion);
                cmdFecha.Parameters.AddWithValue("@EmpresaID", idEmpresa);
                cmdFecha.Parameters.AddWithValue("@GradoID", grado);
                cmdFecha.Parameters.Add("@Comision", SqlDbType.Decimal).Value = Double.Parse(comision);
                cmdFecha.Parameters.AddWithValue("@RubroID", rubro);
                //Luego de armar el INSERT individual de la fecha que estoy recorriendo, agrego la funcion en la misma
                Database.execQuery(cmdFecha);

                //Obtengo el cod_espectaculo, que voy a necesitar para persistir las Ubicaciones
                //Para agarrarlo, busco el mayor cod_publicacion de la tabla. que es el de la Publicacion recien agregada
                queryFecha = "SELECT TOP 1 cod_publicacion FROM SQLITO.Publicaciones ORDER BY cod_publicacion DESC";
                cmdFecha = Database.createQuery(queryFecha);
                String idEspectaculo = Database.getValue(cmdFecha);

                String queryUbicacion;
                SqlCommand cmdUbicacion;

                //Para esa funcion de la publicacion, persisto todas las ubicaciones ingresadas
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
                    cmdUbicacion.Parameters.AddWithValue("@PublicacionID", idEspectaculo);
                    //Luego de armar el INSERT individual de la ubicacion que estoy recorriendo, la persisto
                    Database.execQuery(cmdUbicacion);
                }

                this.Close();
            }

        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {

            //Manejo de errores
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
            if (fechasFuncion.Count == 0)
            {
                errorProvider.SetError(dgvFechasElegidas, "No ha ingresado fechas de funcion. Debe especificar al menos una");
                return;
            }

            //Obtencion de valores ingresados
            String descripcion = tbDescripcion.Text;
            String direccion = tbDireccion.Text;
            String grado = comboGrado.SelectedValue.ToString();
            String queryComision = "SELECT comision FROM SQLITO.Grados WHERE id_grado = " + grado;
            SqlCommand cmdComision = Database.createQuery(queryComision);
            String comision = Database.getValue(cmdComision);
            String rubro = comboRubro.SelectedValue.ToString();

            //Persistencia de registros
            String queryFecha;
            SqlCommand cmdFecha;

            foreach (var fecha in fechasFuncion)
            {
                 
                queryFecha = "INSERT INTO SQLITO.Publicaciones (publ_descripcion, fecha_creacion, fecha_funcion, fecha_vencimiento, ";
                queryFecha += "direccion, empresa_id, grado_id, publ_comision, rubro_id, estado_id) VALUES(@Descripcion, ";
                queryFecha += "@FechaCreacion, @FechaVenc, @FechaFuncion, @Direccion, @EmpresaID, @GradoID, @Comision, @RubroID, 2)";
                cmdFecha = Database.createQuery(queryFecha);
                cmdFecha.Parameters.AddWithValue("@Descripcion", descripcion);
                cmdFecha.Parameters.Add("@FechaCreacion", SqlDbType.DateTime).Value = fechaConfig;
                cmdFecha.Parameters.Add("@FechaFuncion", SqlDbType.DateTime).Value = fecha;
                //Siguiendo el patron de la migracion, las fechas de vencimiento son una semana antes de la fecha de la funcion
                DateTime fechaVenc = ObtenerFechaVencimiento(fecha, fechaConfig);
                cmdFecha.Parameters.Add("@FechaVenc", SqlDbType.DateTime).Value = fechaVenc;
                cmdFecha.Parameters.AddWithValue("@Direccion", direccion);
                cmdFecha.Parameters.AddWithValue("@EmpresaID", idEmpresa);
                cmdFecha.Parameters.AddWithValue("@GradoID", grado);
                cmdFecha.Parameters.Add("@Comision", SqlDbType.Decimal).Value = Double.Parse(comision);
                cmdFecha.Parameters.AddWithValue("@RubroID", rubro);
                //Luego de armar el INSERT individual de la fecha que estoy recorriendo, agrego la funcion en la misma
                Database.execQuery(cmdFecha);

                //Obtengo el cod_espectaculo, que voy a necesitar para persistir las Ubicaciones
                //Para agarrarlo, busco el mayor cod_publicacion de la tabla. que es el de la Publicacion recien agregada
                queryFecha = "SELECT TOP 1 cod_publicacion FROM SQLITO.Publicaciones ORDER BY cod_publicacion DESC";
                cmdFecha = Database.createQuery(queryFecha);
                String idEspectaculo = Database.getValue(cmdFecha);

                String queryUbicacion;
                SqlCommand cmdUbicacion;

                //Para esa funcion de la publicacion, persisto todas las ubicaciones ingresadas
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
                    cmdUbicacion.Parameters.AddWithValue("@PublicacionID", idEspectaculo);
                    //Luego de armar el INSERT individual de la ubicacion que estoy recorriendo, la persisto
                    Database.execQuery(cmdUbicacion);
                }

                this.Close();

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbDescripcion.Text = "";
            tbDireccion.Text = "";
            fechasFuncion = new List<DateTime>();
            actualizarDatosDGV();
            ubicacionesIngresadas = new List<Ubicacion>();
            InicializarPares();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Eventos

    }
}
