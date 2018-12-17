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

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class MostrarUsuarioAsignado : Form
    {
        public MostrarUsuarioAsignado()
        {
            InitializeComponent();
            CargarUsuario();
        }

        public void CargarUsuario()
        {
            string ultimo = "select top 1 * from SQLITO.Usuarios order by id_usuario desc";
            Database.ObtenerDataSet(ultimo);

            textBoxUser.Text = Database.ObtenerDataSet(ultimo).Tables[0].Rows[0]["username"].ToString();
            //textBoxPw.Text = Database.ObtenerDataSet(ultimo).Tables[0].Rows[0]["password"].ToString();
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Abm_Empresa_Espectaculo.ABM_Alta_Empresa nuevaAlta = new ABM_Alta_Empresa();
            nuevaAlta.Show();
        }

        private void textBoxPw_TextChanged(object sender, EventArgs e)
        {

        }

        private void MostrarUsuarioAsignado_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       
    }
}
