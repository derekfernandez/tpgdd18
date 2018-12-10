namespace PalcoNet
{
    partial class BaseWindow
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseWindow));
            this.logoPalcoNet = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPalcoNet)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPalcoNet
            // 
            this.logoPalcoNet.Image = ((System.Drawing.Image)(resources.GetObject("logoPalcoNet.Image")));
            this.logoPalcoNet.Location = new System.Drawing.Point(69, 12);
            this.logoPalcoNet.Name = "logoPalcoNet";
            this.logoPalcoNet.Size = new System.Drawing.Size(144, 127);
            this.logoPalcoNet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPalcoNet.TabIndex = 0;
            this.logoPalcoNet.TabStop = false;
            // 
            // BaseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.logoPalcoNet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseWindow";
           ((System.ComponentModel.ISupportInitialize)(this.logoPalcoNet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPalcoNet;
    }
}

