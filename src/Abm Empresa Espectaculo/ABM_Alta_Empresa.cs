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


namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class ABM_Alta_Empresa : Form
    {
        int cantArrobas = 0;

        #region constructor

        public ABM_Alta_Empresa()
        {
            InitializeComponent();
        }

        #endregion
        

        #region Eventos Cargar / Limpiar Form

        public virtual void btnCargar_Click(object sender, EventArgs e)
        {
            

            if (validarCamposVacios())
            {
                MessageBox.Show("Complete los campos correspondientes");
                controlarCamposNoVacios();
            }
            else
            {

                eliminarErrorProvider();
                try
                {

                    string direccion = textBoxDireccion.Text + "," + textBoxAltura.Text + "," + textBoxNumeroPiso.Text + "," +  textBoxDepartamento.Text + "," + textBoxLocalidad.Text + "," + textBoxCodigoPostal.Text + "," + textBoxCiudad.Text;
                    string cuit = textBoxCUITPrefijo.Text + "-" + textBoxCuitLargo.Text + "-" + textBoxCUITSufijo.Text;

                    string insert = string.Format("exec [SQLITO].[pr_Alta_Empresa] '{0}','{1}','{2}','{3}','{4}'", textBoxRazonSocial.Text, cuit, textBoxMail.Text, direccion, textBoxTelefono.Text);

                    Database.ejecutarProc(insert);

                    MessageBox.Show("Empresa agregada correctamente");

                    limpiar();
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar la empresa: " + ex.Message);
                }
            }
            
        }
        #endregion


        #region Movimiento entre forms

        public virtual void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                //Aca se va a llamar al Form anterior donde estan las opciones del admin

                this.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error " + exp.Message);
            }

        }

        

     


        #endregion



        #region validaciones Nulos

        #region validarCamposVacios
        public virtual bool validarCamposVacios() 
        {
            bool vacios = false;

            if(string.IsNullOrWhiteSpace(textBoxRazonSocial.Text))
            {
                vacios = true;
                errorProviderRazonSocial.SetError(textBoxRazonSocial,"Ingrese una razon social");
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


            #region direccion
            if (string.IsNullOrWhiteSpace(textBoxDireccion.Text))
            {
                vacios = true;
                errorProviderDireccion.SetError(textBoxDireccion, "Ingrese una calle");
            }
            if (string.IsNullOrWhiteSpace(textBoxLocalidad.Text))
            {
                vacios = true;
                errorProviderLocalidad.SetError(textBoxLocalidad, "Ingrese una localidad");
            }
            if (string.IsNullOrWhiteSpace(textBoxDepartamento.Text))
            {
                vacios = true;
                errorProviderDepartamento.SetError(textBoxDepartamento, "Ingrese un departamento");
            }
            if (string.IsNullOrWhiteSpace(textBoxCodigoPostal.Text))
            {
                vacios = true;
                errorProviderCP.SetError(textBoxCodigoPostal, "Ingrese un codigo postal");
            }

            if (string.IsNullOrWhiteSpace(textBoxCiudad.Text))
            {

                errorProviderCiudad.SetError(textBoxCiudad, "Ingrese una ciudad");
            }

            if (string.IsNullOrWhiteSpace(textBoxNumeroPiso.Text))
            {

                errorProviderPiso.SetError(textBoxNumeroPiso, "ingrese un numero de piso");
            }
            if (string.IsNullOrWhiteSpace(textBoxAltura.Text))
            {
                vacios = true;
                errorProviderTelefono.SetError(textBoxAltura, "Ingrese una altura");
            }
            #endregion

            if (string.IsNullOrWhiteSpace(textBoxTelefono.Text))
            {
                vacios = true;
                errorProviderTelefono.SetError(textBoxTelefono, "Ingrese un telefono");
            }

           


            if (!validoArroba())
            {
                vacios = true;
                errorProviderMailSinArroba.SetError(textBoxMail, "Ingrese un unico @");
            }

            
           

           
            return vacios;

        }
        #endregion

        #region validarCamposNoVacios
        public void controlarCamposNoVacios()
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

#region Direccion
            if (!string.IsNullOrWhiteSpace(textBoxDireccion.Text))
            {
              
                errorProviderDireccion.SetError(textBoxDireccion, "");
            }
            if (!string.IsNullOrWhiteSpace(textBoxLocalidad.Text))
            {

                errorProviderLocalidad.SetError(textBoxLocalidad, "");
            }
            if (!string.IsNullOrWhiteSpace(textBoxDepartamento.Text))
            {

                errorProviderDepartamento.SetError(textBoxDepartamento, "");
            }
            if (!string.IsNullOrWhiteSpace(textBoxCodigoPostal.Text))
            {
                
                errorProviderCP.SetError(textBoxCodigoPostal, "");
            }
            if (!string.IsNullOrWhiteSpace(textBoxCiudad.Text))
            {
                
                errorProviderCiudad.SetError(textBoxCiudad, "");
            }
            
            if (!string.IsNullOrWhiteSpace(textBoxNumeroPiso.Text))
            {

                errorProviderPiso.SetError(textBoxNumeroPiso, "");
            }
#endregion

            //Telefono
            if (!string.IsNullOrWhiteSpace(textBoxTelefono.Text))
            {
                
                errorProviderTelefono.SetError(textBoxTelefono, "");
            }

            if (validoArroba())
            {
              
                errorProviderMailSinArroba.SetError(textBoxMail, "");
            }

            if (!(string.IsNullOrWhiteSpace(textBoxAltura.Text)))
            {

                errorProviderTelefono.SetError(textBoxAltura, "");
            }

        }

        public void eliminarErrorProvider() 
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
            errorProviderLocalidad.SetError(textBoxLocalidad, "");
            errorProviderDepartamento.SetError(textBoxDepartamento, "");
            errorProviderCP.SetError(textBoxCodigoPostal, "");
            errorProviderCiudad.SetError(textBoxCiudad, "");
            errorProviderPiso.SetError(textBoxNumeroPiso, "");
            errorProviderMailSinArroba.SetError(textBoxMail, "");
            errorProviderTelefono.SetError(textBoxAltura, "");

        }
        #endregion

        #region controlSobreVacios

        public virtual void limpiar() 
        {
            foreach (Control c in this.Controls)
            {

                if (c is TextBox)
                {

                    c.Text = "";

                }

            }
        }
        public virtual void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        public Boolean CamposVacio()
        {
            //Buscar una funcion que ya evalue si los campos son blancos: seguro hay
            foreach (Control c in Controls)
            {

                if (c is TextBox && c.Text == "")
                {
                    return true;
                }

            }
            return false;
        }

        public Boolean todosNulos()
        {
            foreach (Control c in Controls)
            {

                if (c is TextBox && c.Text.Trim() != "")
                {

                    return false;

                }

            }
            return true;
        }
        #endregion

        #endregion

        #region pre validaciones cuit
        public void validarIngresoSoloNumerico(object sender, KeyPressEventArgs e)
        {
            char caracter = e.KeyChar;

            if (!Char.IsDigit(caracter) && caracter != 8)
            {
                e.Handled = true;
            }
        }
        private void textBoxCUITPrefijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarIngresoSoloNumerico(sender, e);
        }

        private void textBoxCuitLargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarIngresoSoloNumerico(sender, e);
        }

        private void textBoxCUITSufijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarIngresoSoloNumerico(sender, e);
        }

        private void textBoxNumeroPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarIngresoSoloNumerico(sender, e);
        }

        private void textBoxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter = e.KeyChar;

            if (!Char.IsDigit(caracter) && caracter != 8 && caracter != '+')
            {
                e.Handled = true;
            }
        }

        private void soloTexto(object sender, KeyPressEventArgs e)
        {
            char caracter = e.KeyChar;

            if (Char.IsDigit(caracter))
            {
                e.Handled = true;
            }
        }

        private void textBoxAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarIngresoSoloNumerico(sender, e);
        }

        private void textBoxCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloTexto(sender, e);
        }

        private void textBoxLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloTexto(sender, e);
        }

        #endregion



        //Validacion mail
        public bool validoArroba()
        {
            
            foreach (char c in textBoxMail.Text)
            {
                if(c == '@')
                {
                    cantArrobas++;
                }
            }
            if (cantArrobas == 1)
            {
                cantArrobas = 0;
                return true;
            }
            cantArrobas = 0;
            return false;
        }

        

        private void textBoxNumeroPiso_Leave(object sender, EventArgs e)
        {
            if (textBoxNumeroPiso.Text == "0")
            {
                textBoxNumeroPiso.Text = "PB";
            }
        }

    

     
      

    

       
     

      

    }
}
