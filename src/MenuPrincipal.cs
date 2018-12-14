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
    public partial class MenuPrincipal : Form
    {
        Session session { get; set; }

        #region Constructores

        public MenuPrincipal(Session session)
        {
            InitializeComponent();
            this.session = session;
            menucuenta.Visible = true;

            if (session.rol.descripcion.Equals("Administrativo"))
            {
                menuadmin.Visible = true;
                menuclientes.Visible = false;
                menuempresas.Visible = false;
            }

            if (session.rol.descripcion.Equals("Cliente"))
            {
                menuadmin.Visible = false;
                menuclientes.Visible = true;
                menuempresas.Visible = false;
            }

            if (session.rol.descripcion.Equals("Empresa"))
            {
                menuadmin.Visible = false;
                menuclientes.Visible = false;
                menuempresas.Visible = true;
            }

            if (session.rol.descripcion.Equals("Administrador General"))
            {
                menuadmin.Visible = true;
                menuclientes.Visible = true;
                menuempresas.Visible = true;
            }
        }
       
        // temporal para pruebas

        public MenuPrincipal() { }

        #endregion

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

            if (session.rol.funcionalidades.Contains("ABM Roles"))
            {
                menu_roles.Visible = true;
            }

            if (session.rol.funcionalidades.Contains("ABM Clientes"))
            {
                menu_clientes.Visible = true;
            }

            if (session.rol.funcionalidades.Contains("ABM Empresas"))
            {
                menu_empresas.Visible = true;
            }

            if (session.rol.funcionalidades.Contains("ABM Grados"))
            {
                menu_grados.Visible = true;
            }

            if (session.rol.funcionalidades.Contains("Generar Publicacion"))
            {   
                menu_publicaciones.Visible = true;
                submenu_generarpublicacion.Visible = true;
            }

            if (session.rol.funcionalidades.Contains("Editar Publicacion"))
            {
                menu_publicaciones.Visible = true;
                submenu_editarpublicacion.Visible = true;
            }

            if (session.rol.funcionalidades.Contains("Compras"))
            {
                menu_compras.Visible = true;
            }

            if (session.rol.funcionalidades.Contains("Historial de Compras"))
            {
                menu_historial.Visible = true;
            }

            if (session.rol.funcionalidades.Contains("Administracion de Puntos"))
            {
                menu_puntos.Visible = true;
            }

            if (session.rol.funcionalidades.Contains("Estadisticas"))
            {
                menu_stats.Visible = true;
            }

            if (session.rol.funcionalidades.Contains("Rendicion de Comisiones"))
            {
                menu_comisiones.Visible = true;
            }
        }

        private void menucuenta_Click(object sender, EventArgs e)
        {

        }

        private void menu_cerrarsesion_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Está seguro que desea salir?", "Cerrar sesión", MessageBoxButtons.YesNo);

            if (res == DialogResult.No)
            {
                return;
            }

            else
            {
                this.Hide();
                new Login.Login().Show();
            }
        }

        private void submenu_generarpublicacion_Click(object sender, EventArgs e)
        {

        }

        private void submenu_editarpublicacion_Click(object sender, EventArgs e)
        {

        }

        private void menu_compras_Click(object sender, EventArgs e)
        {

        }

        private void menu_historial_Click(object sender, EventArgs e)
        {

        }

        private void menu_puntos_Click(object sender, EventArgs e)
        {

        }

        private void menu_roles_Click(object sender, EventArgs e)
        {
            new Abm_Rol.RoleMainWindow(this.session).ShowDialog();
        }

        private void menu_clientes_Click(object sender, EventArgs e)
        {
            new Abm_Cliente.ClientesMainWindow(this.session).ShowDialog();
        }

        private void menu_empresas_Click(object sender, EventArgs e)
        {
            new Abm_Empresa_Espectaculo.ABM_Menu_Empresa(this.session).ShowDialog();
        }

        private void menu_grados_Click(object sender, EventArgs e)
        {

        }

        private void menu_comisiones_Click(object sender, EventArgs e)
        {

        }

        private void menu_stats_Click(object sender, EventArgs e)
        {

        }
    
    }
}
