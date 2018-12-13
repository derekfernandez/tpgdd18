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
        
        public SeleccionPublicacion(Usuario user)
        {
            
            InitializeComponent();

            errorProvider = new ErrorProvider();

            //Obtengo el id del usuario logeado, y con él busco el id de la Empresa que posee dicho usuario
            idUsuario = user.id;
            String queryID = "SELECT id_empresa FROM SQLITO.Empresas WHERE usuario_id = " + idUsuario;
            SqlCommand cmd = Database.createQuery(queryID);
            idEmpresa = Database.getValue(cmd);

            //Oculto las flechas del NUD
            numId.Controls[0].Visible = false;

            //Obtengo datos para llenar el DGV
            String queryPublicaciones = "SELECT cod_publicacion, descripcion, fecha_creacion, fecha_funcion FROM SQLITO.Publicaciones ";
            queryPublicaciones += "WHERE (empresa_id = @Empresa) AND (estado_id = 1)";
            SqlCommand cmdPublic = Database.createQuery(queryPublicaciones);
            cmdPublic.Parameters.AddWithValue("@Empresa", idEmpresa);
            tablaEditables = Database.getTable(cmdPublic);

            //Lleno el DGV y formateo sus columnas/filas
            ActualizarDGVEditables();

        }

        private void ActualizarDGVEditables()
        {

            String queryPublicaciones = "SELECT cod_publicacion, descripcion, fecha_creacion, fecha_funcion FROM SQLITO.Publicaciones ";
            queryPublicaciones += "WHERE (empresa_id = @Empresa) AND (estado_id = 1)";
            SqlCommand cmdPublic = Database.createQuery(queryPublicaciones);
            cmdPublic.Parameters.AddWithValue("@Empresa", idEmpresa);
            tablaEditables = Database.getTable(cmdPublic);

            //Lleno el DGV y formateo sus columnas/filas
            dgvEditables.DataSource = tablaEditables;
            dgvEditables.Columns[0].HeaderText = "ID";
            dgvEditables.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEditables.Columns[1].HeaderText = "Descripcion";
            dgvEditables.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEditables.Columns[2].HeaderText = "Fecha de creacion";
            //Recordar: HH asi en mayuscula es para que me muestre las horas en formato 24h
            dgvEditables.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvEditables.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEditables.Columns[3].HeaderText = "Fecha de funcion";
            dgvEditables.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvEditables.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEditables.AllowUserToAddRows = false;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            //Manejo de errores
            errorProvider.Clear();
            String idElegido = numId.Text;
            
            if (numId.Text == "")
            {
                errorProvider.SetError(numId, "Debe ingresar el ID de la publicacion a editar");
                return;
            }

            DataRow[] filas = tablaEditables.Select("cod_publicacion = '" + idElegido + "'");
            if (filas.Length == 0)
            {
                errorProvider.SetError(dgvEditables, "No existe ninguna publicacion editable con el ID ingresado");
                return;
            }

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
