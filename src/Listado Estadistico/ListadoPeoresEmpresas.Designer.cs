namespace PalcoNet.Listado_Estadistico
{
    partial class ListadoPeoresEmpresas
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
            this.components = new System.ComponentModel.Container();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbGrado = new System.Windows.Forms.Label();
            this.comboGrado = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dgvEmpresas = new System.Windows.Forms.DataGridView();
            this.gD2C2018DataSet = new PalcoNet.GD2C2018DataSet();
            this.gD2C2018DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2018DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2018DataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(54, 18);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(312, 13);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "EMPRESAS CON MAS LOCALIDADES NO VENDIDAS";
            // 
            // lbGrado
            // 
            this.lbGrado.AutoSize = true;
            this.lbGrado.Location = new System.Drawing.Point(79, 53);
            this.lbGrado.Name = "lbGrado";
            this.lbGrado.Size = new System.Drawing.Size(36, 13);
            this.lbGrado.TabIndex = 1;
            this.lbGrado.Text = "Grado";
            // 
            // comboGrado
            // 
            this.comboGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGrado.FormattingEnabled = true;
            this.comboGrado.Location = new System.Drawing.Point(124, 50);
            this.comboGrado.Name = "comboGrado";
            this.comboGrado.Size = new System.Drawing.Size(86, 21);
            this.comboGrado.TabIndex = 2;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(243, 49);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(90, 23);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // dgvEmpresas
            // 
            this.dgvEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpresas.Location = new System.Drawing.Point(24, 91);
            this.dgvEmpresas.Name = "dgvEmpresas";
            this.dgvEmpresas.Size = new System.Drawing.Size(368, 160);
            this.dgvEmpresas.TabIndex = 4;
            // 
            // gD2C2018DataSet
            // 
            this.gD2C2018DataSet.DataSetName = "GD2C2018DataSet";
            this.gD2C2018DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gD2C2018DataSetBindingSource
            // 
            this.gD2C2018DataSetBindingSource.DataSource = this.gD2C2018DataSet;
            this.gD2C2018DataSetBindingSource.Position = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(169, 268);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(95, 23);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // ListadoPeoresEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 303);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvEmpresas);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.comboGrado);
            this.Controls.Add(this.lbGrado);
            this.Controls.Add(this.lbTitulo);
            this.Name = "ListadoPeoresEmpresas";
            this.Text = "Estadísticas - Peores Vendedoras";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2018DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2018DataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Label lbGrado;
        private System.Windows.Forms.ComboBox comboGrado;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridView dgvEmpresas;
        private GD2C2018DataSet gD2C2018DataSet;
        private System.Windows.Forms.BindingSource gD2C2018DataSetBindingSource;
        private System.Windows.Forms.Button btnVolver;
    }
}