﻿using System;
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
    public partial class Ayuda : Form
    {
        public Ayuda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rdbtn_cliente.Checked)
            {
                helpempresa.Visible = false;
                userhelp.Visible = true;
                return;
            }

            if (rdbtn_empresa.Checked)
            {
                userhelp.Visible = false;
                helpempresa.Visible = true;
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
