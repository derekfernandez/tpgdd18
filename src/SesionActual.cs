﻿using System;
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
    public partial class SesionActual : Form
    {
        public Session session { get; set; }

        public SesionActual(Session session)
        {
            this.session = session;
            InitializeComponent();
        }

        private void SesionActual_Load(object sender, EventArgs e)
        {
            lbl_rol.Text = session.rol.descripcion;
            lbl_username.Text = session.user.username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new CambioPassword(this.session).ShowDialog();
        }
    }
}
