using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Generar_Publicacion;
using PalcoNet.Misc;
using System.Data.SqlClient;

namespace PalcoNet.Abm_Grado
{
    public partial class Grado : Form
    {

        string id = "-1";
        

        public Session session { get; set; }
        public Grado(Session session)
        {
            //Pepe despues me tiene que pasar por parametro el cod de la publicacion
            this.session = session;
            InitializeComponent();

            //Configuro y cargo el DGV
            grillaGrados.AllowUserToAddRows = false;
            grillaGrados.AllowUserToDeleteRows = false;
            cargarGrilla();
            
        }

        private void cargarGrilla()
        {

            try
            {

                string query = "SELECT * FROM SQLITO.Grados ORDER BY comision";

                grillaGrados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                grillaGrados.DataSource = Database.ObtenerDataSet(query).Tables[0];

                grillaGrados.Columns[0].Visible = false;
                grillaGrados.Columns[1].HeaderText = "Descripcion";
                grillaGrados.Columns[2].HeaderText = "Comision";
                grillaGrados.Columns[3].HeaderText = "Habilitado";

                //De entrada, ambos botones estan desactivados, y hago que no haya fila seleccionada
                grillaGrados.ClearSelection();
                btnHabilitar.Enabled = false;
                btnDeshabilitar.Enabled = false;

            }
            catch (Exception exp)
            {
                MessageBox.Show("Error: " + exp.Message);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
         
            Abm_Grado.AgregarGrado nuevoAgregado = new AgregarGrado();
            nuevoAgregado.ShowDialog();
            cargarGrilla();

        }
 

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        


        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            if(id == "-1")
            {
                MessageBox.Show("Seleccione una fila");
            }
            else
            {
            
                string query = string.Format("SELECT * FROM SQLITO.Grados WHERE id_grado = '{0}'", id);
                if (Database.ObtenerDataSet(query).Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("ID no encontrado");       
                }
                else
                {
                    ModificarGrado modgrado = new ModificarGrado(id);
                    modgrado.ShowDialog();
                    cargarGrilla();
                }
            }

        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            
            if(id == "-1")
            {
                MessageBox.Show("Seleccione una fila");
            }
            else
            {
                string query = string.Format("SELECT * FROM SQLITO.Grados WHERE id_grado = '{0}'", id);
                if (Database.ObtenerDataSet(query).Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("ID no encontrado");
                }
                else
                {
                    try
                    {
                        id = grillaGrados.CurrentRow.Cells[0].Value.ToString();
                        string eliminar = string.Format("UPDATE SQLITO.Grados SET habilitado = 0 WHERE id_grado = '{0}'", id);
                        Database.ejecutarNonQueryShort(eliminar);
                        MessageBox.Show("Grado deshabilitado correctamente");
                        cargarGrilla();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Error: " + exp.Message);
                    }
                }
            }

        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {

            //Primero armo la query y actualizo el grado a Habilitado
            String queryHabilitar = "UPDATE SQLITO.Grados SET habilitado = 1 WHERE id_grado = @GradoID";
            SqlCommand cmdHabilitar = Database.createQuery(queryHabilitar);
            cmdHabilitar.Parameters.AddWithValue("@GradoID", grillaGrados.CurrentRow.Cells[0].Value.ToString());
            Database.execQuery(cmdHabilitar);
            MessageBox.Show("Grado habilitado correctamente");
            //Vuelvo a cargar la grilla antes de olvidarme
            cargarGrilla();

        }    

        private void grillaGrados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            id = Convert.ToString(grillaGrados.SelectedCells[0].RowIndex + 1);

            //Si el grado sobre el que me pare esta habilitado, solo enciendo el boton de Deshabilitar
            if (grillaGrados.CurrentRow.Cells[3].Value.ToString() == "True")
            {
                btnHabilitar.Enabled = false;
                btnDeshabilitar.Enabled = true;
            }
            //Si el grado sobre el que me pare esta inhabilitado, solo enciendo el boton de Habilitar
            else if(grillaGrados.CurrentRow.Cells[3].Value.ToString() == "False")
            {
                btnHabilitar.Enabled = true;
                btnDeshabilitar.Enabled = false;
            }

        }

  

   }
    
}
