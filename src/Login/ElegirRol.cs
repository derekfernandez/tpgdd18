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

namespace PalcoNet.Login
{
    public partial class ElegirRol : BaseWindow
    {

        Session session { get; set; }

        public ElegirRol(Session session)
        {
            InitializeComponent();
            this.session = session;
            this.Show();
        }

        private void ElegirRol_Load(object sender, EventArgs e)
        {
            this.AcceptButton = gobtn;
            fillSelect(roleSelect, session.roles);
        }

        private void ElegirRol_FormClosed(object sender, FormClosedEventArgs e)
        {
            new Login().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (roleSelect.SelectedIndex == -1 || roleSelect.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un rol", "Error", MessageBoxButtons.OK);
                return;
            }


            Rol rol = new Rol(roleSelect.SelectedItem.ToString());
            session.rol.id = Database.getIdRol(rol);
            session.rol.funcionalidades = Database.getFuncionalidadesDeRol(rol);

            if (Database.rolHabilitado(rol))
            {
                this.Hide();
                new MenuPrincipal(session).Show();
            }

            else
            {
                MessageBox.Show("El rol se encuentra temporalmente inhabilitado", "Error", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
