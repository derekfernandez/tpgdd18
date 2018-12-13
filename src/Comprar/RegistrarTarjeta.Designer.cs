namespace PalcoNet.Comprar
{
    partial class RegistrarTarjeta
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
            this.tbNumero = new System.Windows.Forms.TextBox();
            this.tbTitular = new System.Windows.Forms.TextBox();
            this.tbBanco = new System.Windows.Forms.TextBox();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.lbNumero = new System.Windows.Forms.Label();
            this.lbGuiones = new System.Windows.Forms.Label();
            this.lbTitular = new System.Windows.Forms.Label();
            this.lbBanco = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(61, 9);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(228, 17);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "REGISTRAR NUEVA TARJETA";
            // 
            // tbNumero
            // 
            this.tbNumero.Location = new System.Drawing.Point(127, 45);
            this.tbNumero.Name = "tbNumero";
            this.tbNumero.Size = new System.Drawing.Size(205, 20);
            this.tbNumero.TabIndex = 1;
            // 
            // tbTitular
            // 
            this.tbTitular.Location = new System.Drawing.Point(127, 90);
            this.tbTitular.Name = "tbTitular";
            this.tbTitular.Size = new System.Drawing.Size(205, 20);
            this.tbTitular.TabIndex = 2;
            // 
            // tbBanco
            // 
            this.tbBanco.Location = new System.Drawing.Point(127, 127);
            this.tbBanco.Name = "tbBanco";
            this.tbBanco.Size = new System.Drawing.Size(205, 20);
            this.tbBanco.TabIndex = 3;
            // 
            // tbCodigo
            // 
            this.tbCodigo.Location = new System.Drawing.Point(127, 164);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(205, 20);
            this.tbCodigo.TabIndex = 4;
            // 
            // lbNumero
            // 
            this.lbNumero.AutoSize = true;
            this.lbNumero.Location = new System.Drawing.Point(18, 48);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(91, 13);
            this.lbNumero.TabIndex = 5;
            this.lbNumero.Text = "Número de tarjeta";
            // 
            // lbGuiones
            // 
            this.lbGuiones.AutoSize = true;
            this.lbGuiones.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGuiones.Location = new System.Drawing.Point(29, 63);
            this.lbGuiones.Name = "lbGuiones";
            this.lbGuiones.Size = new System.Drawing.Size(66, 13);
            this.lbGuiones.TabIndex = 6;
            this.lbGuiones.Text = "(sin guiones)";
            // 
            // lbTitular
            // 
            this.lbTitular.AutoSize = true;
            this.lbTitular.Location = new System.Drawing.Point(18, 93);
            this.lbTitular.Name = "lbTitular";
            this.lbTitular.Size = new System.Drawing.Size(89, 13);
            this.lbTitular.TabIndex = 7;
            this.lbTitular.Text = "Nombre del titular";
            // 
            // lbBanco
            // 
            this.lbBanco.AutoSize = true;
            this.lbBanco.Location = new System.Drawing.Point(18, 130);
            this.lbBanco.Name = "lbBanco";
            this.lbBanco.Size = new System.Drawing.Size(72, 13);
            this.lbBanco.TabIndex = 8;
            this.lbBanco.Text = "Banco Emisor";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Location = new System.Drawing.Point(18, 167);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(106, 13);
            this.lbCodigo.TabIndex = 9;
            this.lbCodigo.Text = "Código de Seguridad";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(64, 205);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 23);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(199, 205);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(90, 23);
            this.btnRegistrar.TabIndex = 11;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // RegistrarTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 245);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lbCodigo);
            this.Controls.Add(this.lbBanco);
            this.Controls.Add(this.lbTitular);
            this.Controls.Add(this.lbGuiones);
            this.Controls.Add(this.lbNumero);
            this.Controls.Add(this.tbCodigo);
            this.Controls.Add(this.tbBanco);
            this.Controls.Add(this.tbTitular);
            this.Controls.Add(this.tbNumero);
            this.Controls.Add(this.lbTitulo);
            this.Name = "RegistrarTarjeta";
            this.Text = "Comprar - Registrar Tarjeta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.TextBox tbNumero;
        private System.Windows.Forms.TextBox tbTitular;
        private System.Windows.Forms.TextBox tbBanco;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.Label lbNumero;
        private System.Windows.Forms.Label lbGuiones;
        private System.Windows.Forms.Label lbTitular;
        private System.Windows.Forms.Label lbBanco;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnRegistrar;
    }
}