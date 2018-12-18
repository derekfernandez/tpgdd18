namespace PalcoNet.Listado_Estadistico
{
    partial class VentanaSeleccion
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
            this.lbTitulo = new System.Windows.Forms.Label();
            this.gbPeriodo = new System.Windows.Forms.GroupBox();
            this.comboTrim = new System.Windows.Forms.ComboBox();
            this.lbTrimestre = new System.Windows.Forms.Label();
            this.dtpAño = new System.Windows.Forms.DateTimePicker();
            this.lbAño = new System.Windows.Forms.Label();
            this.btnPeoresEmpresas = new System.Windows.Forms.Button();
            this.btnClientesPuntos = new System.Windows.Forms.Button();
            this.btnMejoresCompradores = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.gbPeriodo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(50, 21);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(200, 17);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "LISTADOS ESTADISTICOS";
            // 
            // gbPeriodo
            // 
            this.gbPeriodo.Controls.Add(this.comboTrim);
            this.gbPeriodo.Controls.Add(this.lbTrimestre);
            this.gbPeriodo.Controls.Add(this.dtpAño);
            this.gbPeriodo.Controls.Add(this.lbAño);
            this.gbPeriodo.Location = new System.Drawing.Point(41, 64);
            this.gbPeriodo.Name = "gbPeriodo";
            this.gbPeriodo.Size = new System.Drawing.Size(215, 102);
            this.gbPeriodo.TabIndex = 1;
            this.gbPeriodo.TabStop = false;
            this.gbPeriodo.Text = "Periodo";
            // 
            // comboTrim
            // 
            this.comboTrim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTrim.FormattingEnabled = true;
            this.comboTrim.Items.AddRange(new object[] {
            "1 (Ene-Mar)",
            "2 (Abr-Jun)",
            "3 (Jul-Sep)",
            "4 (Oct-Dic)"});
            this.comboTrim.Location = new System.Drawing.Point(101, 60);
            this.comboTrim.Name = "comboTrim";
            this.comboTrim.Size = new System.Drawing.Size(94, 21);
            this.comboTrim.TabIndex = 3;
            // 
            // lbTrimestre
            // 
            this.lbTrimestre.AutoSize = true;
            this.lbTrimestre.Location = new System.Drawing.Point(22, 64);
            this.lbTrimestre.Name = "lbTrimestre";
            this.lbTrimestre.Size = new System.Drawing.Size(50, 13);
            this.lbTrimestre.TabIndex = 2;
            this.lbTrimestre.Text = "Trimestre";
            // 
            // dtpAño
            // 
            this.dtpAño.Location = new System.Drawing.Point(101, 29);
            this.dtpAño.Name = "dtpAño";
            this.dtpAño.Size = new System.Drawing.Size(94, 20);
            this.dtpAño.TabIndex = 1;
            // 
            // lbAño
            // 
            this.lbAño.AutoSize = true;
            this.lbAño.Location = new System.Drawing.Point(32, 32);
            this.lbAño.Name = "lbAño";
            this.lbAño.Size = new System.Drawing.Size(26, 13);
            this.lbAño.TabIndex = 0;
            this.lbAño.Text = "Año";
            // 
            // btnPeoresEmpresas
            // 
            this.btnPeoresEmpresas.Location = new System.Drawing.Point(41, 182);
            this.btnPeoresEmpresas.Name = "btnPeoresEmpresas";
            this.btnPeoresEmpresas.Size = new System.Drawing.Size(215, 23);
            this.btnPeoresEmpresas.TabIndex = 2;
            this.btnPeoresEmpresas.Text = "Empresas menos vendedoras";
            this.btnPeoresEmpresas.UseVisualStyleBackColor = true;
            this.btnPeoresEmpresas.Click += new System.EventHandler(this.btnPeoresEmpresas_Click);
            // 
            // btnClientesPuntos
            // 
            this.btnClientesPuntos.Location = new System.Drawing.Point(41, 221);
            this.btnClientesPuntos.Name = "btnClientesPuntos";
            this.btnClientesPuntos.Size = new System.Drawing.Size(215, 23);
            this.btnClientesPuntos.TabIndex = 3;
            this.btnClientesPuntos.Text = "Clientes con más puntos vencidos";
            this.btnClientesPuntos.UseVisualStyleBackColor = true;
            this.btnClientesPuntos.Click += new System.EventHandler(this.btnClientesPuntos_Click);
            // 
            // btnMejoresCompradores
            // 
            this.btnMejoresCompradores.Location = new System.Drawing.Point(41, 259);
            this.btnMejoresCompradores.Name = "btnMejoresCompradores";
            this.btnMejoresCompradores.Size = new System.Drawing.Size(215, 23);
            this.btnMejoresCompradores.TabIndex = 4;
            this.btnMejoresCompradores.Text = "Clientes con más compras";
            this.btnMejoresCompradores.UseVisualStyleBackColor = true;
            this.btnMejoresCompradores.Click += new System.EventHandler(this.btnMejoresCompradores_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(112, 296);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 43);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // VentanaSeleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 351);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnMejoresCompradores);
            this.Controls.Add(this.btnClientesPuntos);
            this.Controls.Add(this.btnPeoresEmpresas);
            this.Controls.Add(this.gbPeriodo);
            this.Controls.Add(this.lbTitulo);
            this.Name = "VentanaSeleccion";
            this.Text = "Estadísticas";
            this.gbPeriodo.ResumeLayout(false);
            this.gbPeriodo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.GroupBox gbPeriodo;
        private System.Windows.Forms.DateTimePicker dtpAño;
        private System.Windows.Forms.Label lbAño;
        private System.Windows.Forms.Label lbTrimestre;
        private System.Windows.Forms.Button btnPeoresEmpresas;
        private System.Windows.Forms.Button btnClientesPuntos;
        private System.Windows.Forms.Button btnMejoresCompradores;
        private System.Windows.Forms.ComboBox comboTrim;
        private System.Windows.Forms.Button btnVolver;
    }
}