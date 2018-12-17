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
    public partial class BusquedaPublicacion : Form
    {

        #region Atributos

        CheckBox[] filtrosRubro;
        DateTime fechaConfig;
        String idUsuario;
        String idCliente;
        ErrorProvider errorProvider;
        public Usuario user { get; set; }
        public Session session { get; set; }

        #endregion Atributos

        #region Inicializacion

        public BusquedaPublicacion(Session session)
        {
            this.session = session;
            user = session.user;
            InitializeComponent();
            errorProvider = new ErrorProvider();
            fechaConfig = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);

            //Obtengo el id del usuario logeado, y con él busco el id de la Empresa que posee dicho usuario
            idUsuario = user.id;
            String queryID = "SELECT id_cliente FROM SQLITO.Clientes WHERE usuario_id = " + idUsuario;
            SqlCommand cmd = Database.createQuery(queryID);
            idCliente = Database.getValue(cmd);

            ConfigurarDTPs();
            InicializarFiltrosRubro();
            dgvPublicaciones.AllowUserToAddRows = false;

        }

        //Carga el array de rubros, donde cada indice representa el id del Rubro menos 1
        private void InicializarFiltrosRubro()
        {

            filtrosRubro = new CheckBox[7];
            filtrosRubro[0] = cbTeatro;
            filtrosRubro[1] = cbCine;
            filtrosRubro[2] = cbConciertos;
            filtrosRubro[3] = cbMusicales;
            filtrosRubro[4] = cbDeportes;
            filtrosRubro[5] = cbInfantiles;
            filtrosRubro[6] = cbOtros;

        }

        private void ConfigurarDTPs()
        {

            dtpInicial.Format = DateTimePickerFormat.Custom;
            dtpInicial.CustomFormat = "dd/MM/yyyy";
            dtpInicial.Value = fechaConfig;

            dtpFinal.Format = DateTimePickerFormat.Custom;
            dtpFinal.CustomFormat = "dd/MM/yyyy";
            dtpFinal.Value = fechaConfig.AddDays(1);

        }

        #endregion Inicializacion

        #region Verificaciones

        private int FiltrosPorRubroActivados()
        {
            return Array.FindAll(filtrosRubro, cb => cb.Checked == true).Count();
        }

        //Agrega los rubros (sentencia IN(...)) a la query pasada por parametro; ref para que la modifique posta
        private void AgregarRubros(ref String query)
        {

            query += " AND (P.rubro_id IN (";

            int cantidadRubros = FiltrosPorRubroActivados();
            int i = 1;
            int j = 0;

            //Si hay n filtros activados, copio los primeros n-1 IDs de rubro correspondientes con un ", " despues
            while (i <= (cantidadRubros - 1))
            {
                while (filtrosRubro[j].Checked == false)
                {
                    j++;
                }
                query += ((j + 1).ToString() + ", ");
                j++;
                i++;
            }

            while (filtrosRubro[j].Checked == false)
            {
                j++;
            }
            query += ((j + 1).ToString() + "))");


        }

        private void LlenarDGV(SqlCommand cmd)
        {

            DataTable tablaPublicaciones = Database.getTable(cmd);
            dgvPublicaciones.DataSource = tablaPublicaciones;

            //Lleno el DGV y formateo sus columnas/filas
            dgvPublicaciones.DataSource = tablaPublicaciones;
            dgvPublicaciones.Columns[0].Visible = false;
            dgvPublicaciones.Columns[1].HeaderText = "Nombre";
            dgvPublicaciones.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPublicaciones.Columns[2].HeaderText = "Fecha";
            dgvPublicaciones.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //Recordar: HH asi en mayuscula es para que me muestre las horas en formato 24h
            dgvPublicaciones.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvPublicaciones.Columns[3].HeaderText = "Rubro";
            dgvPublicaciones.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        #endregion Verificaciones

        #region Eventos

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            String queryPublicaciones;
            SqlCommand cmdPublicaciones;

            DateTime fechaInicial = dtpInicial.Value.Date;
            DateTime fechaFinal = dtpFinal.Value.Date;

            #region ManejoErrores
            errorProvider.Clear();

            if (fechaFinal < fechaConfig)
            {
                errorProvider.SetError(dtpFinal, "No pueden buscarse publicaciones anteriores al dia de hoy");
                return;
            }
            if (fechaInicial < fechaConfig)
            {
                errorProvider.SetError(dtpInicial, "No pueden buscarse publicaciones anteriores al dia de hoy");
                return;
            }
            if (fechaFinal < fechaInicial)
            {
                errorProvider.SetError(dtpFinal, "La fecha final no puede ser anterior a la inicial");
                return;
            }

            #endregion ManejoErrores

            //Hago todos los CONVERT por temas de tipo, y el ISNULL porque si la fecha es NULL nunca es mayor ni menor a nada
            queryPublicaciones = "SELECT P.cod_publicacion, P.descripcion, fecha_funcion, R.descripcion FROM SQLITO.Publicaciones ";
            queryPublicaciones += "AS P JOIN SQLITO.Rubros AS R ON (P.rubro_id = R.id_rubro) JOIN SQLITO.Grados AS G ON (P.grado_id";
            queryPublicaciones += " =  G.id_grado) WHERE (CONVERT(DATE, P.fecha_funcion) BETWEEN @FechaInicial AND @FechaFinal)";
            queryPublicaciones += " AND (estado_id = 2) AND (ISNULL(P.fecha_creacion, 0) <= CONVERT(DATE, @FechaActual)) AND ";
            queryPublicaciones += "(ISNULL(P.fecha_vencimiento, 0) > CONVERT(DATE, @FechaActual))";

            if (FiltrosPorRubroActivados() > 0)
            {
                AgregarRubros(ref queryPublicaciones);
            }
            //Si hay texto dentro del textBox de Nombre, agrego la clausula LIKE para buscarlo por ese patron
            if(!(string.IsNullOrWhiteSpace(tbNombre.Text)))
            {
                queryPublicaciones += (" AND (P.descripcion LIKE '%" + tbNombre.Text + "%')");
            }

            queryPublicaciones += " ORDER BY G.comision DESC, P.descripcion ASC";

            cmdPublicaciones = Database.createQuery(queryPublicaciones);
            cmdPublicaciones.Parameters.Add("@FechaInicial", SqlDbType.Date).Value = fechaInicial;
            cmdPublicaciones.Parameters.Add("@FechaFinal", SqlDbType.Date).Value = fechaFinal;
            cmdPublicaciones.Parameters.Add("@FechaActual", SqlDbType.Date).Value = fechaConfig;

            LlenarDGV(cmdPublicaciones);

        }

        //Destildo todos los CheckBox, pongo la fecha como al iniciar, y vacio el textBox de descripcion
        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 7; i++)
            {
                filtrosRubro[i].Checked = false;
            }
            dtpInicial.Value = fechaConfig;
            dtpFinal.Value = fechaConfig.AddDays(1);
            tbNombre.Text = "";
        }

        private void btnUbicaciones_Click(object sender, EventArgs e)
        {

            errorProvider.Clear();

            if (dgvPublicaciones.CurrentRow == null)
            {
                errorProvider.SetError(dgvPublicaciones, "Seleccione una publicacion");
                return;
            }

            ComprarUbicaciones cu = new ComprarUbicaciones(dgvPublicaciones.CurrentRow.Cells[0].Value.ToString(), idCliente);
            cu.ShowDialog();

            //Vacio el DGV tras efectuar la compra; si quiero volver a comprar, vuelvo a buscar
            dgvPublicaciones.DataSource = null;            

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Eventos

    }
}
