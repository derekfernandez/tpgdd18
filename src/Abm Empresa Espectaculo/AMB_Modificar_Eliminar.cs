using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PalcoNet.Controllers;
using PalcoNet.Misc;


namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class AMB_Modificar_Eliminar : Form
    {
        public AMB_Modificar_Eliminar()
        {
            InitializeComponent();
        }

        private void bntAltaEmpresa_Click(object sender, EventArgs e)
        {
            this.Hide();
            ABM_Menu_Empresa nuevoMenu = new ABM_Menu_Empresa();
            nuevoMenu.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                
                string query = string.Format("select * from SQLITO.Empresas where razonsocial='{0}' and cuit='{1}' and mail='{2}'", textBoxRazonSocial.Text, textBoxCUIT.Text, textBoxEmail.Text);
                grillaEmpresas.DataSource = Database.ObtenerDataSet(query).Tables[0];
            }
            catch (Exception exp) 
            {
                MessageBox.Show("Error: " + exp.Message);
            }
        }

    

      
    }
}
