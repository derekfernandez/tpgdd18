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

        
    }
}
