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
            this.trimestre = trimestre;

            String query = "DECLARE @anio INT = " + anio + ";" + "DECLARE @trimestre INT = " + trimestre + ";";
            query += "EXEC estadistica_clientesConMasPuntosVencidos @anio, @trimestre";
            SqlCommand cmd = Database.createQuery(query);

            dgvPuntos.DataSource = Database.getTable(cmd);
            dgvPuntos.Columns[0].HeaderText = "Nombre";
            dgvPuntos.Columns[1].HeaderText = "Apellido";
            dgvPuntos.Columns[2].HeaderText = "Puntos vencidos";

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
