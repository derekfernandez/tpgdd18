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
    public partial class Form1 : Form
    {

        public Form1()
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

        }
        public void llenarPremios(ComboBox cb)
        {
            SqlCommand query = Database.createQuery("SELECT descripcion as Premio FROM SQLITO.Premios");
            List<string> lista = new List<string> ();
            lista = Database.getList(query);
            foreach(String item in lista)
            {
                cb.Items.Add(item);
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            llenarPremios(comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
