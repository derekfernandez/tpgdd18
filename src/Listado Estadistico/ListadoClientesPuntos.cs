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
    public partial class ListadoClientesPuntos : Form
    {

        private ErrorProvider errorProvider;
        private int anio;
        private int trimestre;

        //Este no se usa, la idea es que VentanaSeleccion lo instancie con ciertos parametros
        public ListadoClientesPuntos()
        {
            InitializeComponent();
        }

        public ListadoClientesPuntos(int anio, int trimestre)
        {
            InitializeComponent();

            errorProvider = new ErrorProvider();

            //Le seteo los atributos que me pasaron por parametro, VentanaSeleccion los definio
            this.anio = anio;
            //Al trimestre le sumo 1, el indice del ComboBox arranca en 0
            this.trimestre = trimestre + 1;

            String query = "DECLARE @anio INT = " + this.anio + ";" + "DECLARE @trimestre INT = " + this.trimestre + ";";
            query += "EXEC SQLITO.estadistica_clientesConMasPuntosVencidos @anio, @trimestre";
            SqlCommand cmd = Database.createQuery(query);

            dgvPuntos.DataSource = Database.getTable(cmd);
            dgvPuntos.Columns[0].HeaderText = "Nombre";
            dgvPuntos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPuntos.Columns[1].HeaderText = "Apellido";
            dgvPuntos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPuntos.Columns[2].HeaderText = "Puntos vencidos";
            dgvPuntos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPuntos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPuntos.AllowUserToAddRows = false;

            //No permito que el usuario ordene manualmente
            foreach (DataGridViewColumn col in dgvPuntos.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
