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

namespace PalcoNet.Abm_Grado
{
    public partial class Grado : Form
    {

        string id = "-1";
        int selector = -1;

        public Session session { get; set; }
        public Grado(Session session)
        {
            //Pepe despues me tiene que pasar por parametro el cod de la publicacion
            this.session = session;
            InitializeComponent();
            grillaGrados.AllowUserToAddRows = false;
            grillaGrados.AllowUserToDeleteRows = false;
            cargarGrilla();
            
        }

        private void cargarGrilla()
        {

            try
            {

                string query = "select * from SQLITO.Grados";

                grillaGrados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                grillaGrados.DataSource = Database.ObtenerDataSet(query).Tables[0];

                grillaGrados.Columns[0].HeaderText = "ID";
                grillaGrados.Columns[1].HeaderText = "Descripcion";
                grillaGrados.Columns[2].HeaderText = "Comision";
                grillaGrados.Columns[3].HeaderText = "Habilitado";

            }
            catch (Exception exp)
            {
                MessageBox.Show("Error: " + exp.Message);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
         
            Abm_Grado.AgregarGrado nuevoAgregado = new AgregarGrado();
            nuevoAgregado.Show();

        }
        /*
        private void btnModificar_Click(object sender, EventArgs e)
        {
            string modificar = string.Format("update SQLITO.Grados set descripcion = '{0}',comision = '{1}' where id_grado = '{2}'", textBoxDescripcion.Text, textBoxComision.Text, textBoxBuscar.Text);
            try
            {

                    Database.ejecutarNonQueryShort(modificar);
                    MessageBox.Show("Grado modificado correctamente");
                
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error: " + exp.Message);
            }
        }*/

 

        private void btnVolver_Click(object sender, EventArgs e)
        {
            //Falta referencias al menu:
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
            
            string query = string.Format("select * from SQLITO.Grados where id_grado = '{0}'", id);
            if (Database.ObtenerDataSet(query).Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("ID no encontrado");       
            }
            else
            {
           
            ModificarGrado modgrado = new ModificarGrado(id);
            modgrado.Show();
            }
            }
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            //Valida ID
            if(id == "-1")
            {
                MessageBox.Show("Seleccione una fila");
            }
            else
            {
            
            string query = string.Format("select * from SQLITO.Grados where id_grado = '{0}'", id);
            if (Database.ObtenerDataSet(query).Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("ID no encontrado");
            }
            else
            {
                try
                {
                    string eliminar = string.Format("update SQLITO.Grados set habilitado = 0 where id_grado = '{0}'", id);
                    Database.ejecutarNonQueryShort(eliminar);
                    MessageBox.Show("Grado Deshabilitado correctamente");
                    cargarGrilla();
                }
                catch (Exception exp)
                {

                    MessageBox.Show("Error: " + exp.Message);
                }
            }
            }
        }

        private void grillaGrados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                        
                    selector = grillaGrados.SelectedCells[0].RowIndex + 1;
                    id = selector.ToString();        
         
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarGrilla();
        }


      

   }
    
}
