namespace PalcoNet.Abm_Empresa_Espectaculo
{
    partial class ModificacionEmpresas
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
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Size = new System.Drawing.Size(634, 33);
            this.label2.Text = "Ingrese los datos de la empresa a modificar:";
            // 
            // btnVolver
            // 
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(1078, 641);
            this.btnCargar.Text = "Modificar";
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(418, 30);
            this.label1.Size = new System.Drawing.Size(712, 88);
            this.label1.Text = "Modificar Empresa";
            // 
            // ModificacionEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 864);
            this.Name = "ModificacionEmpresas";
            this.Text = "ModificacionEmpresas";
       
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}