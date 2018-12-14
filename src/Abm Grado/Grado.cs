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
            //Pepe despues me tiene que pasar por parametro el cod de la publicacion
            InitializeComponent();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (textBoxBuscar.Text == "")
            {
                MessageBox.Show("Ingrese un valor para buscar");
            }
            else
            {
                try
                {
                    string buscar = string.Format("select * from SQLITO.Grados where id_grado = '{0}'", textBoxBuscar.Text);

                    textBoxDescripcion.Text = Database.ObtenerDataSet(buscar).Tables[0].Rows[0]["descripcion"].ToString();
                    textBoxComision.Text = Database.ObtenerDataSet(buscar).Tables[0].Rows[0]["comision"].ToString();

                    if (textBoxComision.Text.Contains(","))
                    {
                        textBoxComision.Text = textBoxComision.Text.Replace(",", ".");
                    }

                    if (Database.ObtenerDataSet(buscar).Tables[0].Rows[0]["habilitado"].ToString() == "True")
                    {
                        textBoxHabilitacion.Text = "1";
                    }
                    else
                    {
                        textBoxHabilitacion.Text = "0";
                    }


                }
                catch (Exception exp)
                {

                    MessageBox.Show("Error: " + exp.Message);
                }
            }

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string ingresar = string.Format("pr_Carga_Grado '{0}','{1}'", textBoxDescripcion.Text, textBoxComision.Text);
            try
            {
                if (algunNulo())
                {
                    MessageBox.Show("Error: Descripcion o Comision vacia");
                }
                else
                {
                    Database.ejecutarNonQueryShort(ingresar);
                    MessageBox.Show("Grado ingresado correctamente");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error: " + exp.Message);
            }

        }

        public Boolean algunNulo()
        {
            if (textBoxDescripcion.Text == "" || textBoxComision.Text == "")
                return true;
            return false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string eliminar = string.Format("update SQLITO.Grados set habilitado = 0 where id_grado = '{0}'", textBoxBuscar.Text);
            try
            {
                if (textBoxBuscar.Text == "")
                {
                    MessageBox.Show("Error: ingresar id de grado a inhabilitar");
                }
                else
                {
                    Database.ejecutarNonQueryShort(eliminar);
                    MessageBox.Show("Grado inhabilitado correctamente");
                    btnBuscar_Click(sender, e);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error: " + exp.Message);
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            string eliminar = string.Format("update SQLITO.Grados set habilitado = 1 where id_grado = '{0}'", textBoxBuscar.Text);
            try
            {
                if (textBoxBuscar.Text == "")
                {
                    MessageBox.Show("Error: ingresar id de grado a habilitar");
                }
                else
                {
                    Database.ejecutarNonQueryShort(eliminar);
                    MessageBox.Show("Grado habilitado correctamente");
                    btnBuscar_Click(sender, e);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error: " + exp.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string modificar = string.Format("update SQLITO.Grados set descripcion = '{0}',comision = '{1}' where id_grado = '{2}'", textBoxDescripcion.Text, textBoxComision.Text, textBoxBuscar.Text);
            try
            {
                if (textBoxBuscar.Text == "")
                {
                    MessageBox.Show("Error: ingresar id de grado a modificar");
                }
                else
                {
                    Database.ejecutarNonQueryShort(modificar);
                    MessageBox.Show("Grado modificado correctamente");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error: " + exp.Message);
            }
        }

        private void Grado_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            //Falta referencias al menu:
            this.Close();
        }
    }
}
