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
            this.btnMod = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Size = new System.Drawing.Size(634, 33);
            this.label2.Text = "Ingrese los datos de la empresa a modificar:";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 12);
            this.btnVolver.Size = new System.Drawing.Size(119, 30);
            this.btnVolver.Visible = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(19, 48);
            this.btnCargar.Size = new System.Drawing.Size(112, 39);
            this.btnCargar.Text = "No se ve el cornudo";
            this.btnCargar.Visible = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(571, 641);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(418, 30);
            this.label1.Size = new System.Drawing.Size(712, 88);
            this.label1.Text = "Modificar Empresa";
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(991, 641);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(210, 125);
            this.btnMod.TabIndex = 26;
            this.btnMod.Text = "Modificar";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(127, 641);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(210, 125);
            this.btnBack.TabIndex = 27;
            this.btnBack.Text = "Volver";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ModificacionEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 864);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnMod);
            this.Name = "ModificacionEmpresas";
            this.Text = "ModificacionEmpresas";
            
            this.Controls.SetChildIndex(this.labelRazonSocial, 0);
            this.Controls.SetChildIndex(this.labelMail, 0);
            this.Controls.SetChildIndex(this.labelTelefono, 0);
            this.Controls.SetChildIndex(this.labelCUIT, 0);
            this.Controls.SetChildIndex(this.textBoxRazonSocial, 0);
            this.Controls.SetChildIndex(this.textBoxMail, 0);
            this.Controls.SetChildIndex(this.textBoxTelefono, 0);
            this.Controls.SetChildIndex(this.textBoxCuit, 0);
            this.Controls.SetChildIndex(this.textBoxDireccion, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnVolver, 0);
            this.Controls.SetChildIndex(this.btnCargar, 0);
            this.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnMod, 0);
            this.Controls.SetChildIndex(this.btnBack, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btnBack;
    }
}