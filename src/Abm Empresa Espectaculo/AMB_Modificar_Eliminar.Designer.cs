﻿namespace PalcoNet.Abm_Empresa_Espectaculo
{
    partial class AMB_Modificar_Eliminar
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.labelTituloModEli = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.grillaEmpresas = new System.Windows.Forms.DataGridView();
            this.labelCUIT = new System.Windows.Forms.Label();
            this.labelRazonSocial = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxRazonSocial = new System.Windows.Forms.TextBox();
            this.textBoxCUIT = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grillaEmpresas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.Location = new System.Drawing.Point(13, 705);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(4);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(172, 59);
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.bntAltaEmpresa_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1159, 705);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(172, 59);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // labelTituloModEli
            // 
            this.labelTituloModEli.AutoSize = true;
            this.labelTituloModEli.Font = new System.Drawing.Font("Arial", 22.125F, System.Drawing.FontStyle.Bold);
            this.labelTituloModEli.Location = new System.Drawing.Point(253, 22);
            this.labelTituloModEli.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTituloModEli.Name = "labelTituloModEli";
            this.labelTituloModEli.Size = new System.Drawing.Size(889, 69);
            this.labelTituloModEli.TabIndex = 2;
            this.labelTituloModEli.Text = "Modificar o Eliminar Empresas";
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(295, 705);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(172, 59);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Modificar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(582, 705);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(172, 59);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // grillaEmpresas
            // 
            this.grillaEmpresas.AllowUserToOrderColumns = true;
            this.grillaEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaEmpresas.Location = new System.Drawing.Point(12, 222);
            this.grillaEmpresas.Margin = new System.Windows.Forms.Padding(4);
            this.grillaEmpresas.Name = "grillaEmpresas";
            this.grillaEmpresas.ReadOnly = true;
            this.grillaEmpresas.RowTemplate.Height = 33;
            this.grillaEmpresas.Size = new System.Drawing.Size(1319, 438);
            this.grillaEmpresas.TabIndex = 5;
            this.grillaEmpresas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaEmpresas_CellClick);
            // 
            // labelCUIT
            // 
            this.labelCUIT.AutoSize = true;
            this.labelCUIT.Location = new System.Drawing.Point(485, 171);
            this.labelCUIT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCUIT.Name = "labelCUIT";
            this.labelCUIT.Size = new System.Drawing.Size(66, 25);
            this.labelCUIT.TabIndex = 6;
            this.labelCUIT.Text = "CUIT:";
            // 
            // labelRazonSocial
            // 
            this.labelRazonSocial.AutoSize = true;
            this.labelRazonSocial.Location = new System.Drawing.Point(20, 172);
            this.labelRazonSocial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRazonSocial.Name = "labelRazonSocial";
            this.labelRazonSocial.Size = new System.Drawing.Size(145, 25);
            this.labelRazonSocial.TabIndex = 7;
            this.labelRazonSocial.Text = "Razon Social:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(895, 171);
            this.labelEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(58, 25);
            this.labelEmail.TabIndex = 8;
            this.labelEmail.Text = "Mail:";
            // 
            // textBoxRazonSocial
            // 
            this.textBoxRazonSocial.Location = new System.Drawing.Point(173, 170);
            this.textBoxRazonSocial.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRazonSocial.Name = "textBoxRazonSocial";
            this.textBoxRazonSocial.Size = new System.Drawing.Size(280, 31);
            this.textBoxRazonSocial.TabIndex = 10;
            // 
            // textBoxCUIT
            // 
            this.textBoxCUIT.Location = new System.Drawing.Point(557, 169);
            this.textBoxCUIT.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCUIT.Name = "textBoxCUIT";
            this.textBoxCUIT.Size = new System.Drawing.Size(324, 31);
            this.textBoxCUIT.TabIndex = 12;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(971, 169);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(324, 31);
            this.textBoxEmail.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(873, 37);
            this.label1.TabIndex = 14;
            this.label1.Text = "*Seleccionar buscar sin aplicar filtros traera todas las empresas existentes";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(876, 705);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(172, 59);
            this.btnLimpiar.TabIndex = 15;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // AMB_Modificar_Eliminar
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnVolver;
            this.ClientSize = new System.Drawing.Size(1369, 797);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxCUIT);
            this.Controls.Add(this.textBoxRazonSocial);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelRazonSocial);
            this.Controls.Add(this.labelCUIT);
            this.Controls.Add(this.grillaEmpresas);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.labelTituloModEli);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnVolver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1395, 868);
            this.MinimumSize = new System.Drawing.Size(1395, 868);
            this.Name = "AMB_Modificar_Eliminar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Editar_ModificarABM";
            ((System.ComponentModel.ISupportInitialize)(this.grillaEmpresas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnVolver;
        public System.Windows.Forms.Button btnBuscar;
        public System.Windows.Forms.Label labelTituloModEli;
        public System.Windows.Forms.Button btnEditar;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.DataGridView grillaEmpresas;
        public System.Windows.Forms.Label labelCUIT;
        public System.Windows.Forms.Label labelRazonSocial;
        public System.Windows.Forms.Label labelEmail;
        public System.Windows.Forms.TextBox textBoxRazonSocial;
        public System.Windows.Forms.TextBox textBoxCUIT;
        public System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnLimpiar;

    }
}