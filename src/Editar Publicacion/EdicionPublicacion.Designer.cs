namespace PalcoNet.Editar_Publicacion
{
    partial class EdicionPublicacion
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
            this.btnPublicar = new System.Windows.Forms.Button();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.lbRubro = new System.Windows.Forms.Label();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.lbDirección = new System.Windows.Forms.Label();
            this.comboRubro = new System.Windows.Forms.ComboBox();
            this.lbGrado = new System.Windows.Forms.Label();
            this.comboGrado = new System.Windows.Forms.ComboBox();
            this.btnUbicaciones = new System.Windows.Forms.Button();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lbFechaHora = new System.Windows.Forms.Label();
            this.dtpHorario = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnDescartar = new System.Windows.Forms.Button();
            this.gbDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPublicar
            // 
            this.btnPublicar.BackColor = System.Drawing.Color.LimeGreen;
            this.btnPublicar.Location = new System.Drawing.Point(370, 328);
            this.btnPublicar.Name = "btnPublicar";
            this.btnPublicar.Size = new System.Drawing.Size(146, 23);
            this.btnPublicar.TabIndex = 22;
            this.btnPublicar.Text = "Publicar";
            this.btnPublicar.UseVisualStyleBackColor = false;
            this.btnPublicar.Click += new System.EventHandler(this.btnPublicar_Click);
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(181, 9);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(170, 17);
            this.lbTitulo.TabIndex = 25;
            this.lbTitulo.Text = "EDITAR PUBLICACION";
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.AutoSize = true;
            this.lbDescripcion.Location = new System.Drawing.Point(26, 34);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lbDescripcion.TabIndex = 4;
            this.lbDescripcion.Text = "Descripcion";
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(172, 31);
            this.tbDescripcion.Multiline = true;
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(317, 20);
            this.tbDescripcion.TabIndex = 5;
            // 
            // lbRubro
            // 
            this.lbRubro.AutoSize = true;
            this.lbRubro.Location = new System.Drawing.Point(26, 102);
            this.lbRubro.Name = "lbRubro";
            this.lbRubro.Size = new System.Drawing.Size(36, 13);
            this.lbRubro.TabIndex = 6;
            this.lbRubro.Text = "Rubro";
            // 
            // tbDireccion
            // 
            this.tbDireccion.Location = new System.Drawing.Point(172, 65);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(317, 20);
            this.tbDireccion.TabIndex = 7;
            // 
            // lbDirección
            // 
            this.lbDirección.AutoSize = true;
            this.lbDirección.Location = new System.Drawing.Point(26, 68);
            this.lbDirección.Name = "lbDirección";
            this.lbDirección.Size = new System.Drawing.Size(52, 13);
            this.lbDirección.TabIndex = 8;
            this.lbDirección.Text = "Dirección";
            // 
            // comboRubro
            // 
            this.comboRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRubro.FormattingEnabled = true;
            this.comboRubro.Location = new System.Drawing.Point(172, 99);
            this.comboRubro.Name = "comboRubro";
            this.comboRubro.Size = new System.Drawing.Size(317, 21);
            this.comboRubro.TabIndex = 9;
            // 
            // lbGrado
            // 
            this.lbGrado.AutoSize = true;
            this.lbGrado.Location = new System.Drawing.Point(26, 137);
            this.lbGrado.Name = "lbGrado";
            this.lbGrado.Size = new System.Drawing.Size(100, 13);
            this.lbGrado.TabIndex = 10;
            this.lbGrado.Text = "Grado de Visibilidad";
            // 
            // comboGrado
            // 
            this.comboGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGrado.FormattingEnabled = true;
            this.comboGrado.Location = new System.Drawing.Point(172, 134);
            this.comboGrado.Name = "comboGrado";
            this.comboGrado.Size = new System.Drawing.Size(317, 21);
            this.comboGrado.TabIndex = 11;
            // 
            // btnUbicaciones
            // 
            this.btnUbicaciones.Location = new System.Drawing.Point(134, 214);
            this.btnUbicaciones.Name = "btnUbicaciones";
            this.btnUbicaciones.Size = new System.Drawing.Size(249, 36);
            this.btnUbicaciones.TabIndex = 5;
            this.btnUbicaciones.Text = "Seleccionar Ubicaciones";
            this.btnUbicaciones.UseVisualStyleBackColor = true;
            this.btnUbicaciones.Click += new System.EventHandler(this.btnUbicaciones_Click);
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lbFechaHora);
            this.gbDatos.Controls.Add(this.dtpHorario);
            this.gbDatos.Controls.Add(this.dtpFecha);
            this.gbDatos.Controls.Add(this.btnUbicaciones);
            this.gbDatos.Controls.Add(this.comboGrado);
            this.gbDatos.Controls.Add(this.lbGrado);
            this.gbDatos.Controls.Add(this.comboRubro);
            this.gbDatos.Controls.Add(this.lbDirección);
            this.gbDatos.Controls.Add(this.tbDireccion);
            this.gbDatos.Controls.Add(this.lbRubro);
            this.gbDatos.Controls.Add(this.tbDescripcion);
            this.gbDatos.Controls.Add(this.lbDescripcion);
            this.gbDatos.Location = new System.Drawing.Point(12, 35);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(504, 272);
            this.gbDatos.TabIndex = 20;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de la Publicacion";
            // 
            // lbFechaHora
            // 
            this.lbFechaHora.AutoSize = true;
            this.lbFechaHora.Location = new System.Drawing.Point(26, 177);
            this.lbFechaHora.Name = "lbFechaHora";
            this.lbFechaHora.Size = new System.Drawing.Size(82, 13);
            this.lbFechaHora.TabIndex = 21;
            this.lbFechaHora.Text = "Fecha y Horario";
            // 
            // dtpHorario
            // 
            this.dtpHorario.Location = new System.Drawing.Point(377, 175);
            this.dtpHorario.Name = "dtpHorario";
            this.dtpHorario.Size = new System.Drawing.Size(112, 20);
            this.dtpHorario.TabIndex = 20;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(172, 175);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(190, 20);
            this.dtpFecha.TabIndex = 19;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Gold;
            this.btnActualizar.Location = new System.Drawing.Point(191, 328);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(137, 23);
            this.btnActualizar.TabIndex = 26;
            this.btnActualizar.Text = "Actualizar Borrador";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnDescartar
            // 
            this.btnDescartar.Location = new System.Drawing.Point(13, 328);
            this.btnDescartar.Name = "btnDescartar";
            this.btnDescartar.Size = new System.Drawing.Size(137, 23);
            this.btnDescartar.TabIndex = 24;
            this.btnDescartar.Text = "Descartar Cambios";
            this.btnDescartar.UseVisualStyleBackColor = true;
            this.btnDescartar.Click += new System.EventHandler(this.btnDescartar_Click);
            // 
            // EdicionPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 373);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.btnDescartar);
            this.Controls.Add(this.btnPublicar);
            this.Controls.Add(this.gbDatos);
            this.Name = "EdicionPublicacion";
            this.Text = "Editar Publicacion - Edicion";
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPublicar;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Label lbRubro;
        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.Label lbDirección;
        private System.Windows.Forms.ComboBox comboRubro;
        private System.Windows.Forms.Label lbGrado;
        private System.Windows.Forms.ComboBox comboGrado;
        private System.Windows.Forms.Button btnUbicaciones;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lbFechaHora;
        private System.Windows.Forms.DateTimePicker dtpHorario;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnDescartar;

    }
}