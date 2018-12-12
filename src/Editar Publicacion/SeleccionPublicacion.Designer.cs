namespace PalcoNet.Editar_Publicacion
{
    partial class SeleccionPublicacion
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
            this.dgvEditables = new System.Windows.Forms.DataGridView();
            this.lbId = new System.Windows.Forms.Label();
            this.numId = new System.Windows.Forms.NumericUpDown();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numId)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(171, 9);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(310, 17);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "SELECCIONE LA PUBLICACIÓN A EDITAR";
            // 
            // dgvEditables
            // 
            this.dgvEditables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEditables.Location = new System.Drawing.Point(33, 44);
            this.dgvEditables.Name = "dgvEditables";
            this.dgvEditables.Size = new System.Drawing.Size(572, 287);
            this.dgvEditables.TabIndex = 1;
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(47, 355);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(129, 13);
            this.lbId.TabIndex = 2;
            this.lbId.Text = "ID de Publicación a editar";
            // 
            // numId
            // 
            this.numId.Location = new System.Drawing.Point(182, 352);
            this.numId.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numId.Name = "numId";
            this.numId.Size = new System.Drawing.Size(57, 20);
            this.numId.TabIndex = 3;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(263, 349);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(130, 23);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Red;
            this.btnVolver.Location = new System.Drawing.Point(481, 349);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(102, 23);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // SeleccionPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 391);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.numId);
            this.Controls.Add(this.lbId);
            this.Controls.Add(this.dgvEditables);
            this.Controls.Add(this.lbTitulo);
            this.Name = "SeleccionPublicacion";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.DataGridView dgvEditables;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.NumericUpDown numId;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnVolver;
    }
}