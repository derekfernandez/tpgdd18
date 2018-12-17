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


        public Grado()
        {
            //Pepe despues me tiene que pasar por parametro el cod de la publicacion
            InitializeComponent();
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
            transformarComision();
            if (!comisionValida())
            {
                MessageBox.Show("Ingrese una comision valida");
            }
            else
            {
            string ingresar = string.Format("pr_Carga_Grado '{0}','{1}'", textBoxDescripcion.Text, textBoxComision.Text);
            try
             {
                if (algunNulo())
                {
                    MessageBox.Show("Error: Descripcion vacia");
                }
                else
                {
                    Database.ejecutarNonQueryShort(ingresar);
                    MessageBox.Show("Grado ingresado correctamente");
                    cargarGrilla();
                }
             }
            catch (Exception exp)
             {
                MessageBox.Show("Error: " + exp.Message);
             }
            }
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

        private void Grado_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            //Falta referencias al menu:
            this.Close();
        }
        public Boolean algunNulo()
        {
            if (textBoxDescripcion.Text == "" || textBoxComision.Text == "")
                return true;
            return false;
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Valida ID
            string query = string.Format("select * from SQLITO.Grados where id_grado = '{0}'", textBoxIDaModificar.Text);
            if (Database.ObtenerDataSet(query).Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("ID no encontrado");       
            }
            else
            {
            this.Hide();
            ModificarGrado modgrado = new ModificarGrado(textBoxIDaModificar.Text);
            modgrado.Show();
            }
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            //Valida ID
            string query = string.Format("select * from SQLITO.Grados where id_grado = '{0}'", textBoxIDaModificar.Text);
            if (Database.ObtenerDataSet(query).Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("ID no encontrado");
            }
            else
            {
                try
                {
                    string eliminar = string.Format("update SQLITO.Grados set habilitado = 0 where id_grado = '{0}'", textBoxIDaModificar.Text);
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

        public void transformarComision()
        {
            if (textBoxComision.Text.Contains(','))
                textBoxComision.Text = textBoxComision.Text.Replace(',', '.');
        }

        public Boolean comisionValida() 
        {
            string comision = textBoxComision.Text;

            if (comision.Contains('.'))
                comision = comision.Replace('.', '1');

            foreach (char c in comision)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

   
   }
    
}
