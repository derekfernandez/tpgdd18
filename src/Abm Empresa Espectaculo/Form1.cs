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
    public partial class ABM_empresa_publicacion : Form
    {
        public ABM_empresa_publicacion()
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
            //Funcionalidad de ingresar datos en la tabla empresa y validar que sean correctos
            try
            {
                MessageBox.Show("Datos ingresados correctamente");
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
                MessageBox.Show("Volviendo...");
                this.Hide();
                Form1 nuevaForm1 = new Form1();
                nuevaForm1.Show();
            }
            catch (Exception)
            {

                throw;
            }

        }

      

       

     
    }
}
