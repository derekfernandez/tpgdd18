using PalcoNet.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Listado_Estadistico
{
    public partial class ListadoMayoresCompradores : Form
    {

        #region Atributos

        int anio;
        int trimestre;

        #endregion Atributos

        #region Inicializacion

        public ListadoMayoresCompradores()
        {
            InitializeComponent();
        }

        public ListadoMayoresCompradores(int anio, int trimestre)
        {

            InitializeComponent();
           
            this.anio = anio;
            //Al trimestre le sumo 1, el indice del ComboBox arranca en 0
            this.trimestre = trimestre + 1;

            //Query para ejecutar el SP; devuelve la tabla con los valores a cargar en la DGV; uso this para usar atributos, no parametros
            String query = "DECLARE @anio INT = " + this.anio + "; DECLARE @trimestre INT  = " + this.trimestre + ";";
            query += "EXEC estadistica_clientesConMasCompras @anio, @trimestre";

            //Lleno la DGV con las empresas requeridas
            SqlCommand cmd = Database.createQuery(query);
            dgvClientes.DataSource = Database.getTable(cmd);
            dgvClientes.Columns[0].HeaderText = "Nombre";
            dgvClientes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvClientes.Columns[1].HeaderText = "Apellido";
            dgvClientes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvClientes.Columns[2].HeaderText = "Empresa";
            dgvClientes.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns[3].HeaderText = "Cantidad de Compras";
            dgvClientes.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvClientes.AllowUserToAddRows = false;

        }

        #endregion Inicializacion

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Eventos


        #endregion Eventos

    }
}
