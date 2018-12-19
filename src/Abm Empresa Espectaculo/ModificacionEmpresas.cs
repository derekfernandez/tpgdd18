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

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class ModificacionEmpresas : ABM_Alta_Empresa
    {
        string idEmpresa;
       

        public ModificacionEmpresas(string idEmpresa)
        {
            InitializeComponent();
            this.idEmpresa = idEmpresa;
            cargarTextBox();
        }


        public override void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
               
        }

        //Falta CERRAR
        #region Modificar Empresa
        public override void btnCargar_Click(object sender, EventArgs e)
        {
            if (validarCamposVacios())
            {
                MessageBox.Show("Complete los campos correspondientes");
                controlarCamposNoVacios();
            }
            else
            {
                string cuitCompleto;
                string direccion;

                eliminarErrorProvider();

                cuitCompleto = textBoxCUITPrefijo.Text + "-" + textBoxCuitLargo.Text + "-" + textBoxCUITSufijo.Text;

                direccion = textBoxDireccion.Text + "," + textBoxNumeroPiso.Text + "," + textBoxDepartamento.Text + "," + textBoxLocalidad.Text + "," + textBoxCodigoPostal.Text + "," + textBoxCiudad.Text;

                string update = string.Format("pr_Modificar_Empresa '{0}','{1}','{2}','{3}','{4}','{5}'", textBoxRazonSocial.Text, cuitCompleto, textBoxMail.Text, direccion, textBoxTelefono.Text, idEmpresa);
                try
                {
                    Database.ejecutarNonQueryShort(update);
                    MessageBox.Show("Empresa actualizada correctamente");
                    this.Close();

                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error: " + exp.Message);
                    
                }
            }
         }
        #endregion

        #region cargarGrilla

        public void cargarTextBox() 
        {
            string query = string.Format("select * from SQLITO.Empresas where id_empresa = '{0}'", idEmpresa);

            string direcEntera = Database.ObtenerDataSet(query).Tables[0].Rows[0]["direccion"].ToString();
            string cuitEntero = Database.ObtenerDataSet(query).Tables[0].Rows[0]["cuit"].ToString();

            string[] cuit = cuitEntero.Split('-');
            string[] direc = direcEntera.Split(',');

            textBoxRazonSocial.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["razonsocial"].ToString();


            textBoxDireccion.Text = direc[0];
            textBoxNumeroPiso.Text = direc[1];
            textBoxDepartamento.Text = direc[2];
            textBoxLocalidad.Text = direc[3];
            textBoxCodigoPostal.Text = direc[4];
            textBoxCiudad.Text = direc[5];

            textBoxCuitLargo.Text = cuit[1];
            textBoxCUITPrefijo.Text = cuit[0];
            textBoxCUITSufijo.Text = cuit[2];
            
           

            textBoxMail.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["mail"].ToString();
            textBoxTelefono.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["telefono"].ToString();
            //textBoxCui.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["cuit"].ToString();
        }

        #endregion

        private void btnCargar_Click_1(object sender, EventArgs e)
        {

        }


      

       

      

      






    }
}
