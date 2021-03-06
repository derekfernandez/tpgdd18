﻿using System;
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

                direccion = textBoxDireccion.Text + "," + textBoxAltura.Text + "," + textBoxNumeroPiso.Text + "," + textBoxDepartamento.Text + "," + textBoxLocalidad.Text + "," + textBoxCodigoPostal.Text + "," + textBoxCiudad.Text;



                string update = string.Format("EXEC [SQLITO].[pr_Modificar_Empresa] '{0}','{1}','{2}','{3}','{4}','{5}','{6}'", textBoxRazonSocial.Text, cuitCompleto, textBoxMail.Text, direccion, textBoxTelefono.Text, idEmpresa, obtenerHabilitado());
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
       
            textBoxRazonSocial.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["razonsocial"].ToString();
            textBoxMail.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["mail"].ToString();
            textBoxMail.Text = textBoxMail.Text.Replace(" ", "");
            textBoxMail.Text = textBoxMail.Text.Replace(":", "");
            textBoxTelefono.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["telefono"].ToString();
            textBoxRazonSocial.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["razonsocial"].ToString();

          

            if (!(string.IsNullOrWhiteSpace(direcEntera)))
            {
                string[] direc = direcEntera.Split(',');


                if ((direc.All(x => !(string.IsNullOrWhiteSpace(x)))) && direc.Length == 7)
                {
                    textBoxDireccion.Text = direc[0];
                    textBoxAltura.Text = direc[1];
                    textBoxNumeroPiso.Text = direc[2];
                    textBoxDepartamento.Text = direc[3];
                    textBoxLocalidad.Text = direc[4];
                    textBoxCodigoPostal.Text = direc[5];
                    textBoxCiudad.Text = direc[6];
                }
                else
                {
                    asignarDirecciones(direc);
                }
            }

            if(!(string.IsNullOrWhiteSpace(cuitEntero)))
            {
                string[] cuit = cuitEntero.Split('-');

                textBoxCuitLargo.Text = cuit[1];
                textBoxCUITPrefijo.Text = cuit[0];
                textBoxCUITSufijo.Text = cuit[2];
            }
            

            string habilitado = Database.ObtenerDataSet(query).Tables[0].Rows[0]["habilitado"].ToString();

            if (habilitado == "True")
            {
                comboBoxHabilitado.SelectedIndex = 0;
            }
            else
                comboBoxHabilitado.SelectedIndex = 1;

      
        }

        #endregion


        
        public string obtenerHabilitado()
        {
            if (comboBoxHabilitado.SelectedIndex == 0)
            {
                return "1";
            }
            return "0";
        }



        public void asignarDirecciones(string[] direccion)
        {

                if (!(string.IsNullOrWhiteSpace(direccion[0])))
                {
                    textBoxDireccion.Text = direccion[0];
                }
                if (!(string.IsNullOrWhiteSpace(direccion[1])))
                {
                    textBoxAltura.Text = direccion[1];
                }
                if (!(string.IsNullOrWhiteSpace(direccion[2])))
                {
                    string[] div = direccion[2].Split('º');
                    textBoxNumeroPiso.Text = div[0];
                    textBoxDepartamento.Text = div[1];
                }
                if (!(string.IsNullOrWhiteSpace(direccion[3])))
                {
                    textBoxCiudad.Text = direccion[3];
                }
                if (!(string.IsNullOrWhiteSpace(direccion[4])))
                {
                    textBoxCodigoPostal.Text = direccion[4].Replace("CP:",string.Empty).Trim();
                }


        }




    }
}
