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
            if (validarCamposVacios())
            {
                MessageBox.Show("Ingrese los campos faltantes");
                controlarCamposNoVacios();
            }
            else
            {
                eliminarErrorProvider();
                transformarComision();

                string update = string.Format("EXEC [SQLITO].[pr_Mod_Grado] '{0}','{1}','{2}','{3}'", textBoxDescripcion.Text, textBoxComision.Text, obtenerHabilitado(), gradoAModificar);
                try
                {
                    Database.ejecutarNonQueryShort(update);
                    MessageBox.Show("Grado modificado correctamente");

                    this.Close();
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
            this.Close();
        }


        #region validaciones Nulos

        #region validarCamposVacios
        public virtual bool validarCamposVacios()
        {
            bool vacios = false;

            if (string.IsNullOrWhiteSpace(textBoxComision.Text))
            {
                vacios = true;
                errorProviderComision.SetError(textBoxComision, "Ingrese una comision");
            }




            if (string.IsNullOrWhiteSpace(textBoxDescripcion.Text))
            {
                vacios = true;
                errorProviderDescripcion.SetError(textBoxDescripcion, "Ingrese una descripcion");

            }





            return vacios;

        }
        #endregion

        #region validarCamposNoVacios
        public virtual void controlarCamposNoVacios()
        {


            if (!(string.IsNullOrWhiteSpace(textBoxComision.Text)))
            {

                errorProviderComision.SetError(textBoxComision, "");
            }




            if (!(string.IsNullOrWhiteSpace(textBoxDescripcion.Text)))
            {

                errorProviderDescripcion.SetError(textBoxDescripcion, "");

            }



        }

        public virtual void eliminarErrorProvider()
        {
            errorProviderComision.SetError(textBoxComision, "");
            errorProviderDescripcion.SetError(textBoxDescripcion, "");



        }
        #endregion

        #region controlSobreVacios
        public virtual void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {

                if (c is TextBox)
                {

                    c.Text = "";

                }

            }
        }

        public Boolean CamposVacio()
        {
            //Buscar una funcion que ya evalue si los campos son blancos: seguro hay
            foreach (Control c in Controls)
            {

                if (c is TextBox && c.Text == "")
                {
                    return true;
                }

            }
            return false;
        }

        public Boolean todosNulos()
        {
            foreach (Control c in Controls)
            {

                if (c is TextBox && c.Text.Trim() != "")
                {

                    return false;

                }

            }
            return true;
        }
        #endregion

        #endregion

        #region pre validaciones cuit
        public void validarIngreso(object sender, KeyPressEventArgs e)
        {
            char caracter = e.KeyChar;

            if (!Char.IsDigit(caracter) && caracter != 8 && caracter != ',' && caracter != '.')
            {
                e.Handled = true;
            }
        }

        #endregion

        private void textBoxComision_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            validarIngreso(sender, e);
        }

  


    }
}
