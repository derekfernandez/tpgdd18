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

        //Atributos de controles
        CheckBox[] filtrosRubro;
        DateTime fechaConfig;
        ErrorProvider errorProvider;
        DataTable tablaPaginaActual;
        DateTime fechaInicial;
        DateTime fechaFinal;

        //Atributos de datos de sesion
        String idUsuario;
        String idCliente;
        public Usuario user { get; set; }
        public Session session { get; set; }

        //Atributos de paginacion
        private const int resultadosPorPagina = 10;
        private int paginaActual = 1;                               //Deberia arrancar en la primer pagina
        private int totalPaginas;
        private int resultadosDePaginasAnteriores;                  //Para saber cuanto moverme en el SELECT de carga

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

            //Deshabilito botones, asi no se pueden utilizar hasta la primera busqueda
            btnPrimeraPag.Enabled = false;
            btnPagAnt.Enabled = false;
            btnPagSig.Enabled = false;
            btnUltimaPag.Enabled = false;

            //Escondo el label, asi no se lo ve hasta que se haga la primera busqueda
            lbPagina.Visible = false;
            lbPagina.Text = "";

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

            query += " AND (rubro_id IN (";

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

            tablaPaginaActual = Database.getTable(cmd);

            //Lleno el DGV y formateo sus columnas/filas
            dgvPublicaciones.DataSource = tablaPaginaActual;
            dgvPublicaciones.Columns[0].Visible = false;
            dgvPublicaciones.Columns[1].HeaderText = "Nombre";
            dgvPublicaciones.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPublicaciones.Columns[2].HeaderText = "Fecha";
            dgvPublicaciones.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //Recordar: HH asi en mayuscula es para que me muestre las horas en formato 24h
            dgvPublicaciones.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvPublicaciones.Columns[3].HeaderText = "Rubro";
            dgvPublicaciones.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void CalcularTotalDePaginas(SqlCommand cmdBase)
        {

            DataTable tablaMasiva = Database.getTable(cmdBase);
            
            int cantidadResultados = tablaMasiva.Rows.Count;
            totalPaginas = cantidadResultados / resultadosPorPagina;
            //Si la cantidad de resultados no es multiplo de los resultados por pagina, entonces me va a quedar una pagina
            //mas, a medio llenar; como la division entera trunca, le sumo uno al total de paginas
            if ((cantidadResultados % resultadosPorPagina) != 0)
            {
                totalPaginas++;
            }

        }

        #endregion Verificaciones

        #region Paginacion

        private void obtenerPublicaciones()
        {

            //Primero, calculo cuantos resultados deberia dejar atras en base a la pagina actual
            //Tener en cuenta que la query se ejecuta para cada pagina, no es una general para todo
            resultadosDePaginasAnteriores = (paginaActual - 1) * resultadosPorPagina;

            #region Atributos

            //Parte que tendran en comun las querys, tanto la principal como el subSELECT del NOT IN
            String queryComun;
            //Parte que ira en el NOT IN para no traer datos de paginas anteriores
            String queryNotIn;
            //Query que voy a ejecutar para traer todas las publicaciones posibles y obtener la cantidad de paginas
            String queryMasiva;
            SqlCommand cmdMasiva;
            //Query efectiva que voy a usar para traer las publicaciones que necesito para la pagina actual
            String queryPublicaciones;
            SqlCommand cmdPublicaciones;

            #endregion Atributos

            #region ArmadoQueryComun

            //Hago todos los CONVERT por temas de tipo, y el ISNULL porque si la fecha es NULL nunca es mayor ni menor a nada
            queryComun = "FROM SQLITO.Publicaciones JOIN SQLITO.Rubros ON (rubro_id = id_rubro) JOIN SQLITO.";
            queryComun += "Grados ON (grado_id = id_grado) WHERE (CONVERT(DATE, fecha_funcion) BETWEEN @FechaInicial ";
            queryComun += "AND @FechaFinal) AND (estado_id = 2) AND (ISNULL(fecha_creacion, 0) <= CONVERT(DATE, @FechaActual))";
            queryComun += " AND (ISNULL(fecha_vencimiento, 0) > CONVERT(DATE, @FechaActual))";

            if (FiltrosPorRubroActivados() > 0)
            {
                AgregarRubros(ref queryComun);
            }
            //Si hay texto dentro del textBox de Nombre, agrego la clausula LIKE para buscarlo por ese patron
            if (!(string.IsNullOrWhiteSpace(tbNombre.Text)))
            {
                queryComun += (" AND (publ_descripcion LIKE '%" + tbNombre.Text + "%')");
            }

            #endregion ArmadoQueryComun

            #region ArmadoQueryFinal

            queryNotIn = "(SELECT TOP " + resultadosDePaginasAnteriores.ToString() + " cod_publicacion " + queryComun + " ORDER BY";
            queryNotIn += " comision DESC, publ_descripcion ASC)";

            queryPublicaciones = "SELECT TOP " + resultadosPorPagina.ToString() + " cod_publicacion, publ_descripcion, ";
            queryPublicaciones += ("fecha_funcion, r_descripcion " + queryComun + " AND (cod_publicacion NOT IN " + queryNotIn);
            queryPublicaciones += ") ORDER BY comision DESC, publ_descripcion ASC";

            #endregion ArmadoQueryFinal

            #region LlenadoDeTabla

            //Primero, calculo el total de paginas teniendo en cuenta la busqueda especificada
            queryMasiva = "SELECT cod_publicacion " + queryComun;
            cmdMasiva = Database.createQuery(queryMasiva);
            cmdMasiva.Parameters.Add("@FechaInicial", SqlDbType.Date).Value = fechaInicial;
            cmdMasiva.Parameters.Add("@FechaFinal", SqlDbType.Date).Value = fechaFinal;
            cmdMasiva.Parameters.Add("@FechaActual", SqlDbType.Date).Value = fechaConfig;
            CalcularTotalDePaginas(cmdMasiva);

            //Y luego completo el DGV con los datos necesarios, en base a la pagina elegida y demas
            cmdPublicaciones = Database.createQuery(queryPublicaciones);
            cmdPublicaciones.Parameters.Add("@FechaInicial", SqlDbType.Date).Value = fechaInicial;
            cmdPublicaciones.Parameters.Add("@FechaFinal", SqlDbType.Date).Value = fechaFinal;
            cmdPublicaciones.Parameters.Add("@FechaActual", SqlDbType.Date).Value = fechaConfig;            
            LlenarDGV(cmdPublicaciones);

            #endregion LlenadoDeTabla

        }

        #endregion Paginacion

        #region Eventos

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            fechaInicial = dtpInicial.Value.Date;
            fechaFinal = dtpFinal.Value.Date;

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

            obtenerPublicaciones();

            //Inhabilito los botones de primera pagina y pagina anterior, y actualizo el label
            btnPagAnt.Enabled = false;
            btnPrimeraPag.Enabled = false;
            lbPagina.Visible = true;
            if (totalPaginas == 0)
            {
                lbPagina.Text = "Pagina 0 de 0";
            }
            else
            {
                lbPagina.Text = "Pagina 1 de " + totalPaginas.ToString();
            }
            
            //Si hubiera mas de una pagina, permito ir a la siguiente y/o a la ultima
            if (totalPaginas > 1)
            {
                btnPagSig.Enabled = true;
                btnUltimaPag.Enabled = true;
            }

        }

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
            fechaInicial = dtpInicial.Value.Date;
            fechaFinal = dtpFinal.Value.Date;
            obtenerPublicaciones();

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

            //Actualizo el DGV y muestro solo la pagina solicitada
            fechaInicial = dtpInicial.Value.Date;
            fechaFinal = dtpFinal.Value.Date;
            obtenerPublicaciones();

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

            //Actualizo el DGV y muestro solo la pagina solicitada
            fechaInicial = dtpInicial.Value.Date;
            fechaFinal = dtpFinal.Value.Date;
            obtenerPublicaciones();

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

            //Actualizo el DGV y muestro solo la pagina solicitada
            fechaInicial = dtpInicial.Value.Date;
            fechaFinal = dtpFinal.Value.Date;
            obtenerPublicaciones();

        }

        //Destildo todos los CheckBox, pongo la fecha como al iniciar, y vacio el textBox de descripcion
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
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

            #region PrimeraPaginaDeNuevo

            //Actualizo la pagina actual
            paginaActual = 1;

            //Anulo botones de Primera Pagina y Pagina Anterior, y activo los de Pagina Siguiente y Ultima Pagina
            btnPrimeraPag.Enabled = false;
            btnPagAnt.Enabled = false;
            btnPagSig.Enabled = true;
            btnUltimaPag.Enabled = true;

            //Actualizo el DGV y muestro solo la primera pagina
            fechaInicial = dtpInicial.Value.Date;
            fechaFinal = dtpFinal.Value.Date;
            obtenerPublicaciones();

            //Ahora que ya obtuve las publicaciones y calcule las paginas, pongo el label como se debe
            lbPagina.Text = "Pagina 1 de " + totalPaginas.ToString();
            lbPagina.Visible = true;

            #endregion PrimeraPaginaDeNuevo


        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiarResultados_Click(object sender, EventArgs e)
        {

            //Vacio la DGV, y reseteo el numero de pagina actual a 1 (IMPORTANTE, asi al volver a buscar no la caga)
            dgvPublicaciones.DataSource = null;
            paginaActual = 1;

            //Deshabilito botones, asi no se pueden utilizar hasta la primera busqueda
            btnPrimeraPag.Enabled = false;
            btnPagAnt.Enabled = false;
            btnPagSig.Enabled = false;
            btnUltimaPag.Enabled = false;

            //Escondo el label, asi no se lo ve hasta que se haga la primera busqueda
            lbPagina.Visible = false;
            lbPagina.Text = "";

        }

        #endregion Eventos

    }
}
