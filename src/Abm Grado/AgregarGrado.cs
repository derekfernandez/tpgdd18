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
    public partial class AgregarGrado : Form
    {
   

        public AgregarGrado()
        {
            InitializeComponent();
            
            cargarTextBox();
        }

        public void cargarTextBox() 
        {

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

                
                    string ingresar = string.Format("pr_Carga_Grado '{0}','{1}'", textBoxDescripcion.Text, textBoxComision.Text);
                    try
                    {
                        
                            Database.ejecutarNonQueryShort(ingresar);
                            MessageBox.Show("Grado ingresado correctamente");

                            this.Hide();
                            Grado nuevoGrado = new Grado();
                            nuevoGrado.Show();

                        
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

               
          #region validaciones Nulos

        #region validarCamposVacios
        public virtual bool validarCamposVacios() 
        {
            bool vacios = false; 

            if(string.IsNullOrWhiteSpace(textBoxComision.Text))
            {
                vacios = true;
                errorProviderComision.SetError(textBoxComision,"Ingrese una comision");
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
            

           if(!(string.IsNullOrWhiteSpace(textBoxComision.Text)))
            {
                
                errorProviderComision.SetError(textBoxComision,"");
            }

           

        
            if (!(string.IsNullOrWhiteSpace(textBoxDescripcion.Text)))
            {
                
                errorProviderDescripcion.SetError(textBoxDescripcion, "");

            }

           

        }

        public virtual void eliminarErrorProvider() 
        {
           errorProviderComision.SetError(textBoxComision,"");
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

        private void textBoxComision_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarIngreso(sender, e);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grado nuevoGrado = new Grado();
            nuevoGrado.Show();
        }
        
    }
}
