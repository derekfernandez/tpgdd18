namespace PalcoNet.Abm_Empresa_Espectaculo
{
    partial class ABM_Modificar_Empresa
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
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1082, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(415, 51);
            this.label4.TabIndex = 26;
            this.label4.Text = "ULTIMO FALTANTE";
            // 
            // ABM_Modificar_Empresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1509, 1033);
            this.Controls.Add(this.label4);
            this.Name = "ABM_Modificar_Empresa";
            this.Text = "ABM_Modificar_Empresa";
            this.Load += new System.EventHandler(this.ABM_Modificar_Empresa_Load);
            this.Controls.SetChildIndex(this.labelTelefono, 0);
            this.Controls.SetChildIndex(this.labelCUIT, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
    }
}