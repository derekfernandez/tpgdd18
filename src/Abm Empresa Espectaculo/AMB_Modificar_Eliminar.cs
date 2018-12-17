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
                
                //LIMITACION: NO FILTRA POR VALORES NULOS
                filtrosVacios();
                string query = string.Format("select * from SQLITO.Empresas where (razonsocial like '{0}' or razonsocial is null) and (cuit like '{1}' or cuit is null) and (mail like '{2}' or mail is null)", textBoxRazonSocial.Text, textBoxCUIT.Text, textBoxEmail.Text);
                grillaEmpresas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                grillaEmpresas.DataSource = Database.ObtenerDataSet(query).Tables[0];

                grillaEmpresas.Columns[0].HeaderText = "ID";
                grillaEmpresas.Columns[1].HeaderText = "Razon Social";
                grillaEmpresas.Columns[2].HeaderText = "Fecha de Creacion";
                grillaEmpresas.Columns[3].HeaderText = "CUIT";
                grillaEmpresas.Columns[4].HeaderText = "Mail";
                grillaEmpresas.Columns[5].HeaderText = "Direccion";
                grillaEmpresas.Columns[6].HeaderText = "Telefono";
                grillaEmpresas.Columns[7].HeaderText = "Usuario ID";

                
            }
            catch (Exception exp) 
            {
                MessageBox.Show("Error: " + exp.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                filtrosVacios();
                string eliminar = string.Format("exec pr_Eliminar_empresa '{0}'", ObtenerIdentity());
                Database.execNonQuery(Database.createQuery(eliminar));
                //Database.ejecutarNonQueryShort(insert);
                MessageBox.Show("Empresa eliminada correctamente");
                
                btnBuscar_Click(sender,e);
            }
            catch (Exception exp)
            {
                
                MessageBox.Show("Error: " + exp.Message);
            }
        }

        private void AMB_Modificar_Eliminar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Si no aclaro estoy modificando el primer registro
        public int ObtenerIdentity() 
        {
            string query = string.Format("select * from SQLITO.Empresas where (razonsocial like '{0}' or razonsocial is null) and (cuit like '{1}' or cuit is null) and (mail like '{2}' or mail is null)", textBoxRazonSocial.Text, textBoxCUIT.Text, textBoxEmail.Text);
            int identitySearch = Database.ejecutarExecuteScalar<int>(query);
            return identitySearch;
        }
        
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int identidad = ObtenerIdentity();
            if(identidad == 0)
            {
                MessageBox.Show("No se encontro la empresa a modificar");
            }
            else
            {
            this.Hide();
            ModificacionEmpresas modEmp = new ModificacionEmpresas(identidad);
            modEmp.Show();
            }
        }

        

        private void AMB_Modificar_Eliminar_Load(object sender, EventArgs e)
        {

        }

    

      
    }
}
