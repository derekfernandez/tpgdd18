namespace PalcoNet.Abm_Grado
{
    partial class Grado
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
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.gradosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gD2C2018DataSet = new PalcoNet.GD2C2018DataSet();
            this.gradosTableAdapter = new PalcoNet.GD2C2018DataSetTableAdapters.GradosTableAdapter();
            this.label5 = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.grillaGrados = new System.Windows.Forms.DataGridView();
            this.btnDeshabilitar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gradosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2018DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaGrados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModificar
            // 
            this.btnModificar.AutoSize = true;
            this.btnModificar.Location = new System.Drawing.Point(693, 325);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(176, 47);
            this.btnModificar.TabIndex = 17;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.Location = new System.Drawing.Point(693, 425);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(176, 47);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // gradosBindingSource
            // 
            this.gradosBindingSource.DataMember = "Grados";
            this.gradosBindingSource.DataSource = this.gD2C2018DataSet;
            // 
            // gD2C2018DataSet
            // 
            this.gD2C2018DataSet.DataSetName = "GD2C2018DataSet";
            this.gD2C2018DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gradosTableAdapter
            // 
            this.gradosTableAdapter.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(182, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(515, 56);
            this.label5.TabIndex = 12;
            this.label5.Text = "Grado de Publicacion";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(693, 120);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(176, 46);
            this.btnIngresar.TabIndex = 14;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // grillaGrados
            // 
            this.grillaGrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaGrados.Location = new System.Drawing.Point(12, 164);
            this.grillaGrados.Name = "grillaGrados";
            this.grillaGrados.ReadOnly = true;
            this.grillaGrados.RowTemplate.Height = 33;
            this.grillaGrados.Size = new System.Drawing.Size(359, 308);
            this.grillaGrados.TabIndex = 25;
            this.grillaGrados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaGrados_CellClick);
            // 
            // btnDeshabilitar
            // 
            this.btnDeshabilitar.AutoSize = true;
            this.btnDeshabilitar.Location = new System.Drawing.Point(693, 221);
            this.btnDeshabilitar.Name = "btnDeshabilitar";
            this.btnDeshabilitar.Size = new System.Drawing.Size(176, 46);
            this.btnDeshabilitar.TabIndex = 28;
            this.btnDeshabilitar.Text = "Deshabilitar";
            this.btnDeshabilitar.UseVisualStyleBackColor = true;
            this.btnDeshabilitar.Click += new System.EventHandler(this.btnDeshabilitar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(426, 24);
            this.label1.TabIndex = 29;
            this.label1.Text = "Seleccione la fila a modificar/deshabilitar:";
            // 
            // Grado
            // 
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnVolver;
            this.ClientSize = new System.Drawing.Size(895, 520);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeshabilitar);
            this.Controls.Add(this.grillaGrados);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnModificar);
            this.Font = new System.Drawing.Font("Arial", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Grado";
            this.Text = "Grado";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Grado_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.gradosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2018DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaGrados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnVolver;
        private GD2C2018DataSet gD2C2018DataSet;
        private System.Windows.Forms.BindingSource gradosBindingSource;
        private GD2C2018DataSetTableAdapters.GradosTableAdapter gradosTableAdapter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.DataGridView grillaGrados;
        private System.Windows.Forms.Button btnDeshabilitar;
        private System.Windows.Forms.Label label1;
    }
}