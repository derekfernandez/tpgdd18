namespace PalcoNet
{
    partial class VentanaInicio
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
            this.btnEmpresa = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnGrado = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEmpresa
            // 
            this.btnEmpresa.Location = new System.Drawing.Point(112, 589);
            this.btnEmpresa.Name = "btnEmpresa";
            this.btnEmpresa.Size = new System.Drawing.Size(210, 150);
            this.btnEmpresa.TabIndex = 0;
            this.btnEmpresa.Text = "Ir Menu Empresa";
            this.btnEmpresa.UseVisualStyleBackColor = true;
            this.btnEmpresa.Click += new System.EventHandler(this.btnEmpresa_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(422, 589);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(210, 150);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Ir Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnGrado
            // 
            this.btnGrado.Location = new System.Drawing.Point(698, 589);
            this.btnGrado.Name = "btnGrado";
            this.btnGrado.Size = new System.Drawing.Size(210, 150);
            this.btnGrado.TabIndex = 2;
            this.btnGrado.Text = "Ir Grado";
            this.btnGrado.UseVisualStyleBackColor = true;
            this.btnGrado.Click += new System.EventHandler(this.btnGrado_Click);
            // 
            // VentanaInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 846);
            this.Controls.Add(this.btnGrado);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnEmpresa);
            this.Name = "VentanaInicio";
            this.Text = "VentanaInicio";
            this.Load += new System.EventHandler(this.InicioPrueba_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmpresa;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnGrado;
    }
}