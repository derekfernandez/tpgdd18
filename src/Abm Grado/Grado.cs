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

      
        string idPublicacion;

        public Grado(string idPublicacion)
        {
            //Pepe despues me tiene que pasar por parametro el cod de la publicacion
            InitializeComponent();
            cargarLista();
            this.idPublicacion = idPublicacion;
        }
            

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            GenerarPublicacion nuevaPublicacion = new GenerarPublicacion();
            nuevaPublicacion.Show();
        }
        

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Query que se ejecutara para actualizar la publicacion.
            string queryUpdate = string.Format("update SQLITO.Publicaciones set grado_id = '{0}' where cod_publicacion = '{1}'", comboBoxGrado.SelectedValue.ToString(), idPublicacion);
            try
            {
                Database.ejecutarNonQueryShort(queryUpdate);
                MessageBox.Show("Grado de publicacion actualizado correctamente ");
            }
            catch (Exception exp)
            {
                
                MessageBox.Show("Error al ejecutar la query: " + exp.Message);
            }
        }

        public void cargarLista()
        {
            string query = "select id_grado from SQLITO.GRADOS";

            comboBoxGrado.ValueMember = "id_grado";
            comboBoxGrado.DisplayMember = "id_grado";
            
            


            comboBoxGrado.DataSource = (Database.ObtenerDataSet(query).Tables[0]);
            comboBoxGrado.SelectedIndex = 2; //Por defecto el mas caro
        }

        private void comboBoxGrado_SelectedIndexChanged(object sender, EventArgs e)
        {
   
           string query = string.Format("select * from SQLITO.GRADOS where id_grado= '{0}'", comboBoxGrado.SelectedValue.ToString());

           switch (Database.ObtenerDataSet(query).Tables[0].Rows[0]["descripcion"].ToString())
           {
               case "Alta":
                   textBoxGrado.Text = "Grado Alto de Exposicion";
                   break;
               case "Media":
                   textBoxGrado.Text = "Grado Medio de Exposicion";
                   break;
               case "Baja":
                   textBoxGrado.Text = "Grado Bajo de Exposicion";
                   break;
           }

           //textBoxGrado.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["descripcion"].ToString();
           textBoxComision.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["comision"].ToString() + " %";
        
        }

        private void Grado_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Grado_Load(object sender, EventArgs e)
        {

        }

       
    }
}
