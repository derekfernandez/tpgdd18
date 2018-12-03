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
    /// <summary>
    /// Todavia falta: Ver el tema de la sesion y toda la parte de back
    /// </summary>
    public partial class ABM_Menu_Empresa : Form
    {
        public ABM_Menu_Empresa()
        {
            InitializeComponent();
        }

        private void btnNuevaEmpresa_Click(object sender, EventArgs e)
        {
            this.Hide();
            ABM_Alta_Empresa nuevaAlta = new ABM_Alta_Empresa();
            nuevaAlta.Show();
        }

        private void btnModEliminar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AMB_Modificar_Eliminar nuevoEditar = new AMB_Modificar_Eliminar();
            nuevoEditar.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaInicio inicio = new VentanaInicio();
            inicio.Show();
        }

        private void ABM_Menu_Empresa_Load(object sender, EventArgs e)
        {

        }
    }
}
