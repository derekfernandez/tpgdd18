namespace PalcoNet.Abm_Grado
{
    partial class AgregarGrado
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
            this.textBoxComision = new System.Windows.Forms.TextBox();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.errorProviderDescripcion = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderComision = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderComision)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxComision
            // 
            this.textBoxComision.Location = new System.Drawing.Point(216, 236);
            this.textBoxComision.Name = "textBoxComision";
            this.textBoxComision.Size = new System.Drawing.Size(300, 31);
            this.textBoxComision.TabIndex = 13;
            this.textBoxComision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxComision_KeyPress);
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(216, 179);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(300, 31);
            this.textBoxDescripcion.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 37);
            this.label2.TabIndex = 11;
            this.label2.Text = "Comisión:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 37);
            this.label1.TabIndex = 10;
            this.label1.Text = "Descripcion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(171, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 56);
            this.label3.TabIndex = 14;
            this.label3.Text = "Alta Grado ";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(36, 345);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(179, 63);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(354, 345);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(179, 63);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // errorProviderDescripcion
            // 
            this.errorProviderDescripcion.ContainerControl = this;
            // 
            // errorProviderComision
            // 
            this.errorProviderComision.ContainerControl = this;
            // 
            // AgregarGrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 443);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxComision);
            this.Controls.Add(this.textBoxDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AgregarGrado";
            this.Text = "AgregarGrado";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderComision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxComision;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ErrorProvider errorProviderDescripcion;
        private System.Windows.Forms.ErrorProvider errorProviderComision;
    }
}