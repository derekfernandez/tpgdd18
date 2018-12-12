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
            this.Hide();
            ABM_Menu_Empresa nuevoMenu = new ABM_Menu_Empresa();
            nuevoMenu.Show();
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

        private void btnBuscar_Click(object sender, EventArgs e)
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
                string query = string.Format("select * from SQLITO.Empresas where (razonsocial like '{0}' or razonsocial is null) and (cuit like '{1}' or cuit is null) and (mail like '{2}' or mail is null)", textBoxRazonSocial.Text, textBoxCUIT.Text, textBoxEmail.Text);
                int identitySearch = Database.ejecutarExecuteScalar<int>(query);
                string eliminar = string.Format("exec pr_Eliminar_empresa '{0}'", identitySearch);
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Falta query para actualizar los campos que devuelve la grilla
            string actualizar = string.Format("update SQLITO.Empresas set ... where '{0}'");
            try
            {
                Database.execNonQuery(Database.createQuery(actualizar));
                MessageBox.Show("Empresa actualizada correctamente");

                btnBuscar_Click(sender, e);
            }
            catch (Exception exp)
            {

                MessageBox.Show("Error: " + exp.Message);
            }
        }

        private void grillaEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AMB_Modificar_Eliminar_Load(object sender, EventArgs e)
        {

        }

    

      
    }
}
