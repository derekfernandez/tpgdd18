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
        string id = "-1";
        public AMB_Modificar_Eliminar()
        {
            InitializeComponent();
            grillaEmpresas.AllowUserToAddRows = false;
            grillaEmpresas.AllowUserToDeleteRows = false;
            
        }

        private void bntAltaEmpresa_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("La operación fue exitosa", "", MessageBoxButtons.OK);
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
            
                query = string.Format("select * from SQLITO.Empresas where razonsocial like '{0}%' and cuit like '{1}%' and mail like '{2}%'", textBoxRazonSocial.Text, textBoxCUIT.Text, textBoxEmail.Text);
            
                grillaEmpresas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                if (Database.ObtenerDataSet(query).Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron empresas para mostrar");
                }
                else
                {
                    grillaEmpresas.DataSource = Database.ObtenerDataSet(query).Tables[0];

                    grillaEmpresas.Columns[0].Visible = false;
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

            if (id == "-1")
            {
                MessageBox.Show("Seleccione una fila a deshabilitar");
            }
            else
            {
                string eliminar = string.Format("[SQLITO].[pr_Baja_empresa] '{0}'", id);
                
                if (yaEliminado(id))
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

            //Vuelvo a cargar el DGV con los mismos filtros, para que se vea como quedo actualizado
            cargarGrilla();

        }

        
        public Boolean yaEliminado(string validacion) 
        {

            string queryBuscar = string.Format("select 1 from SQLITO.Empresas where id_empresa = '{0}' and habilitado = 0", validacion);
            if (Database.ObtenerDataSet(queryBuscar).Tables[0].Rows.Count == 0)
                return false;
            return true;
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
            if (id == "-1")
            {
                MessageBox.Show("No se encontro la empresa a modificar");
            }
            else
            {

                ModificacionEmpresas modEmp = new ModificacionEmpresas(id);
                modEmp.ShowDialog();
                       
            }

            //Vacio los textboxes y el DGV
            vaciar();
            grillaEmpresas.DataSource = null;
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
            
            //Limpio primero todos los controles del form
            foreach (Control c in this.Controls)
            {

                if (c is TextBox)
                {

                    c.Text = "";

                }

            }

            //Y vacio el DGV, para que no traiga ningun resultado
            grillaEmpresas.DataSource = null;

        }

        private void grillaEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Hasta que no se modifique el admin el id sera + 2!
            id = Convert.ToString(grillaEmpresas.SelectedCells[0].RowIndex + 1);
                     
        }  

      
    }
}
