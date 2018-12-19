using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Generar_Publicacion;
using PalcoNet.Misc;





namespace PalcoNet.Abm_Rubro
{
    public partial class Rubro : Form
    {
        public Session session { get; set; }
        public Rubro(Session sesion)
        {
            this.session = session;
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
