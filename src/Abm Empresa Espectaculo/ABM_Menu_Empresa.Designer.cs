namespace PalcoNet.Abm_Empresa_Espectaculo
{
    partial class ABM_Menu_Empresa
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
            this.btnNuevaEmpresa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModEliminar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNuevaEmpresa
            // 
            this.btnNuevaEmpresa.Location = new System.Drawing.Point(244, 588);
            this.btnNuevaEmpresa.Name = "btnNuevaEmpresa";
            this.btnNuevaEmpresa.Size = new System.Drawing.Size(293, 160);
            this.btnNuevaEmpresa.TabIndex = 0;
            this.btnNuevaEmpresa.Text = "Nueva Empresa";
            this.btnNuevaEmpresa.UseVisualStyleBackColor = true;
            this.btnNuevaEmpresa.Click += new System.EventHandler(this.btnNuevaEmpresa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 28.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(151, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1235, 88);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bienvenido al Menu de Empresas";
            // 
            // btnModEliminar
            // 
            this.btnModEliminar.Location = new System.Drawing.Point(616, 588);
            this.btnModEliminar.Name = "btnModEliminar";
            this.btnModEliminar.Size = new System.Drawing.Size(293, 160);
            this.btnModEliminar.TabIndex = 2;
            this.btnModEliminar.Text = "Modificar o Eliminar Empresa";
            this.btnModEliminar.UseVisualStyleBackColor = true;
            this.btnModEliminar.Click += new System.EventHandler(this.btnModEliminar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.Location = new System.Drawing.Point(996, 588);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(293, 160);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // ABM_Menu_Empresa
            // 
            this.AcceptButton = this.btnNuevaEmpresa;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnVolver;
            this.ClientSize = new System.Drawing.Size(1589, 863);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnModEliminar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNuevaEmpresa);
            this.Name = "ABM_Menu_Empresa";
            this.Text = "MenuEmpresa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNuevaEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModEliminar;
        private System.Windows.Forms.Button btnVolver;
    }
}