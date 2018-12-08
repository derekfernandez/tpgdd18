using PalcoNet.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Listado_Estadistico
{
    public partial class ListadoPeoresEmpresas : Form
    {

        private ErrorProvider errorProvider;
        private int anio;
        private int trimestre;
        
        //Este no se usa, la idea es que VentanaSeleccion lo instancie con ciertos parametros
        public ListadoPeoresEmpresas()
        {
            InitializeComponent();
        }
        
        public ListadoPeoresEmpresas(int anio, int trimestre)
        {
            InitializeComponent();

            errorProvider = new ErrorProvider();

            this.anio = anio;
            this.trimestre = trimestre;

            String query = "SELECT id_grado, descripcion FROM SQLITO.Grados";
            SqlCommand cmd = new SqlCommand(query, Database.getConnection());

            comboGrado.DataSource = Database.getTable(cmd);
            comboGrado.DisplayMember = "descripcion";
            comboGrado.ValueMember = "id_grado";

            //Tiene que arrancar vacia, solo cuando aprete generar debe llenarse
            dgvEmpresas.DataSource = null;
            //Seteo esta propiedad en false para que no pueda agregar filas
            dgvEmpresas.AllowUserToAddRows = false;

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            
            //Por si no se hubiera seleccionado el grado de visibilidad
            if (comboGrado.SelectedIndex < 0)
            {
                errorProvider.SetError(comboGrado, "Debe elegir un grado");
                return;
            }

            errorProvider.Clear();

            //Query para ejecutar el SP; devuelve la tabla con los valores a cargar en la dgv
            String query = "DECLARE @anio INT = " + anio + ";" + "DECLARE @trimestre INT = " + trimestre + ";";
            query += ("DECLARE @grado INT = " + Convert.ToInt32(comboGrado.SelectedValue) + ";");
            query += "EXEC estadistica_empresasMenosVendedoras @anio, @trimestre, @grado";

            SqlCommand cmd = new SqlCommand(query, Database.getConnection());
            dgvEmpresas.DataSource = Database.getTable(cmd);
            dgvEmpresas.Columns[0].HeaderText = "Razon social";
            dgvEmpresas.Columns[1].HeaderText = "Localidades no vendidas";

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
