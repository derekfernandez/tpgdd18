using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Misc;
using PalcoNet.Controllers;
using System.Data.SqlClient;

namespace PalcoNet.Canje_Puntos
{
    public partial class canjePuntos : Form
    {
        public Session session { get; set; }
        DateTime fechaConfig;

        public canjePuntos(Session session)
        {
            this.session = session;
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            label2.Visible = false;
            fechaConfig = DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["FechaSistema"]);

        }
        public canjePuntos()
        {
            InitializeComponent();

        }
  
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void sumarPuntos()
        {
            SqlCommand query = Database.createQuery("SELECT TOP 1 SQLITO.sumarPuntos(@cliente,@fechaConfig) as Puntos FROM SQLITO.Puntos");
            query.Parameters.AddWithValue("@cliente", Database.getIdPorUsuario(session.user));
            query.Parameters.AddWithValue("@fechaConfig", fechaConfig);
            string puntos = Database.getValue(query);
            if(puntos == "")
            {
                label2.Visible = true;
            }
            label6.Text = puntos;
        }
        public void llenarPremios(DataGridView data)
        {
            SqlCommand query = Database.createQuery("SELECT descripcion as Premio, puntos_requeridos AS Puntos_Requeridos FROM SQLITO.Premios WHERE cantidad_stock <> 0 ORDER BY puntos_requeridos ASC");
            data.DataSource = Database.getTable(query);
            data.Columns[0].HeaderText = "Premio";
            data.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            data.Columns[1].HeaderText = "Puntos requeridos";
            data.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;



        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            sumarPuntos();
            llenarPremios(dataGridView1);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
            private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(label6.Text))
            {
                MessageBox.Show("Lo sentimos, no dispones de puntos para canjear en este momento", "", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (Int32.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString()) > Int32.Parse(label6.Text))
            {
                MessageBox.Show("No tiene los suficientes puntos para ese premio, intente con otro!", "Premio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Está seguro que desea canjear este premio?", "Premio", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if(result == DialogResult.OK)
                {
                    SqlCommand query = Database.createQuery("Insert Into SQLITO.Puntos (cantidad,cliente_id,fecha_vencimiento) Values(" + Int32.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString()) * (-1) + ",@cliente, NULL)");
                    SqlCommand query3 = Database.createQuery("SELECT cantidad_stock FROM SQLITO.Premios WHERE descripcion = @nombreDescripcion");
                    query3.Parameters.AddWithValue("@nombreDescripcion", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    string nombrePremio = Database.getValue(query3);
                    SqlCommand query2 = Database.createQuery("UPDATE SQLITO.Premios SET cantidad_stock = (SELECT cantidad_stock FROM SQLITO.Premios WHERE descripcion=@nombreDescripcion) - 1 WHERE descripcion=@nombreDescripcion");
                    query2.Parameters.AddWithValue("@nombreDescripcion", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    query.Parameters.AddWithValue("@cliente", Database.getIdPorUsuario(session.user));

                    //Update al usuario con sus nuevos puntos
                    SqlCommand puntosGastadosNuevos = Database.createQuery("UPDATE SQLITO.Clientes SET puntos_gastados = (puntos_gastados + @puntosCanjeados) WHERE id_cliente = @cliente");
                    puntosGastadosNuevos.Parameters.AddWithValue("@cliente", Database.getIdPorUsuario(session.user));
                    puntosGastadosNuevos.Parameters.AddWithValue("@puntosCanjeados", Int32.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString()));

                    Database.execNonQuery(puntosGastadosNuevos);
                    Database.execNonQuery(query);
                    Database.execNonQuery(query2);
                    sumarPuntos();
                    MessageBox.Show("Se canjeo el premio correctamente!", "Premio", MessageBoxButtons.OK);
                    llenarPremios(dataGridView1);
                }
                else
                {

                }

            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
