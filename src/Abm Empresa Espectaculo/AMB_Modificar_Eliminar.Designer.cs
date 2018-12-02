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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.labelTituloModEli = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(193, 646);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(252, 133);
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.bntAltaEmpresa_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(1087, 646);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(252, 133);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // labelTituloModEli
            // 
            this.labelTituloModEli.AutoSize = true;
            this.labelTituloModEli.Font = new System.Drawing.Font("Arial", 28.125F, System.Drawing.FontStyle.Bold);
            this.labelTituloModEli.Location = new System.Drawing.Point(242, 113);
            this.labelTituloModEli.Name = "labelTituloModEli";
            this.labelTituloModEli.Size = new System.Drawing.Size(1097, 88);
            this.labelTituloModEli.TabIndex = 2;
            this.labelTituloModEli.Text = "Modificar o Eliminar Empresa";
            // 
            // AMB_Modificar_Eliminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1521, 912);
            this.Controls.Add(this.labelTituloModEli);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnVolver);
            this.Name = "AMB_Modificar_Eliminar";
            this.Text = "Editar_ModificarABM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label labelTituloModEli;
    }
}