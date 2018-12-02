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
    }
}
