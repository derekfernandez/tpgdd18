using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Generar_Publicacion;
using PalcoNet.Misc;

namespace PalcoNet.Abm_Grado
{
    public partial class Grado : Form
    {
        public Grado()
        {
            InitializeComponent();
            cargarLista();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            GenerarPublicacion nuevaPublicacion = new GenerarPublicacion();
            nuevaPublicacion.Show();
        }
        

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string queryUpdate = string.Format("exec agregarGrado o update directo");
        }

        public void cargarLista()
        {
            string query = "select id_grado from SQLITO.GRADOS";
            comboBoxGrado.DataSource = Database.ObtenerDataSet(query).Tables[0];

            comboBoxGrado.ValueMember = "id_grado";
            comboBoxGrado.DisplayMember = "id_grado";
            
        }

        private void comboBoxGrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Para cambiar:
           string query = string.Format("select * from SQLITO.GRADOS where id_grado= '{0}'", comboBoxGrado.SelectedValue);

            textBoxGrado.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["descripcion"].ToString();
            textBoxComision.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["comision"].ToString();
        
        }

        private void Grado_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       
    }
}
