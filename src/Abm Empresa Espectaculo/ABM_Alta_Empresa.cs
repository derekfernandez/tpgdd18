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

        private void btnCargar_Click(object sender, EventArgs e)
        {
               try
            {
                   //Temporal
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                   /*Lo mejor seria agregar un stored proc que ejecute todo lo siguiente:
                    * Genere Validaciones de CUIT y demas, agregue la fecha actual*/
                string insert = string.Format("insert into Empresas values('{0}','{1}','{2}','{3}','{4}','{5}'", textBoxRazonSocial.Text,textBoxCuit.Text,textBoxMail.Text,textBoxDireccion,textBoxTelefono.Text, sqlFormattedDate);
                Database.execNonQuery(Database.createQuery(insert));
                
            }
            catch(Exception exp) 
            {
                throw new Exception("Error al ejecutar la query: " + exp.Message);
            }
            finally
            {
                Database.cerrar();
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
            catch (Exception)
            {

                throw;
            }

        }
        public Boolean CamposVacio()
        {
            //Buscar una funcion que ya evalue si los campos son blancos: seguro hay
            foreach (Control c in this.Controls)
            {

                if (c is TextBox && c.Text == "")
                {
                    return true;
                }

            }
            return false;
        }

        
      

       

     
    }
}
