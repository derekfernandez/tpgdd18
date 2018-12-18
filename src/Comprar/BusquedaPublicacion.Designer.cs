namespace PalcoNet.Comprar
{
    partial class BusquedaPublicacion
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
            this.gbRubros = new System.Windows.Forms.GroupBox();
            this.cbOtros = new System.Windows.Forms.CheckBox();
            this.cbTeatro = new System.Windows.Forms.CheckBox();
            this.cbMusicales = new System.Windows.Forms.CheckBox();
            this.cbInfantiles = new System.Windows.Forms.CheckBox();
            this.cbDeportes = new System.Windows.Forms.CheckBox();
            this.cbConciertos = new System.Windows.Forms.CheckBox();
            this.cbCine = new System.Windows.Forms.CheckBox();
            this.gbRango = new System.Windows.Forms.GroupBox();
            this.lbHasta = new System.Windows.Forms.Label();
            this.lbDesde = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.lbNombre = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lbResultados = new System.Windows.Forms.Label();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.dgvPublicaciones = new System.Windows.Forms.DataGridView();
            this.btnUbicaciones = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.btnUltimaPag = new System.Windows.Forms.Button();
            this.btnPagSig = new System.Windows.Forms.Button();
            this.btnPagAnt = new System.Windows.Forms.Button();
            this.btnPrimeraPag = new System.Windows.Forms.Button();
            this.gbResultados = new System.Windows.Forms.GroupBox();
            this.lbPagina = new System.Windows.Forms.Label();
            this.btnLimpiarResultados = new System.Windows.Forms.Button();
            this.gbRubros.SuspendLayout();
            this.gbRango.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublicaciones)).BeginInit();
            this.gbResultados.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRubros
            // 
            this.gbRubros.Controls.Add(this.cbOtros);
            this.gbRubros.Controls.Add(this.cbTeatro);
            this.gbRubros.Controls.Add(this.cbMusicales);
            this.gbRubros.Controls.Add(this.cbInfantiles);
            this.gbRubros.Controls.Add(this.cbDeportes);
            this.gbRubros.Controls.Add(this.cbConciertos);
            this.gbRubros.Controls.Add(this.cbCine);
            this.gbRubros.Location = new System.Drawing.Point(20, 33);
            this.gbRubros.Name = "gbRubros";
            this.gbRubros.Size = new System.Drawing.Size(129, 179);
            this.gbRubros.TabIndex = 0;
            this.gbRubros.TabStop = false;
            this.gbRubros.Text = "Filtrar por Rubro";
            // 
            // cbOtros
            // 
            this.cbOtros.AutoSize = true;
            this.cbOtros.Location = new System.Drawing.Point(8, 157);
            this.cbOtros.Name = "cbOtros";
            this.cbOtros.Size = new System.Drawing.Size(51, 17);
            this.cbOtros.TabIndex = 6;
            this.cbOtros.Text = "Otros";
            this.cbOtros.UseVisualStyleBackColor = true;
            // 
            // cbTeatro
            // 
            this.cbTeatro.AutoSize = true;
            this.cbTeatro.Location = new System.Drawing.Point(8, 134);
            this.cbTeatro.Name = "cbTeatro";
            this.cbTeatro.Size = new System.Drawing.Size(57, 17);
            this.cbTeatro.TabIndex = 5;
            this.cbTeatro.Text = "Teatro";
            this.cbTeatro.UseVisualStyleBackColor = true;
            // 
            // cbMusicales
            // 
            this.cbMusicales.AutoSize = true;
            this.cbMusicales.Location = new System.Drawing.Point(8, 111);
            this.cbMusicales.Name = "cbMusicales";
            this.cbMusicales.Size = new System.Drawing.Size(73, 17);
            this.cbMusicales.TabIndex = 4;
            this.cbMusicales.Text = "Musicales";
            this.cbMusicales.UseVisualStyleBackColor = true;
            // 
            // cbInfantiles
            // 
            this.cbInfantiles.AutoSize = true;
            this.cbInfantiles.Location = new System.Drawing.Point(8, 88);
            this.cbInfantiles.Name = "cbInfantiles";
            this.cbInfantiles.Size = new System.Drawing.Size(68, 17);
            this.cbInfantiles.TabIndex = 3;
            this.cbInfantiles.Text = "Infantiles";
            this.cbInfantiles.UseVisualStyleBackColor = true;
            // 
            // cbDeportes
            // 
            this.cbDeportes.AutoSize = true;
            this.cbDeportes.Location = new System.Drawing.Point(8, 65);
            this.cbDeportes.Name = "cbDeportes";
            this.cbDeportes.Size = new System.Drawing.Size(69, 17);
            this.cbDeportes.TabIndex = 2;
            this.cbDeportes.Text = "Deportes";
            this.cbDeportes.UseVisualStyleBackColor = true;
            // 
            // cbConciertos
            // 
            this.cbConciertos.AutoSize = true;
            this.cbConciertos.Location = new System.Drawing.Point(8, 42);
            this.cbConciertos.Name = "cbConciertos";
            this.cbConciertos.Size = new System.Drawing.Size(76, 17);
            this.cbConciertos.TabIndex = 1;
            this.cbConciertos.Text = "Conciertos";
            this.cbConciertos.UseVisualStyleBackColor = true;
            // 
            // cbCine
            // 
            this.cbCine.AutoSize = true;
            this.cbCine.Location = new System.Drawing.Point(8, 19);
            this.cbCine.Name = "cbCine";
            this.cbCine.Size = new System.Drawing.Size(47, 17);
            this.cbCine.TabIndex = 0;
            this.cbCine.Text = "Cine";
            this.cbCine.UseVisualStyleBackColor = true;
            // 
            // gbRango
            // 
            this.gbRango.Controls.Add(this.lbHasta);
            this.gbRango.Controls.Add(this.lbDesde);
            this.gbRango.Controls.Add(this.dtpFinal);
            this.gbRango.Controls.Add(this.dtpInicial);
            this.gbRango.Location = new System.Drawing.Point(168, 39);
            this.gbRango.Name = "gbRango";
            this.gbRango.Size = new System.Drawing.Size(378, 173);
            this.gbRango.TabIndex = 1;
            this.gbRango.TabStop = false;
            this.gbRango.Text = "Rango Temporal";
            // 
            // lbHasta
            // 
            this.lbHasta.AutoSize = true;
            this.lbHasta.Location = new System.Drawing.Point(259, 25);
            this.lbHasta.Name = "lbHasta";
            this.lbHasta.Size = new System.Drawing.Size(35, 13);
            this.lbHasta.TabIndex = 3;
            this.lbHasta.Text = "Hasta";
            // 
            // lbDesde
            // 
            this.lbDesde.AutoSize = true;
            this.lbDesde.Location = new System.Drawing.Point(76, 25);
            this.lbDesde.Name = "lbDesde";
            this.lbDesde.Size = new System.Drawing.Size(38, 13);
            this.lbDesde.TabIndex = 2;
            this.lbDesde.Text = "Desde";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Location = new System.Drawing.Point(195, 43);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(170, 20);
            this.dtpFinal.TabIndex = 1;
            // 
            // dtpInicial
            // 
            this.dtpInicial.Location = new System.Drawing.Point(13, 44);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.Size = new System.Drawing.Size(166, 20);
            this.dtpInicial.TabIndex = 0;
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(17, 231);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(44, 13);
            this.lbNombre.TabIndex = 2;
            this.lbNombre.Text = "Nombre";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(76, 228);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(151, 20);
            this.tbNombre.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(398, 226);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(148, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar Publicaciones";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lbResultados
            // 
            this.lbResultados.AutoSize = true;
            this.lbResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResultados.Location = new System.Drawing.Point(219, 0);
            this.lbResultados.Name = "lbResultados";
            this.lbResultados.Size = new System.Drawing.Size(94, 13);
            this.lbResultados.TabIndex = 5;
            this.lbResultados.Text = "RESULTADOS:";
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(200, 9);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(196, 17);
            this.lbTitulo.TabIndex = 6;
            this.lbTitulo.Text = "BUSCAR PUBLICACIONES";
            // 
            // dgvPublicaciones
            // 
            this.dgvPublicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPublicaciones.Location = new System.Drawing.Point(13, 17);
            this.dgvPublicaciones.Name = "dgvPublicaciones";
            this.dgvPublicaciones.Size = new System.Drawing.Size(499, 248);
            this.dgvPublicaciones.TabIndex = 7;
            // 
            // btnUbicaciones
            // 
            this.btnUbicaciones.Location = new System.Drawing.Point(430, 596);
            this.btnUbicaciones.Name = "btnUbicaciones";
            this.btnUbicaciones.Size = new System.Drawing.Size(116, 23);
            this.btnUbicaciones.TabIndex = 11;
            this.btnUbicaciones.Text = "Ver Ubicaciones";
            this.btnUbicaciones.UseVisualStyleBackColor = true;
            this.btnUbicaciones.Click += new System.EventHandler(this.btnUbicaciones_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(20, 596);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(115, 23);
            this.btnVolver.TabIndex = 12;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(244, 226);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(148, 23);
            this.btnLimpiarFiltros.TabIndex = 13;
            this.btnLimpiarFiltros.Text = "Limpiar Filtros";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // btnUltimaPag
            // 
            this.btnUltimaPag.Location = new System.Drawing.Point(437, 272);
            this.btnUltimaPag.Name = "btnUltimaPag";
            this.btnUltimaPag.Size = new System.Drawing.Size(76, 39);
            this.btnUltimaPag.TabIndex = 14;
            this.btnUltimaPag.Text = "Última Página";
            this.btnUltimaPag.UseVisualStyleBackColor = true;
            this.btnUltimaPag.Click += new System.EventHandler(this.btnUltimaPag_Click);
            // 
            // btnPagSig
            // 
            this.btnPagSig.Location = new System.Drawing.Point(336, 272);
            this.btnPagSig.Name = "btnPagSig";
            this.btnPagSig.Size = new System.Drawing.Size(76, 39);
            this.btnPagSig.TabIndex = 15;
            this.btnPagSig.Text = "Página Siguiente";
            this.btnPagSig.UseVisualStyleBackColor = true;
            this.btnPagSig.Click += new System.EventHandler(this.btnPagSig_Click);
            // 
            // btnPagAnt
            // 
            this.btnPagAnt.Location = new System.Drawing.Point(114, 272);
            this.btnPagAnt.Name = "btnPagAnt";
            this.btnPagAnt.Size = new System.Drawing.Size(76, 39);
            this.btnPagAnt.TabIndex = 17;
            this.btnPagAnt.Text = "Página Anterior";
            this.btnPagAnt.UseVisualStyleBackColor = true;
            this.btnPagAnt.Click += new System.EventHandler(this.btnPagAnt_Click);
            // 
            // btnPrimeraPag
            // 
            this.btnPrimeraPag.Location = new System.Drawing.Point(13, 272);
            this.btnPrimeraPag.Name = "btnPrimeraPag";
            this.btnPrimeraPag.Size = new System.Drawing.Size(76, 39);
            this.btnPrimeraPag.TabIndex = 16;
            this.btnPrimeraPag.Text = "Primera Página";
            this.btnPrimeraPag.UseVisualStyleBackColor = true;
            this.btnPrimeraPag.Click += new System.EventHandler(this.btnPrimeraPag_Click);
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.lbPagina);
            this.gbResultados.Controls.Add(this.dgvPublicaciones);
            this.gbResultados.Controls.Add(this.btnPagSig);
            this.gbResultados.Controls.Add(this.btnPagAnt);
            this.gbResultados.Controls.Add(this.btnUltimaPag);
            this.gbResultados.Controls.Add(this.lbResultados);
            this.gbResultados.Controls.Add(this.btnPrimeraPag);
            this.gbResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbResultados.Location = new System.Drawing.Point(21, 268);
            this.gbResultados.Name = "gbResultados";
            this.gbResultados.Size = new System.Drawing.Size(525, 322);
            this.gbResultados.TabIndex = 18;
            this.gbResultados.TabStop = false;
            // 
            // lbPagina
            // 
            this.lbPagina.AutoSize = true;
            this.lbPagina.Location = new System.Drawing.Point(220, 285);
            this.lbPagina.Name = "lbPagina";
            this.lbPagina.Size = new System.Drawing.Size(35, 13);
            this.lbPagina.TabIndex = 18;
            this.lbPagina.Text = "label1";
            // 
            // btnLimpiarResultados
            // 
            this.btnLimpiarResultados.Location = new System.Drawing.Point(181, 596);
            this.btnLimpiarResultados.Name = "btnLimpiarResultados";
            this.btnLimpiarResultados.Size = new System.Drawing.Size(115, 23);
            this.btnLimpiarResultados.TabIndex = 19;
            this.btnLimpiarResultados.Text = "Limpiar Resultados";
            this.btnLimpiarResultados.UseVisualStyleBackColor = true;
            this.btnLimpiarResultados.Click += new System.EventHandler(this.btnLimpiarResultados_Click);
            // 
            // BusquedaPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 629);
            this.Controls.Add(this.btnLimpiarResultados);
            this.Controls.Add(this.gbResultados);
            this.Controls.Add(this.btnLimpiarFiltros);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnUbicaciones);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.gbRango);
            this.Controls.Add(this.gbRubros);
            this.Name = "BusquedaPublicacion";
            this.Text = "Comprar - Busqueda de Publicacion";
            this.gbRubros.ResumeLayout(false);
            this.gbRubros.PerformLayout();
            this.gbRango.ResumeLayout(false);
            this.gbRango.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPublicaciones)).EndInit();
            this.gbResultados.ResumeLayout(false);
            this.gbResultados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRubros;
        private System.Windows.Forms.CheckBox cbOtros;
        private System.Windows.Forms.CheckBox cbTeatro;
        private System.Windows.Forms.CheckBox cbMusicales;
        private System.Windows.Forms.CheckBox cbInfantiles;
        private System.Windows.Forms.CheckBox cbDeportes;
        private System.Windows.Forms.CheckBox cbConciertos;
        private System.Windows.Forms.CheckBox cbCine;
        private System.Windows.Forms.GroupBox gbRango;
        private System.Windows.Forms.Label lbHasta;
        private System.Windows.Forms.Label lbDesde;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.DateTimePicker dtpInicial;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lbResultados;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.DataGridView dgvPublicaciones;
        private System.Windows.Forms.Button btnUbicaciones;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnUltimaPag;
        private System.Windows.Forms.Button btnPagSig;
        private System.Windows.Forms.Button btnPagAnt;
        private System.Windows.Forms.Button btnPrimeraPag;
        private System.Windows.Forms.GroupBox gbResultados;
        private System.Windows.Forms.Label lbPagina;
        private System.Windows.Forms.Button btnLimpiarResultados;
    }
}