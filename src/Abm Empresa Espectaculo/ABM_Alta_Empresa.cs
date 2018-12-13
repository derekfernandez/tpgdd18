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

using PalcoNet.Controllers;


namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class ABM_Alta_Empresa : Form
    {
        
        public ABM_Alta_Empresa()
        {
            InitializeComponent();
        }

        private void ABM_empresa_publicacion_Load(object sender, EventArgs e)
        {

        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {

                if (c is TextBox)
                {

                    c.Text = "";

                }

            }
        }

        public void controlarNulos () 
        {
         foreach (Control c in Controls)
            {

                if (c is TextBox && c.Text == "")
                {

                    c.Text = null;

                }

            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            string select = string.Format("exec pr_Alta_Empresa '{0}','{1}','{2}','{3}','{4}'", textBoxRazonSocial.Text, textBoxCuit.Text, textBoxMail.Text, textBoxDireccion.Text, textBoxTelefono.Text);
            string error;

            if(1==0)
            {
                MessageBox.Show("Error: " + error);
            }
            else
            {
               try
            {
                   /*Lo mejor seria agregar un stored proc que ejecute todo lo siguiente:
                    * Genere Validaciones de CUIT y demas, agregue la fecha actual*/

                controlarNulos();

                string insert = string.Format("exec pr_Alta_Empresa '{0}','{1}','{2}','{3}','{4}'", textBoxRazonSocial.Text, textBoxCuit.Text, textBoxMail.Text, textBoxDireccion.Text, textBoxTelefono.Text);
                
                Database.ejecutarNonQueryShort(insert);
                MessageBox.Show("Empresa agregadas ");

                
            }
            catch(Exception exp) 
            {
                 MessageBox.Show("Error al ejecutar la query: " + exp.Message);
            }
            finally
            {
                Database.cerrar();
            }
            }


          
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                //Aca se va a llamar al Form anterior donde estan las opciones del admin
                this.Hide();
                ABM_Menu_Empresa nuevoMenu = new ABM_Menu_Empresa();
                nuevoMenu.Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error " + exp.Message);
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

        private void ABM_Alta_Empresa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
      

       

     
    }
}
