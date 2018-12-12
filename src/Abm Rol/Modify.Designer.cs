namespace PalcoNet.Abm_Rol
{
    partial class Modify
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox_actuales = new System.Windows.Forms.ListBox();
            this.listBox_disponibles = new System.Windows.Forms.ListBox();
            this.btn_habilitar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.errorAdv_nombre = new System.Windows.Forms.Label();
            this.error_sololetras = new System.Windows.Forms.Label();
            this.error_vacio = new System.Windows.Forms.Label();
            this.errorAdv_actuales = new System.Windows.Forms.Label();
            this.errorAdv_disponibles = new System.Windows.Forms.Label();
            this.error_nullselection = new System.Windows.Forms.Label();
            this.lbl_habilitado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPalcoNet)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPalcoNet
            // 
            this.logoPalcoNet.Enabled = false;
            this.logoPalcoNet.Image = null;
            this.logoPalcoNet.Location = new System.Drawing.Point(580, 12);
            this.logoPalcoNet.Size = new System.Drawing.Size(51, 50);
            this.logoPalcoNet.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rol a modificar:";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRol.ForeColor = System.Drawing.Color.Orange;
            this.lblRol.Location = new System.Drawing.Point(130, 27);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(0, 17);
            this.lblRol.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nuevo nombre";
            // 
            // listBox_actuales
            // 
            this.listBox_actuales.FormattingEnabled = true;
            this.listBox_actuales.Location = new System.Drawing.Point(12, 161);
            this.listBox_actuales.Name = "listBox_actuales";
            this.listBox_actuales.Size = new System.Drawing.Size(137, 95);
            this.listBox_actuales.TabIndex = 4;
            // 
            // listBox_disponibles
            // 
            this.listBox_disponibles.FormattingEnabled = true;
            this.listBox_disponibles.Location = new System.Drawing.Point(207, 161);
            this.listBox_disponibles.Name = "listBox_disponibles";
            this.listBox_disponibles.Size = new System.Drawing.Size(137, 95);
            this.listBox_disponibles.TabIndex = 5;
            // 
            // btn_habilitar
            // 
            this.btn_habilitar.Enabled = false;
            this.btn_habilitar.Location = new System.Drawing.Point(285, 24);
            this.btn_habilitar.Name = "btn_habilitar";
            this.btn_habilitar.Size = new System.Drawing.Size(75, 23);
            this.btn_habilitar.TabIndex = 6;
            this.btn_habilitar.Text = "Habilitar";
            this.btn_habilitar.UseVisualStyleBackColor = true;
            this.btn_habilitar.Click += new System.EventHandler(this.btn_habilitar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(270, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Modificar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 312);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Volver";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(155, 177);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(46, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = ">>";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(155, 216);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(46, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "<<";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Funcionalidades Actuales";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Funcionalidades Disponibles";
            // 
            // errorAdv_nombre
            // 
            this.errorAdv_nombre.AutoSize = true;
            this.errorAdv_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.errorAdv_nombre.ForeColor = System.Drawing.Color.Red;
            this.errorAdv_nombre.Location = new System.Drawing.Point(86, 69);
            this.errorAdv_nombre.Name = "errorAdv_nombre";
            this.errorAdv_nombre.Size = new System.Drawing.Size(15, 20);
            this.errorAdv_nombre.TabIndex = 13;
            this.errorAdv_nombre.Text = "*";
            this.errorAdv_nombre.Visible = false;
            // 
            // error_sololetras
            // 
            this.error_sololetras.AutoSize = true;
            this.error_sololetras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.error_sololetras.ForeColor = System.Drawing.Color.Red;
            this.error_sololetras.Location = new System.Drawing.Point(134, 94);
            this.error_sololetras.Name = "error_sololetras";
            this.error_sololetras.Size = new System.Drawing.Size(207, 15);
            this.error_sololetras.TabIndex = 14;
            this.error_sololetras.Text = "El campo solo puede contener letras";
            this.error_sololetras.Visible = false;
            // 
            // error_vacio
            // 
            this.error_vacio.AutoSize = true;
            this.error_vacio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.error_vacio.ForeColor = System.Drawing.Color.Red;
            this.error_vacio.Location = new System.Drawing.Point(134, 94);
            this.error_vacio.Name = "error_vacio";
            this.error_vacio.Size = new System.Drawing.Size(175, 15);
            this.error_vacio.TabIndex = 15;
            this.error_vacio.Text = "El campo no puede estar vacío";
            this.error_vacio.Visible = false;
            // 
            // errorAdv_actuales
            // 
            this.errorAdv_actuales.AutoSize = true;
            this.errorAdv_actuales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.errorAdv_actuales.ForeColor = System.Drawing.Color.Red;
            this.errorAdv_actuales.Location = new System.Drawing.Point(146, 134);
            this.errorAdv_actuales.Name = "errorAdv_actuales";
            this.errorAdv_actuales.Size = new System.Drawing.Size(15, 20);
            this.errorAdv_actuales.TabIndex = 16;
            this.errorAdv_actuales.Text = "*";
            this.errorAdv_actuales.Visible = false;
            // 
            // errorAdv_disponibles
            // 
            this.errorAdv_disponibles.AutoSize = true;
            this.errorAdv_disponibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.errorAdv_disponibles.ForeColor = System.Drawing.Color.Red;
            this.errorAdv_disponibles.Location = new System.Drawing.Point(345, 134);
            this.errorAdv_disponibles.Name = "errorAdv_disponibles";
            this.errorAdv_disponibles.Size = new System.Drawing.Size(15, 20);
            this.errorAdv_disponibles.TabIndex = 17;
            this.errorAdv_disponibles.Text = "*";
            this.errorAdv_disponibles.Visible = false;
            // 
            // error_nullselection
            // 
            this.error_nullselection.AutoSize = true;
            this.error_nullselection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.error_nullselection.ForeColor = System.Drawing.Color.Red;
            this.error_nullselection.Location = new System.Drawing.Point(51, 275);
            this.error_nullselection.Name = "error_nullselection";
            this.error_nullselection.Size = new System.Drawing.Size(258, 15);
            this.error_nullselection.TabIndex = 18;
            this.error_nullselection.Text = "Debe seleccionar al menos una funcionalidad";
            this.error_nullselection.Visible = false;
            // 
            // lbl_habilitado
            // 
            this.lbl_habilitado.AutoSize = true;
            this.lbl_habilitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbl_habilitado.ForeColor = System.Drawing.Color.Purple;
            this.lbl_habilitado.Location = new System.Drawing.Point(179, 50);
            this.lbl_habilitado.Name = "lbl_habilitado";
            this.lbl_habilitado.Size = new System.Drawing.Size(181, 15);
            this.lbl_habilitado.TabIndex = 19;
            this.lbl_habilitado.Text = "El rol ya se encuentra habilitado";
            this.lbl_habilitado.Visible = false;
            // 
            // Modify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 348);
            this.Controls.Add(this.lbl_habilitado);
            this.Controls.Add(this.error_nullselection);
            this.Controls.Add(this.errorAdv_disponibles);
            this.Controls.Add(this.errorAdv_actuales);
            this.Controls.Add(this.error_vacio);
            this.Controls.Add(this.error_sololetras);
            this.Controls.Add(this.errorAdv_nombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_habilitar);
            this.Controls.Add(this.listBox_disponibles);
            this.Controls.Add(this.listBox_actuales);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Modify";
            this.Text = "Modificar Rol";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Modify_FormClosed);
            this.Load += new System.EventHandler(this.Modify_Load);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.logoPalcoNet, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblRol, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.listBox_actuales, 0);
            this.Controls.SetChildIndex(this.listBox_disponibles, 0);
            this.Controls.SetChildIndex(this.btn_habilitar, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.button5, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.errorAdv_nombre, 0);
            this.Controls.SetChildIndex(this.error_sololetras, 0);
            this.Controls.SetChildIndex(this.error_vacio, 0);
            this.Controls.SetChildIndex(this.errorAdv_actuales, 0);
            this.Controls.SetChildIndex(this.errorAdv_disponibles, 0);
            this.Controls.SetChildIndex(this.error_nullselection, 0);
            this.Controls.SetChildIndex(this.lbl_habilitado, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logoPalcoNet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox_actuales;
        private System.Windows.Forms.ListBox listBox_disponibles;
        private System.Windows.Forms.Button btn_habilitar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label errorAdv_nombre;
        private System.Windows.Forms.Label error_sololetras;
        private System.Windows.Forms.Label error_vacio;
        private System.Windows.Forms.Label errorAdv_actuales;
        private System.Windows.Forms.Label errorAdv_disponibles;
        private System.Windows.Forms.Label error_nullselection;
        private System.Windows.Forms.Label lbl_habilitado;
    }
}