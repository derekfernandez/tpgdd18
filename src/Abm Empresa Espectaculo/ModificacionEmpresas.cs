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
            AMB_Modificar_Eliminar nuevoMod = new AMB_Modificar_Eliminar();
            nuevoMod.Show();
            
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

                eliminarErrorProvider();

                string cuit = textBoxCUITPrefijo.Text + "-" + textBoxCuitLargo.Text + "-" + textBoxCUITSufijo.Text;

                string update = string.Format("pr_Modificar_Empresa '{0}','{1}','{2}','{3}','{4}','{5}'", textBoxRazonSocial.Text, cuit, textBoxMail.Text, textBoxDireccion.Text, textBoxTelefono.Text, idEmpresa);
                try
                {
                    Database.ejecutarNonQueryShort(update);
                    MessageBox.Show("Empresa actualizada correctamente");
                    this.Hide();
                    Abm_Empresa_Espectaculo.AMB_Modificar_Eliminar nuevoMod = new AMB_Modificar_Eliminar();
                    nuevoMod.cargarGrilla();
                    nuevoMod.Show();

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

            string cuitEntero = Database.ObtenerDataSet(query).Tables[0].Rows[0]["cuit"].ToString();

            string[] cuit = cuitEntero.Split('-');

            textBoxRazonSocial.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["razonsocial"].ToString();
            textBoxCuitLargo.Text = cuit[1];
            textBoxCUITPrefijo.Text = cuit[0];
            textBoxCUITSufijo.Text = cuit[2];
            textBoxMail.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["mail"].ToString();
            textBoxDireccion.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["direccion"].ToString();
            textBoxTelefono.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["telefono"].ToString();
            //textBoxCui.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["cuit"].ToString();
        }

        #endregion // ESTA OK

        #region validarCamposVacios
        public override bool validarCamposVacios()
        {
            bool vacios = false;

            if (string.IsNullOrWhiteSpace(textBoxRazonSocial.Text))
            {
                vacios = true;
                errorProviderRazonSocial.SetError(textBoxRazonSocial, "Ingrese una razon social");
            }



            //Validacion de longitudes
            #region longitudes cuit
            if (textBoxCuitLargo.Text.Length != 8)
            {
                vacios = true;
                errorProviderCUITLargo.SetError(textBoxCuitLargo, "Debe tener 8 numeros");

            }

            if (textBoxCUITPrefijo.Text.Length != 2)
            {
                vacios = true;
                errorProviderPrefijoCUIT.SetError(textBoxCUITPrefijo, "Debe tener 2 numeros");

            }

            if (textBoxCUITSufijo.Text.Length != 2)
            {
                vacios = true;
                errorProviderSufijoCUIT.SetError(textBoxCUITSufijo, "Debe tener 2 numeros");
            }
            #endregion

            if (string.IsNullOrWhiteSpace(textBoxMail.Text))
            {
                vacios = true;
                errorProviderMail.SetError(textBoxMail, "Ingrese un mail");
            }


            //Direccion
            if (string.IsNullOrWhiteSpace(textBoxDireccion.Text))
            {
                vacios = true;
                errorProviderDireccion.SetError(textBoxDireccion, "Ingrese una direccion");
            }
            

            if (string.IsNullOrWhiteSpace(textBoxTelefono.Text))
            {
                vacios = true;
                errorProviderTelefono.SetError(textBoxTelefono, "Ingrese un telefono");
            }

            //Validaciones CUIT



            return vacios;

        }
        #endregion

        #region validarCamposNoVacios
        public override void controlarCamposNoVacios()
        {


            if (!string.IsNullOrWhiteSpace(textBoxRazonSocial.Text))
            {
                errorProviderRazonSocial.SetError(textBoxRazonSocial, "");
            }


            //Limpia CUIT Largo
            if (textBoxCuitLargo.Text.Length == 8)
            {
                errorProviderCUITLargo.SetError(textBoxCuitLargo, "");
            }

            //Limpia CUIT Prefijo
            if (textBoxCUITPrefijo.Text.Length == 2)
            {
                errorProviderPrefijoCUIT.SetError(textBoxCUITPrefijo, "");

            }
            //Limpia CUIT Sufijo

            if (textBoxCUITSufijo.Text.Length == 2)
            {

                errorProviderSufijoCUIT.SetError(textBoxCUITSufijo, "");
            }



            if (!string.IsNullOrWhiteSpace(textBoxMail.Text))
            {

                errorProviderMail.SetError(textBoxMail, "");
            }

            //Direccion
            if (!string.IsNullOrWhiteSpace(textBoxDireccion.Text))
            {

                errorProviderDireccion.SetError(textBoxDireccion, "");
            }
            


            if (!string.IsNullOrWhiteSpace(textBoxTelefono.Text))
            {

                errorProviderTelefono.SetError(textBoxTelefono, "");
            }

        }
        #endregion

        #region eliminar texto provider
        public virtual void eliminarErrorProvider()
        {
            errorProviderRazonSocial.SetError(textBoxRazonSocial, "");
            errorProviderMail.SetError(textBoxMail, "");
            errorProviderTelefono.SetError(textBoxTelefono, "");

            //Limpio CUIT
            errorProviderCUITLargo.SetError(textBoxCuitLargo, "");
            errorProviderPrefijoCUIT.SetError(textBoxCUITPrefijo, "");
            errorProviderSufijoCUIT.SetError(textBoxCUITSufijo, "");


            //Limpio Direccion
            errorProviderDireccion.SetError(textBoxDireccion, "");


        }
        #endregion



    }
}
