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

namespace PalcoNet.Login
{
    public partial class ElegirRol : BaseWindow
    {

        Session session { get; set; }

        public ElegirRol(Session session)
        {
            InitializeComponent();
            this.session = session;
        }

        private void ElegirRol_Load(object sender, EventArgs e)
        {

        }
    }
}
