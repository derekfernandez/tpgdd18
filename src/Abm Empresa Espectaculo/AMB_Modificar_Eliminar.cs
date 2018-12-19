using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PalcoNet.Controllers;
using PalcoNet.Misc;


namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class AMB_Modificar_Eliminar : Form
    {
        
        public AMB_Modificar_Eliminar()
        {
            InitializeComponent();
            grillaEmpresas.AllowUserToAddRows = false;
            grillaEmpresas.AllowUserToDeleteRows = false;
            
        }

        private void bntAltaEmpresa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La operación fue exitosa", "", MessageBoxButtons.OK);
            this.Close();
        }

        public void filtrosVacios() 
        {
         
         foreach (Control c in Controls)
            {

                if (c is TextBox && c.Text == "")
                {

                    c.Text = "%";

                }

            }
        
        }

        public void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
            cargarGrilla();
            }
            catch (Exception exp) 
            {
                MessageBox.Show("Error: " + exp.Message);
            }
        }


        public void cargarGrilla() 
        {
            string query;
            filtrosVacios();
            if (textBoxEmail.Text == "%")
            {
                query = string.Format("select * from SQLITO.Empresas where razonsocial like '{0}%' and cuit like '{1}%' and (mail like '{2}%' or mail is null)", textBoxRazonSocial.Text, textBoxCUIT.Text, textBoxEmail.Text);
            }
            else
            {
                query = string.Format("select * from SQLITO.Empresas where razonsocial like '{0}%' and cuit like '{1}%' and mail like '{2}%'", textBoxRazonSocial.Text, textBoxCUIT.Text, textBoxEmail.Text);
            }
                grillaEmpresas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                if (Database.ObtenerDataSet(query).Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No hay empresas para mostrar");
                }
                else
                {
                    grillaEmpresas.DataSource = Database.ObtenerDataSet(query).Tables[0];

                    grillaEmpresas.Columns[0].HeaderText = "ID";
                    grillaEmpresas.Columns[1].HeaderText = "Razon Social";
                    grillaEmpresas.Columns[2].HeaderText = "Fecha de Creacion";
                    grillaEmpresas.Columns[3].HeaderText = "CUIT";
                    grillaEmpresas.Columns[4].HeaderText = "Mail";
                    grillaEmpresas.Columns[5].HeaderText = "Direccion";
                    grillaEmpresas.Columns[6].HeaderText = "Telefono";
                    grillaEmpresas.Columns[7].HeaderText = "Habilitado";
                    grillaEmpresas.Columns[8].HeaderText = "Usuario ID";
                }
               
            
            vaciar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            if (todosNulos())
            {
                MessageBox.Show("Ingrese una empresa a eliminar");
            }
            else
            {
                string eliminar = string.Format("update SQLITO.Empresas set habilitado = 0 where id_empresa = '{0}'", ObtenerIdentity());
                string validacion = ObtenerIdentity();
                if (validacion == "")
                {
                    MessageBox.Show("No se encontro la empresa a eliminar");
                }

                else if (validacion == "-1")
                 {
                        MessageBox.Show("Error, hay mas de una empresa a eliminar");
                 }

                else if (yaEliminado(validacion))
                {
                    MessageBox.Show("Empresa ya eliminada");
                }
                else
                {
                         try
                            {
                                Database.execNonQuery(Database.createQuery(eliminar));
                                //Database.ejecutarNonQueryShort(insert);
                                MessageBox.Show("Empresa eliminada correctamente");
                                cargarGrilla();
                            }
                            catch (Exception exp)
                            {

                                MessageBox.Show("Error: " + exp.Message);
                            }
                }
            }
            vaciar();
        }

        private void AMB_Modificar_Eliminar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public Boolean yaEliminado(string validacion) 
        {

            string queryBuscar = string.Format("select 1 from SQLITO.Empresas where id_empresa = '{0}' and habilitado = 0", validacion);
            if (Database.ObtenerDataSet(queryBuscar).Tables[0].Rows.Count == 0)
                return false;
            return true;
        }

        //Si no aclaro estoy modificando el primer registro
        public string ObtenerIdentity() 
        {
                        
                filtrosVacios();
                string query;
                if (textBoxEmail.Text == "%")
                {
                    query = string.Format("select * from SQLITO.Empresas where razonsocial like '{0}' and cuit like '{1}' and (mail like '{2}' or mail is null)", textBoxRazonSocial.Text, textBoxCUIT.Text, textBoxEmail.Text);
                }
                else
                {
                    query = string.Format("select * from SQLITO.Empresas where razonsocial like '{0}' and cuit like '{1}' and mail like '{2}'", textBoxRazonSocial.Text, textBoxCUIT.Text, textBoxEmail.Text);
                }
                

                try
                {
                    if (Database.ObtenerDataSet(query).Tables[0].Rows.Count > 1)
                    {
                        return "-1";
                    }
                    return Database.ObtenerDataSet(query).Tables[0].Rows[0]["id_empresa"].ToString();
                }
                catch
                {
                    return "";
                }
              
            
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
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (todosNulos())
            {
                MessageBox.Show("Ingrese una empresa a modificar");
            }
            else
            {
                    
                    string identidad = ObtenerIdentity();
                    if (identidad == "")
                    {
                        MessageBox.Show("No se encontro la empresa a modificar");
                    }
                    else if (identidad == "-1")
                    {
                        MessageBox.Show("Error, hay mas de una empresa a modificar");
                    }
                    else
                    {
                            MessageBox.Show(identidad);
                            this.Hide();
                            ModificacionEmpresas modEmp = new ModificacionEmpresas(identidad);
                            modEmp.Show();
                        
                    }
                
            }
            vaciar();
        }

        

        private void AMB_Modificar_Eliminar_Load(object sender, EventArgs e)
        {

        }

        public void vaciar() 
        {
            foreach (Control c in Controls)
            {

                if (c is TextBox && c.Text == "%" || c.Text == null || c.Text.ToLower() == "null")
                {

                    c.Text = "";

                }

            }
        }

        

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {

                if (c is TextBox)
                {

                    c.Text = "";

                }

            }
            cargarGrilla();
        }

    

      
    }
}
