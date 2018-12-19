namespace PalcoNet
{
    partial class Ayuda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ayuda));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbtn_cliente = new System.Windows.Forms.RadioButton();
            this.rdbtn_empresa = new System.Windows.Forms.RadioButton();
            this.btn_confirmar = new System.Windows.Forms.Button();
            this.userhelp = new System.Windows.Forms.Label();
            this.helpempresa = new System.Windows.Forms.Label();
            this.btn_volver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ayuda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bienvenido! Gracias por elegir PalcoNet";
            // 
            // rdbtn_cliente
            // 
            this.rdbtn_cliente.AutoSize = true;
            this.rdbtn_cliente.Location = new System.Drawing.Point(15, 86);
            this.rdbtn_cliente.Name = "rdbtn_cliente";
            this.rdbtn_cliente.Size = new System.Drawing.Size(92, 17);
            this.rdbtn_cliente.TabIndex = 2;
            this.rdbtn_cliente.TabStop = true;
            this.rdbtn_cliente.Text = "Soy un cliente";
            this.rdbtn_cliente.UseVisualStyleBackColor = true;
            // 
            // rdbtn_empresa
            // 
            this.rdbtn_empresa.AutoSize = true;
            this.rdbtn_empresa.Location = new System.Drawing.Point(113, 86);
            this.rdbtn_empresa.Name = "rdbtn_empresa";
            this.rdbtn_empresa.Size = new System.Drawing.Size(107, 17);
            this.rdbtn_empresa.TabIndex = 3;
            this.rdbtn_empresa.TabStop = true;
            this.rdbtn_empresa.Text = "Soy una empresa";
            this.rdbtn_empresa.UseVisualStyleBackColor = true;
            // 
            // btn_confirmar
            // 
            this.btn_confirmar.Location = new System.Drawing.Point(226, 86);
            this.btn_confirmar.Name = "btn_confirmar";
            this.btn_confirmar.Size = new System.Drawing.Size(75, 23);
            this.btn_confirmar.TabIndex = 4;
            this.btn_confirmar.Text = "Confirmar";
            this.btn_confirmar.UseVisualStyleBackColor = true;
            this.btn_confirmar.Click += new System.EventHandler(this.button1_Click);
            // 
            // userhelp
            // 
            this.userhelp.ForeColor = System.Drawing.Color.Purple;
            this.userhelp.Location = new System.Drawing.Point(15, 121);
            this.userhelp.Name = "userhelp";
            this.userhelp.Size = new System.Drawing.Size(286, 148);
            this.userhelp.TabIndex = 5;
            this.userhelp.Text = resources.GetString("userhelp.Text");
            this.userhelp.Visible = false;
            // 
            // helpempresa
            // 
            this.helpempresa.ForeColor = System.Drawing.Color.Purple;
            this.helpempresa.Location = new System.Drawing.Point(15, 121);
            this.helpempresa.Name = "helpempresa";
            this.helpempresa.Size = new System.Drawing.Size(286, 148);
            this.helpempresa.TabIndex = 6;
            this.helpempresa.Text = resources.GetString("helpempresa.Text");
            this.helpempresa.Visible = false;
            // 
            // btn_volver
            // 
            this.btn_volver.Location = new System.Drawing.Point(226, 264);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(75, 23);
            this.btn_volver.TabIndex = 7;
            this.btn_volver.Text = "Entendido";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.button2_Click);
            // 
            // Ayuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 299);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.helpempresa);
            this.Controls.Add(this.userhelp);
            this.Controls.Add(this.btn_confirmar);
            this.Controls.Add(this.rdbtn_empresa);
            this.Controls.Add(this.rdbtn_cliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Ayuda";
            this.Text = "Ayuda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbtn_cliente;
        private System.Windows.Forms.RadioButton rdbtn_empresa;
        private System.Windows.Forms.Button btn_confirmar;
        private System.Windows.Forms.Label userhelp;
        private System.Windows.Forms.Label helpempresa;
        private System.Windows.Forms.Button btn_volver;
    }
}