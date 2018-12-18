namespace PalcoNet.Generar_Publicacion
{
    partial class VentanaPrincipal
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
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.btnUbicaciones = new System.Windows.Forms.Button();
            this.comboGrado = new System.Windows.Forms.ComboBox();
            this.lbGrado = new System.Windows.Forms.Label();
            this.comboRubro = new System.Windows.Forms.ComboBox();
            this.lbDirección = new System.Windows.Forms.Label();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.lbRubro = new System.Windows.Forms.Label();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.btnFechaEliminar = new System.Windows.Forms.Button();
            this.btnFechaAgregar = new System.Windows.Forms.Button();
            this.dgvFechasElegidas = new System.Windows.Forms.DataGridView();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnBorrador = new System.Windows.Forms.Button();
            this.btnPublicar = new System.Windows.Forms.Button();
            this.lbElegirFecha = new System.Windows.Forms.Label();
            this.gbFunciones = new System.Windows.Forms.GroupBox();
            this.dtpHorario = new System.Windows.Forms.DateTimePicker();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFechasElegidas)).BeginInit();
            this.gbFunciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(181, 9);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(166, 17);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "NUEVA PUBLICACION";
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.btnUbicaciones);
            this.gbDatos.Controls.Add(this.comboGrado);
            this.gbDatos.Controls.Add(this.lbGrado);
            this.gbDatos.Controls.Add(this.comboRubro);
            this.gbDatos.Controls.Add(this.lbDirección);
            this.gbDatos.Controls.Add(this.tbDireccion);
            this.gbDatos.Controls.Add(this.lbRubro);
            this.gbDatos.Controls.Add(this.tbDescripcion);
            this.gbDatos.Controls.Add(this.lbDescripcion);
            this.gbDatos.Location = new System.Drawing.Point(12, 42);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(504, 234);
            this.gbDatos.TabIndex = 4;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de la Publicacion";
            // 
            // btnUbicaciones
            // 
            this.btnUbicaciones.Location = new System.Drawing.Point(138, 181);
            this.btnUbicaciones.Name = "btnUbicaciones";
            this.btnUbicaciones.Size = new System.Drawing.Size(249, 36);
            this.btnUbicaciones.TabIndex = 5;
            this.btnUbicaciones.Text = "Seleccionar Ubicaciones";
            this.btnUbicaciones.UseVisualStyleBackColor = true;
            this.btnUbicaciones.Click += new System.EventHandler(this.btnUbicaciones_Click);
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
            // lbGrado
            // 
            this.lbGrado.AutoSize = true;
            this.lbGrado.Location = new System.Drawing.Point(26, 137);
            this.lbGrado.Name = "lbGrado";
            this.lbGrado.Size = new System.Drawing.Size(100, 13);
            this.lbGrado.TabIndex = 10;
            this.lbGrado.Text = "Grado de Visibilidad";
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
            // lbDirección
            // 
            this.lbDirección.AutoSize = true;
            this.lbDirección.Location = new System.Drawing.Point(26, 68);
            this.lbDirección.Name = "lbDirección";
            this.lbDirección.Size = new System.Drawing.Size(52, 13);
            this.lbDirección.TabIndex = 8;
            this.lbDirección.Text = "Dirección";
            // 
            // tbDireccion
            // 
            this.tbDireccion.Location = new System.Drawing.Point(172, 65);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(317, 20);
            this.tbDireccion.TabIndex = 7;
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
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(172, 31);
            this.tbDescripcion.Multiline = true;
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(317, 20);
            this.tbDescripcion.TabIndex = 5;
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
            // btnFechaEliminar
            // 
            this.btnFechaEliminar.Location = new System.Drawing.Point(118, 106);
            this.btnFechaEliminar.Name = "btnFechaEliminar";
            this.btnFechaEliminar.Size = new System.Drawing.Size(81, 52);
            this.btnFechaEliminar.TabIndex = 16;
            this.btnFechaEliminar.Text = "Eliminar Última Función";
            this.btnFechaEliminar.UseVisualStyleBackColor = true;
            this.btnFechaEliminar.Click += new System.EventHandler(this.btnFechaEliminar_Click);
            // 
            // btnFechaAgregar
            // 
            this.btnFechaAgregar.Location = new System.Drawing.Point(16, 106);
            this.btnFechaAgregar.Name = "btnFechaAgregar";
            this.btnFechaAgregar.Size = new System.Drawing.Size(80, 52);
            this.btnFechaAgregar.TabIndex = 15;
            this.btnFechaAgregar.Text = "Agregar Función";
            this.btnFechaAgregar.UseVisualStyleBackColor = true;
            this.btnFechaAgregar.Click += new System.EventHandler(this.btnFechaAgregar_Click);
            // 
            // dgvFechasElegidas
            // 
            this.dgvFechasElegidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFechasElegidas.Location = new System.Drawing.Point(233, 32);
            this.dgvFechasElegidas.Name = "dgvFechasElegidas";
            this.dgvFechasElegidas.Size = new System.Drawing.Size(257, 141);
            this.dgvFechasElegidas.TabIndex = 14;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(16, 67);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(97, 20);
            this.dtpFecha.TabIndex = 13;
            // 
            // btnBorrador
            // 
            this.btnBorrador.Location = new System.Drawing.Point(320, 486);
            this.btnBorrador.Name = "btnBorrador";
            this.btnBorrador.Size = new System.Drawing.Size(92, 39);
            this.btnBorrador.TabIndex = 5;
            this.btnBorrador.Text = "Guardar como Borrador";
            this.btnBorrador.UseVisualStyleBackColor = true;
            this.btnBorrador.Click += new System.EventHandler(this.btnBorrador_Click);
            // 
            // btnPublicar
            // 
            this.btnPublicar.BackColor = System.Drawing.Color.LimeGreen;
            this.btnPublicar.Location = new System.Drawing.Point(424, 486);
            this.btnPublicar.Name = "btnPublicar";
            this.btnPublicar.Size = new System.Drawing.Size(92, 39);
            this.btnPublicar.TabIndex = 6;
            this.btnPublicar.Text = "Publicar";
            this.btnPublicar.UseVisualStyleBackColor = false;
            this.btnPublicar.Click += new System.EventHandler(this.btnPublicar_Click);
            // 
            // lbElegirFecha
            // 
            this.lbElegirFecha.AutoSize = true;
            this.lbElegirFecha.Location = new System.Drawing.Point(47, 37);
            this.lbElegirFecha.Name = "lbElegirFecha";
            this.lbElegirFecha.Size = new System.Drawing.Size(123, 13);
            this.lbElegirFecha.TabIndex = 17;
            this.lbElegirFecha.Text = "Elija una fecha y horario:";
            // 
            // gbFunciones
            // 
            this.gbFunciones.Controls.Add(this.dtpHorario);
            this.gbFunciones.Controls.Add(this.dgvFechasElegidas);
            this.gbFunciones.Controls.Add(this.lbElegirFecha);
            this.gbFunciones.Controls.Add(this.btnFechaEliminar);
            this.gbFunciones.Controls.Add(this.btnFechaAgregar);
            this.gbFunciones.Controls.Add(this.dtpFecha);
            this.gbFunciones.Location = new System.Drawing.Point(13, 283);
            this.gbFunciones.Name = "gbFunciones";
            this.gbFunciones.Size = new System.Drawing.Size(503, 191);
            this.gbFunciones.TabIndex = 18;
            this.gbFunciones.TabStop = false;
            this.gbFunciones.Text = "Funciones de la Publicación";
            // 
            // dtpHorario
            // 
            this.dtpHorario.Location = new System.Drawing.Point(125, 66);
            this.dtpHorario.Name = "dtpHorario";
            this.dtpHorario.Size = new System.Drawing.Size(74, 20);
            this.dtpHorario.TabIndex = 18;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(216, 486);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(92, 39);
            this.btnLimpiar.TabIndex = 19;
            this.btnLimpiar.Text = "Limpiar Formulario";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 486);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(92, 39);
            this.btnVolver.TabIndex = 20;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 553);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.gbFunciones);
            this.Controls.Add(this.btnPublicar);
            this.Controls.Add(this.btnBorrador);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.lbTitulo);
            this.Name = "VentanaPrincipal";
            this.Text = "Generar Publicación - Ventana Principal";
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFechasElegidas)).EndInit();
            this.gbFunciones.ResumeLayout(false);
            this.gbFunciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.ComboBox comboGrado;
        private System.Windows.Forms.Label lbGrado;
        private System.Windows.Forms.ComboBox comboRubro;
        private System.Windows.Forms.Label lbDirección;
        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.Label lbRubro;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.Button btnUbicaciones;
        private System.Windows.Forms.Button btnBorrador;
        private System.Windows.Forms.Button btnPublicar;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DataGridView dgvFechasElegidas;
        private System.Windows.Forms.Button btnFechaAgregar;
        private System.Windows.Forms.Button btnFechaEliminar;
        private System.Windows.Forms.Label lbElegirFecha;
        private System.Windows.Forms.GroupBox gbFunciones;
        private System.Windows.Forms.DateTimePicker dtpHorario;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnVolver;
    }
}