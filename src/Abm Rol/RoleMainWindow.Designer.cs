namespace PalcoNet.Abm_Rol
{
    partial class RoleMainWindow
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.createTab = new System.Windows.Forms.TabPage();
            this.listBox_agregadas = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox_disponibles = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_roleName = new System.Windows.Forms.TextBox();
            this.modifyTab = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_modify = new System.Windows.Forms.DataGridView();
            this.deleteTab = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv_delete = new System.Windows.Forms.DataGridView();
            this.errorSeleccionNula = new System.Windows.Forms.Label();
            this.errorAdv_asignadas = new System.Windows.Forms.Label();
            this.errorAdv_disponibles = new System.Windows.Forms.Label();
            this.error_nocompleto = new System.Windows.Forms.Label();
            this.error_sololetras = new System.Windows.Forms.Label();
            this.errorAdv_nombre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPalcoNet)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.createTab.SuspendLayout();
            this.modifyTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_modify)).BeginInit();
            this.deleteTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_delete)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPalcoNet
            // 
            this.logoPalcoNet.Image = null;
            this.logoPalcoNet.Location = new System.Drawing.Point(521, 38);
            this.logoPalcoNet.Size = new System.Drawing.Size(11, 17);
            this.logoPalcoNet.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.createTab);
            this.tabControl1.Controls.Add(this.modifyTab);
            this.tabControl1.Controls.Add(this.deleteTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(381, 372);
            this.tabControl1.TabIndex = 1;
            // 
            // createTab
            // 
            this.createTab.Controls.Add(this.errorAdv_nombre);
            this.createTab.Controls.Add(this.error_sololetras);
            this.createTab.Controls.Add(this.error_nocompleto);
            this.createTab.Controls.Add(this.errorAdv_disponibles);
            this.createTab.Controls.Add(this.errorAdv_asignadas);
            this.createTab.Controls.Add(this.errorSeleccionNula);
            this.createTab.Controls.Add(this.listBox_agregadas);
            this.createTab.Controls.Add(this.button3);
            this.createTab.Controls.Add(this.label4);
            this.createTab.Controls.Add(this.button2);
            this.createTab.Controls.Add(this.button1);
            this.createTab.Controls.Add(this.label3);
            this.createTab.Controls.Add(this.listBox_disponibles);
            this.createTab.Controls.Add(this.label2);
            this.createTab.Controls.Add(this.label1);
            this.createTab.Controls.Add(this.textBox_roleName);
            this.createTab.Location = new System.Drawing.Point(4, 22);
            this.createTab.Name = "createTab";
            this.createTab.Padding = new System.Windows.Forms.Padding(3);
            this.createTab.Size = new System.Drawing.Size(373, 346);
            this.createTab.TabIndex = 0;
            this.createTab.Text = "Crear";
            this.createTab.UseVisualStyleBackColor = true;
            // 
            // listBox_agregadas
            // 
            this.listBox_agregadas.FormattingEnabled = true;
            this.listBox_agregadas.Location = new System.Drawing.Point(206, 136);
            this.listBox_agregadas.Name = "listBox_agregadas";
            this.listBox_agregadas.Size = new System.Drawing.Size(152, 121);
            this.listBox_agregadas.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(283, 305);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Guardar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Funcionalidades Asignadas";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(170, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = ">>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(170, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "<<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(16, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ingrese los datos del nuevo rol a agregar";
            // 
            // listBox_disponibles
            // 
            this.listBox_disponibles.FormattingEnabled = true;
            this.listBox_disponibles.Location = new System.Drawing.Point(15, 136);
            this.listBox_disponibles.Name = "listBox_disponibles";
            this.listBox_disponibles.Size = new System.Drawing.Size(149, 121);
            this.listBox_disponibles.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Funcionalidades Disponibles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // textBox_roleName
            // 
            this.textBox_roleName.Location = new System.Drawing.Point(69, 53);
            this.textBox_roleName.Name = "textBox_roleName";
            this.textBox_roleName.Size = new System.Drawing.Size(121, 20);
            this.textBox_roleName.TabIndex = 0;
            this.textBox_roleName.TextChanged += new System.EventHandler(this.textBox_roleName_TextChanged);
            // 
            // modifyTab
            // 
            this.modifyTab.Controls.Add(this.label5);
            this.modifyTab.Controls.Add(this.dgv_modify);
            this.modifyTab.Location = new System.Drawing.Point(4, 22);
            this.modifyTab.Name = "modifyTab";
            this.modifyTab.Padding = new System.Windows.Forms.Padding(3);
            this.modifyTab.Size = new System.Drawing.Size(373, 346);
            this.modifyTab.TabIndex = 1;
            this.modifyTab.Text = "Modificar";
            this.modifyTab.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(135, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Roles";
            // 
            // dgv_modify
            // 
            this.dgv_modify.AllowUserToAddRows = false;
            this.dgv_modify.AllowUserToDeleteRows = false;
            this.dgv_modify.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_modify.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_modify.Location = new System.Drawing.Point(3, 44);
            this.dgv_modify.Name = "dgv_modify";
            this.dgv_modify.ReadOnly = true;
            this.dgv_modify.Size = new System.Drawing.Size(366, 266);
            this.dgv_modify.TabIndex = 0;
            this.dgv_modify.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_modify_CellContentClick);
            // 
            // deleteTab
            // 
            this.deleteTab.Controls.Add(this.label6);
            this.deleteTab.Controls.Add(this.dgv_delete);
            this.deleteTab.Location = new System.Drawing.Point(4, 22);
            this.deleteTab.Name = "deleteTab";
            this.deleteTab.Size = new System.Drawing.Size(373, 346);
            this.deleteTab.TabIndex = 2;
            this.deleteTab.Text = "Eliminar";
            this.deleteTab.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(119, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Roles activos";
            // 
            // dgv_delete
            // 
            this.dgv_delete.AllowUserToAddRows = false;
            this.dgv_delete.AllowUserToDeleteRows = false;
            this.dgv_delete.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_delete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_delete.Location = new System.Drawing.Point(3, 44);
            this.dgv_delete.Name = "dgv_delete";
            this.dgv_delete.ReadOnly = true;
            this.dgv_delete.Size = new System.Drawing.Size(366, 266);
            this.dgv_delete.TabIndex = 0;
            this.dgv_delete.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_delete_CellContentClick);
            // 
            // errorSeleccionNula
            // 
            this.errorSeleccionNula.AutoSize = true;
            this.errorSeleccionNula.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.errorSeleccionNula.ForeColor = System.Drawing.Color.Red;
            this.errorSeleccionNula.Location = new System.Drawing.Point(66, 273);
            this.errorSeleccionNula.Name = "errorSeleccionNula";
            this.errorSeleccionNula.Size = new System.Drawing.Size(234, 17);
            this.errorSeleccionNula.TabIndex = 12;
            this.errorSeleccionNula.Text = "Debe seleccionar una funcionalidad";
            this.errorSeleccionNula.Visible = false;
            // 
            // errorAdv_asignadas
            // 
            this.errorAdv_asignadas.AutoSize = true;
            this.errorAdv_asignadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.errorAdv_asignadas.ForeColor = System.Drawing.Color.Red;
            this.errorAdv_asignadas.Location = new System.Drawing.Point(345, 105);
            this.errorAdv_asignadas.Name = "errorAdv_asignadas";
            this.errorAdv_asignadas.Size = new System.Drawing.Size(15, 20);
            this.errorAdv_asignadas.TabIndex = 13;
            this.errorAdv_asignadas.Text = "*";
            this.errorAdv_asignadas.Visible = false;
            // 
            // errorAdv_disponibles
            // 
            this.errorAdv_disponibles.AutoSize = true;
            this.errorAdv_disponibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorAdv_disponibles.ForeColor = System.Drawing.Color.Red;
            this.errorAdv_disponibles.Location = new System.Drawing.Point(162, 105);
            this.errorAdv_disponibles.Name = "errorAdv_disponibles";
            this.errorAdv_disponibles.Size = new System.Drawing.Size(15, 20);
            this.errorAdv_disponibles.TabIndex = 14;
            this.errorAdv_disponibles.Text = "*";
            this.errorAdv_disponibles.Visible = false;
            // 
            // error_nocompleto
            // 
            this.error_nocompleto.AutoSize = true;
            this.error_nocompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.error_nocompleto.ForeColor = System.Drawing.Color.Red;
            this.error_nocompleto.Location = new System.Drawing.Point(16, 77);
            this.error_nocompleto.Name = "error_nocompleto";
            this.error_nocompleto.Size = new System.Drawing.Size(162, 15);
            this.error_nocompleto.TabIndex = 15;
            this.error_nocompleto.Text = "Debe completar este campo";
            this.error_nocompleto.Visible = false;
            // 
            // error_sololetras
            // 
            this.error_sololetras.AutoSize = true;
            this.error_sololetras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.error_sololetras.ForeColor = System.Drawing.Color.Red;
            this.error_sololetras.Location = new System.Drawing.Point(16, 76);
            this.error_sololetras.Name = "error_sololetras";
            this.error_sololetras.Size = new System.Drawing.Size(212, 15);
            this.error_sololetras.TabIndex = 16;
            this.error_sololetras.Text = "El nombre puede contener solo letras";
            this.error_sololetras.Visible = false;
            // 
            // errorAdv_nombre
            // 
            this.errorAdv_nombre.AutoSize = true;
            this.errorAdv_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.errorAdv_nombre.ForeColor = System.Drawing.Color.Red;
            this.errorAdv_nombre.Location = new System.Drawing.Point(197, 53);
            this.errorAdv_nombre.Name = "errorAdv_nombre";
            this.errorAdv_nombre.Size = new System.Drawing.Size(15, 20);
            this.errorAdv_nombre.TabIndex = 17;
            this.errorAdv_nombre.Text = "*";
            this.errorAdv_nombre.Visible = false;
            // 
            // RoleMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 405);
            this.Controls.Add(this.tabControl1);
            this.Name = "RoleMainWindow";
            this.Text = "Roles";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RoleMainWindow_FormClosed);
            this.Load += new System.EventHandler(this.RoleMainWindow_Load);
            this.Controls.SetChildIndex(this.logoPalcoNet, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logoPalcoNet)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.createTab.ResumeLayout(false);
            this.createTab.PerformLayout();
            this.modifyTab.ResumeLayout(false);
            this.modifyTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_modify)).EndInit();
            this.deleteTab.ResumeLayout(false);
            this.deleteTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_delete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage createTab;
        private System.Windows.Forms.TabPage modifyTab;
        private System.Windows.Forms.TabPage deleteTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_roleName;
        private System.Windows.Forms.ListBox listBox_agregadas;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox_disponibles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_modify;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_delete;
        private System.Windows.Forms.Label errorAdv_disponibles;
        private System.Windows.Forms.Label errorAdv_asignadas;
        private System.Windows.Forms.Label errorSeleccionNula;
        private System.Windows.Forms.Label errorAdv_nombre;
        private System.Windows.Forms.Label error_sololetras;
        private System.Windows.Forms.Label error_nocompleto;
    }
}