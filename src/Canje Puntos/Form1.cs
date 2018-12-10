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
        public int cliente { get; set; }
     
        public canjePuntos(int clienteId)
        {
            this.cliente = clienteId;
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
            SqlCommand query = Database.createQuery("SELECT ISNULL(Sum(cantidad),0) From SQLITO.Puntos Where cliente_id = '" + this.cliente + "'");
           string puntos = Database.getValue(query);
            label6.Text = puntos;

        }
        public void llenarPremios(ComboBox cb)
        {
            SqlCommand query = Database.createQuery("SELECT descripcion as Premio, puntos_requeridos FROM SQLITO.Premios ORDER BY puntos_requeridos ASC");
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
            sumarPuntos();
            //revisar
           // SqlCommand query = Database.createQuery("Insert Into SQLITO.Premios (cantidad,cliente_id,fecha_vencimiento) Values("+Int32.Parse(label5.Text)+",this.cliente)";
        }
    }
}
