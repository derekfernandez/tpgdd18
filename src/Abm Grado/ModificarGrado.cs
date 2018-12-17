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


namespace PalcoNet.Abm_Grado
{
    public partial class ModificarGrado : Form
    {
        string gradoAModificar;
        public ModificarGrado(string gradoAModificar)
        {
            InitializeComponent();
            this.gradoAModificar = gradoAModificar;
            cargarTextBox();
        }

        public void cargarTextBox() 
        {

            string query = string.Format("select * from SQLITO.Grados where id_grado = '{0}'", gradoAModificar);

           textBoxDescripcion.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["descripcion"].ToString();
           textBoxComision.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["comision"].ToString();
      
           string habilitado = Database.ObtenerDataSet(query).Tables[0].Rows[0]["habilitado"].ToString();
           
           if (habilitado == "True")
           {
               comboBox1.SelectedIndex = 0;
           }
           else
               comboBox1.SelectedIndex = 1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            transformarComision();
            if (!comisionValida())
            {
                MessageBox.Show("Ingrese una comision valida");
            }
            else
            {
                string update = string.Format("EXEC pr_Mod_Grado '{0}','{1}','{2}','{3}'", textBoxDescripcion.Text, textBoxComision.Text, obtenerHabilitado(), gradoAModificar);
                try
                {
                    Database.ejecutarNonQueryShort(update);
                    MessageBox.Show("Grado modificado correctamente");
                    this.Hide();
                    Abm_Grado.Grado nuevoGrado = new Grado();
                    nuevoGrado.Show();
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error: " + exp.Message);
                }
            }
        }

        public string obtenerHabilitado()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                return "1";
            }
            return "0";
        }

        private void ModificarGrado_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void transformarComision() 
        {
            if (textBoxComision.Text.Contains(","))
              textBoxComision.Text = textBoxComision.Text.Replace(",", ".");
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Abm_Grado.Grado nuevoGrado = new Grado();
            nuevoGrado.Show();
        }

    }
}
