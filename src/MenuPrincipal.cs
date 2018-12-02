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
using PalcoNet.Abm_Empresa_Espectaculo;

namespace PalcoNet
{
    public partial class MenuPrincipal : Form
    {
        Session session { get; set; }

        public MenuPrincipal(Session session)
        {
            InitializeComponent();
            this.session = session;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            this.Hide();
            ABM_Alta_Empresa empresa = new ABM_Alta_Empresa();
            empresa.Show();
        }
    }
}
