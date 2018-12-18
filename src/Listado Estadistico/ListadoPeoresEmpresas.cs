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

            this.anio = anio;
            //Al trimestre le sumo 1, el indice del ComboBox arranca en 0
            this.trimestre = trimestre + 1;

            //Seteo esta propiedad en false para que no pueda agregar filas y lleno la tabla segun corresponda
            dgvEmpresas.AllowUserToAddRows = false;
            llenarDGV();

        }

        private void llenarDGV()
        {
            
            //Query para ejecutar el SP; devuelve la tabla con los valores a cargar en la dgv
            String query = "DECLARE @anio INT = " + this.anio + ";" + "DECLARE @trimestre INT = " + this.trimestre + ";";
            query += "EXEC estadistica_empresasMenosVendedoras @anio, @trimestre";
            SqlCommand cmd = new SqlCommand(query, Database.getConnection());

            dgvEmpresas.DataSource = Database.getTable(cmd);
            dgvEmpresas.Columns[0].HeaderText = "Razon social";
            dgvEmpresas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvEmpresas.Columns[1].HeaderText = "Mes";
            dgvEmpresas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmpresas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEmpresas.Columns[2].HeaderText = "Año";
            dgvEmpresas.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmpresas.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEmpresas.Columns[3].HeaderText = "Visibilidad";
            dgvEmpresas.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvEmpresas.Columns[4].HeaderText = "Localidades no vendidas";
            dgvEmpresas.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmpresas.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
