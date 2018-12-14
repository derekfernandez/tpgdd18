namespace PalcoNet
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuadmin = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_roles = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_clientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_empresas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuclientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuempresas = new System.Windows.Forms.ToolStripMenuItem();
            this.menucuenta = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_grados = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_comisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_stats = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_compras = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_historial = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_puntos = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_publicaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.submenu_generarpublicacion = new System.Windows.Forms.ToolStripMenuItem();
            this.submenu_editarpublicacion = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_datoscuenta = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_cerrarsesion = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuadmin,
            this.menuclientes,
            this.menuempresas,
            this.menucuenta});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(431, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuadmin
            // 
            this.menuadmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_roles,
            this.menu_clientes,
            this.menu_empresas,
            this.menu_grados,
            this.menu_comisiones,
            this.menu_stats});
            this.menuadmin.Name = "menuadmin";
            this.menuadmin.Size = new System.Drawing.Size(100, 20);
            this.menuadmin.Text = "Administración";
            // 
            // menu_roles
            // 
            this.menu_roles.Name = "menu_roles";
            this.menu_roles.Size = new System.Drawing.Size(208, 22);
            this.menu_roles.Text = "ABM Roles";
            this.menu_roles.Click += new System.EventHandler(this.menu_roles_Click);
            // 
            // menu_clientes
            // 
            this.menu_clientes.Name = "menu_clientes";
            this.menu_clientes.Size = new System.Drawing.Size(208, 22);
            this.menu_clientes.Text = "ABM Clientes";
            this.menu_clientes.Click += new System.EventHandler(this.menu_clientes_Click);
            // 
            // menu_empresas
            // 
            this.menu_empresas.Name = "menu_empresas";
            this.menu_empresas.Size = new System.Drawing.Size(208, 22);
            this.menu_empresas.Text = "ABM Empresas";
            this.menu_empresas.Click += new System.EventHandler(this.menu_empresas_Click);
            // 
            // menuclientes
            // 
            this.menuclientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_compras,
            this.menu_historial,
            this.menu_puntos});
            this.menuclientes.Name = "menuclientes";
            this.menuclientes.Size = new System.Drawing.Size(61, 20);
            this.menuclientes.Text = "Clientes";
            // 
            // menuempresas
            // 
            this.menuempresas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_publicaciones});
            this.menuempresas.Name = "menuempresas";
            this.menuempresas.Size = new System.Drawing.Size(69, 20);
            this.menuempresas.Text = "Empresas";
            // 
            // menucuenta
            // 
            this.menucuenta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_datoscuenta,
            this.menu_cerrarsesion});
            this.menucuenta.Name = "menucuenta";
            this.menucuenta.Size = new System.Drawing.Size(74, 20);
            this.menucuenta.Text = "Mi Cuenta";
            this.menucuenta.Click += new System.EventHandler(this.menucuenta_Click);
            // 
            // menu_grados
            // 
            this.menu_grados.Name = "menu_grados";
            this.menu_grados.Size = new System.Drawing.Size(208, 22);
            this.menu_grados.Text = "ABM Grados";
            this.menu_grados.Click += new System.EventHandler(this.menu_grados_Click);
            // 
            // menu_comisiones
            // 
            this.menu_comisiones.Name = "menu_comisiones";
            this.menu_comisiones.Size = new System.Drawing.Size(208, 22);
            this.menu_comisiones.Text = "Rendición de Comisiones";
            this.menu_comisiones.Click += new System.EventHandler(this.menu_comisiones_Click);
            // 
            // menu_stats
            // 
            this.menu_stats.Name = "menu_stats";
            this.menu_stats.Size = new System.Drawing.Size(208, 22);
            this.menu_stats.Text = "Estadísticas";
            this.menu_stats.Click += new System.EventHandler(this.menu_stats_Click);
            // 
            // menu_compras
            // 
            this.menu_compras.Name = "menu_compras";
            this.menu_compras.Size = new System.Drawing.Size(211, 22);
            this.menu_compras.Text = "Compra de ubicaciones";
            this.menu_compras.Click += new System.EventHandler(this.menu_compras_Click);
            // 
            // menu_historial
            // 
            this.menu_historial.Name = "menu_historial";
            this.menu_historial.Size = new System.Drawing.Size(211, 22);
            this.menu_historial.Text = "Historial de compras";
            this.menu_historial.Click += new System.EventHandler(this.menu_historial_Click);
            // 
            // menu_puntos
            // 
            this.menu_puntos.Name = "menu_puntos";
            this.menu_puntos.Size = new System.Drawing.Size(211, 22);
            this.menu_puntos.Text = "Administración de puntos";
            this.menu_puntos.Click += new System.EventHandler(this.menu_puntos_Click);
            // 
            // menu_publicaciones
            // 
            this.menu_publicaciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenu_generarpublicacion,
            this.submenu_editarpublicacion});
            this.menu_publicaciones.Name = "menu_publicaciones";
            this.menu_publicaciones.Size = new System.Drawing.Size(152, 22);
            this.menu_publicaciones.Text = "Publicaciones";
            // 
            // submenu_generarpublicacion
            // 
            this.submenu_generarpublicacion.Name = "submenu_generarpublicacion";
            this.submenu_generarpublicacion.Size = new System.Drawing.Size(180, 22);
            this.submenu_generarpublicacion.Text = "Generar Publicación";
            this.submenu_generarpublicacion.Click += new System.EventHandler(this.submenu_generarpublicacion_Click);
            // 
            // submenu_editarpublicacion
            // 
            this.submenu_editarpublicacion.Name = "submenu_editarpublicacion";
            this.submenu_editarpublicacion.Size = new System.Drawing.Size(180, 22);
            this.submenu_editarpublicacion.Text = "Editar Publicación";
            this.submenu_editarpublicacion.Click += new System.EventHandler(this.submenu_editarpublicacion_Click);
            // 
            // menu_datoscuenta
            // 
            this.menu_datoscuenta.Name = "menu_datoscuenta";
            this.menu_datoscuenta.Size = new System.Drawing.Size(152, 22);
            this.menu_datoscuenta.Text = "Mis datos";
            // 
            // menu_cerrarsesion
            // 
            this.menu_cerrarsesion.Name = "menu_cerrarsesion";
            this.menu_cerrarsesion.Size = new System.Drawing.Size(152, 22);
            this.menu_cerrarsesion.Text = "Cerrar sesión";
            this.menu_cerrarsesion.Click += new System.EventHandler(this.menu_cerrarsesion_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(431, 259);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 286);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuadmin;
        private System.Windows.Forms.ToolStripMenuItem menu_roles;
        private System.Windows.Forms.ToolStripMenuItem menu_clientes;
        private System.Windows.Forms.ToolStripMenuItem menu_empresas;
        private System.Windows.Forms.ToolStripMenuItem menuclientes;
        private System.Windows.Forms.ToolStripMenuItem menuempresas;
        private System.Windows.Forms.ToolStripMenuItem menucuenta;
        private System.Windows.Forms.ToolStripMenuItem menu_grados;
        private System.Windows.Forms.ToolStripMenuItem menu_comisiones;
        private System.Windows.Forms.ToolStripMenuItem menu_stats;
        private System.Windows.Forms.ToolStripMenuItem menu_compras;
        private System.Windows.Forms.ToolStripMenuItem menu_historial;
        private System.Windows.Forms.ToolStripMenuItem menu_puntos;
        private System.Windows.Forms.ToolStripMenuItem menu_publicaciones;
        private System.Windows.Forms.ToolStripMenuItem submenu_generarpublicacion;
        private System.Windows.Forms.ToolStripMenuItem submenu_editarpublicacion;
        private System.Windows.Forms.ToolStripMenuItem menu_datoscuenta;
        private System.Windows.Forms.ToolStripMenuItem menu_cerrarsesion;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}