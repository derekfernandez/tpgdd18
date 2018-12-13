namespace PalcoNet.Abm_Empresa_Espectaculo
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
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grillaEmpresas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.Location = new System.Drawing.Point(12, 903);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(252, 133);
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.bntAltaEmpresa_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1265, 903);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(252, 133);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // labelTituloModEli
            // 
            this.labelTituloModEli.AutoSize = true;
            this.labelTituloModEli.Font = new System.Drawing.Font("Arial", 28.125F, System.Drawing.FontStyle.Bold);
            this.labelTituloModEli.Location = new System.Drawing.Point(229, 9);
            this.labelTituloModEli.Name = "labelTituloModEli";
            this.labelTituloModEli.Size = new System.Drawing.Size(1097, 88);
            this.labelTituloModEli.TabIndex = 2;
            this.labelTituloModEli.Text = "Modificar o Eliminar Empresa";
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(430, 903);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(252, 133);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(867, 903);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(252, 133);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // grillaEmpresas
            // 
            this.grillaEmpresas.AllowUserToOrderColumns = true;
            this.grillaEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaEmpresas.Location = new System.Drawing.Point(12, 234);
            this.grillaEmpresas.Name = "grillaEmpresas";
            this.grillaEmpresas.RowTemplate.Height = 33;
            this.grillaEmpresas.Size = new System.Drawing.Size(1505, 596);
            this.grillaEmpresas.TabIndex = 5;
            this.grillaEmpresas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaEmpresas_CellContentClick);
            // 
            // labelCUIT
            // 
            this.labelCUIT.AutoSize = true;
            this.labelCUIT.Location = new System.Drawing.Point(606, 172);
            this.labelCUIT.Name = "labelCUIT";
            this.labelCUIT.Size = new System.Drawing.Size(66, 25);
            this.labelCUIT.TabIndex = 6;
            this.labelCUIT.Text = "CUIT:";
            // 
            // labelRazonSocial
            // 
            this.labelRazonSocial.AutoSize = true;
            this.labelRazonSocial.Location = new System.Drawing.Point(7, 172);
            this.labelRazonSocial.Name = "labelRazonSocial";
            this.labelRazonSocial.Size = new System.Drawing.Size(145, 25);
            this.labelRazonSocial.TabIndex = 7;
            this.labelRazonSocial.Text = "Razon Social:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(1115, 172);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(71, 25);
            this.labelEmail.TabIndex = 8;
            this.labelEmail.Text = "Email:";
            // 
            // textBoxRazonSocial
            // 
            this.textBoxRazonSocial.Location = new System.Drawing.Point(158, 169);
            this.textBoxRazonSocial.Name = "textBoxRazonSocial";
            this.textBoxRazonSocial.Size = new System.Drawing.Size(325, 31);
            this.textBoxRazonSocial.TabIndex = 10;
            // 
            // textBoxCUIT
            // 
            this.textBoxCUIT.Location = new System.Drawing.Point(678, 169);
            this.textBoxCUIT.Name = "textBoxCUIT";
            this.textBoxCUIT.Size = new System.Drawing.Size(325, 31);
            this.textBoxCUIT.TabIndex = 12;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(1192, 169);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(325, 31);
            this.textBoxEmail.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(873, 37);
            this.label1.TabIndex = 14;
            this.label1.Text = "*Seleccionar buscar sin aplicar filtros traera todas las empresas existentes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 845);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(928, 37);
            this.label2.TabIndex = 15;
            this.label2.Text = "*Editar de a una fila a la vez. No se puede editar el id_usuario ni el id_empresa" +
    "";
            // 
            // AMB_Modificar_Eliminar
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnVolver;
            this.ClientSize = new System.Drawing.Size(1538, 1048);
            this.Controls.Add(this.label2);
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
            this.Name = "AMB_Modificar_Eliminar";
            this.Text = "Editar_ModificarABM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AMB_Modificar_Eliminar_FormClosed);
            this.Load += new System.EventHandler(this.AMB_Modificar_Eliminar_Load);
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
        private System.Windows.Forms.Label label2;

    }
}