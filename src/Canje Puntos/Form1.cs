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
     
        public canjePuntos(Session session)
        {
            this.session = session;
            InitializeComponent();
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
            SqlCommand query = Database.createQuery("SELECT TOP 1 SQLITO.sumarPuntos(@cliente) as Puntos FROM SQLITO.Puntos");
            query.Parameters.AddWithValue("@cliente", Database.getIdPorUsuario(session.user));
            string puntos = Database.getValue(query);
            label6.Text = puntos;
        }
        public void llenarPremios(ComboBox cb)
        {
            SqlCommand query = Database.createQuery("SELECT descripcion as Premio, puntos_requeridos FROM SQLITO.Premios WHERE cantidad_stock <> 0 ORDER BY puntos_requeridos ASC");
            cb.DataSource = Database.getTable(query);
            cb.DisplayMember = "Premio";
            cb.ValueMember = "puntos_requeridos";

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            sumarPuntos();
            llenarPremios(comboBox1);
            string option = comboBox1.SelectedValue.ToString();
            label5.Text = option;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string option = comboBox1.SelectedValue.ToString();
            label5.Text = option;
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

            else if (Int32.Parse(label5.Text) > Int32.Parse(label6.Text))
            {
                MessageBox.Show("No tiene los suficientes puntos para ese premio, intente con otro!", "Premio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Está seguro que desea canjear este premio?", "Premio", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if(result == DialogResult.OK)
                {
                    SqlCommand query = Database.createQuery("Insert Into SQLITO.Puntos (cantidad,cliente_id,fecha_vencimiento) Values(" + Int32.Parse(label5.Text) * (-1) + ",@cliente, NULL)");
                    SqlCommand query3 = Database.createQuery("SELECT cantidad_stock FROM SQLITO.Premios WHERE descripcion = @nombreDescripcion");
                    query3.Parameters.AddWithValue("@nombreDescripcion", comboBox1.Text);
                    string nombrePremio = Database.getValue(query3);
                    SqlCommand query2 = Database.createQuery("UPDATE SQLITO.Premios SET cantidad_stock = (SELECT cantidad_stock FROM SQLITO.Premios WHERE descripcion=@nombreDescripcion) - 1 WHERE descripcion=@nombreDescripcion");
                    query2.Parameters.AddWithValue("@nombreDescripcion", comboBox1.Text);
                    query.Parameters.AddWithValue("@cliente", Database.getIdPorUsuario(session.user));
                    Database.execNonQuery(query);
                    Database.execNonQuery(query2);
                    sumarPuntos();
                    MessageBox.Show("Se canjeo el premio correctamente!", "Premio", MessageBoxButtons.OK);
                    llenarPremios(comboBox1);
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
    }
}
