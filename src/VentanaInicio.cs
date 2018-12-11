using PalcoNet.Abm_Empresa_Espectaculo;
using PalcoNet.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class VentanaInicio : Form
    {
        public VentanaInicio()
        {
            InitializeComponent();
        }

        private void InicioPrueba_Load(object sender, EventArgs e)
        {

        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            this.Hide();
            ABM_Menu_Empresa menu = new ABM_Menu_Empresa();
            menu.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.Login nuevoLogin = new Login.Login();
            nuevoLogin.Show();
        }

        private void btnGrado_Click(object sender, EventArgs e)
        {
            this.Hide();
            Abm_Grado.Grado grado = new Abm_Grado.Grado();
            grado.Show();
        }
    }
}
