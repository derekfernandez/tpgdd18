using PalcoNet.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Editar_Publicacion
{
    public partial class SeleccionPublicacion : Form
    {

        String idUsuario;
        String idEmpresa;
        ErrorProvider errorProvider;
        DataTable tablaEditables;
        Usuario user { get; set; }
        Session session { get; set; }

        public SeleccionPublicacion(Session session)
        {
            this.session = session;
            user = session.user;
            InitializeComponent();

            errorProvider = new ErrorProvider();

            //Obtengo el id del usuario logeado, y con él busco el id de la Empresa que posee dicho usuario
            idUsuario = user.id;
            String queryID = "SELECT id_empresa FROM SQLITO.Empresas WHERE usuario_id = " + idUsuario;
            SqlCommand cmd = Database.createQuery(queryID);
            idEmpresa = Database.getValue(cmd);

            //Lleno el DGV y formateo sus columnas/filas
            dgvEditables.AllowUserToAddRows = false;
            ActualizarDGVEditables();

        }

        private void ActualizarDGVEditables()
        {

            String queryPublicaciones = "SELECT cod_publicacion, publ_descripcion, fecha_creacion, fecha_funcion ";
            queryPublicaciones += "FROM SQLITO.Publicaciones WHERE (empresa_id = @Empresa) AND (estado_id = 1)";
            SqlCommand cmdPublic = Database.createQuery(queryPublicaciones);
            cmdPublic.Parameters.AddWithValue("@Empresa", idEmpresa);
            tablaEditables = Database.getTable(cmdPublic);

            //Lleno el DGV y formateo sus columnas/filas
            dgvEditables.DataSource = tablaEditables;
            dgvEditables.Columns[0].Visible = false;
            dgvEditables.Columns[1].HeaderText = "Descripcion";
            dgvEditables.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEditables.Columns[2].HeaderText = "Fecha de creacion";
            //Recordar: HH asi en mayuscula es para que me muestre las horas en formato 24h
            dgvEditables.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvEditables.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEditables.Columns[3].HeaderText = "Fecha de funcion";
            dgvEditables.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvEditables.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            //Manejo de errores
            errorProvider.Clear();
            
            if (dgvEditables.CurrentRow == null)
            {
                errorProvider.SetError(dgvEditables, "Elija la publicacion a editar");
                return;
            }

            String idElegido = dgvEditables.CurrentRow.Cells[0].Value.ToString();

            Editar_Publicacion.EdicionPublicacion ep = new Editar_Publicacion.EdicionPublicacion(idEmpresa, idElegido);
            ep.ShowDialog();
            ActualizarDGVEditables();
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
