using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
      
            try
            {

                if (this.CamposVacio())
                {
                    MessageBox.Show("Por favor, complete todos los campos correctamente");
                }
                else
                {
                    //Aca iria funcionalidad de ingresar nueva empresa
                    MessageBox.Show("Datos ingresados correctamente");
                }
            }
            catch (Exception)
            {
                
                throw;
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
