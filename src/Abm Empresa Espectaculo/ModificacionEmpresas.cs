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

        public override void btnCargar_Click(object sender, EventArgs e)
        {
            if (todosNulos())
            {
                MessageBox.Show("Ingrese una empresa por favor");
            }
            else
            {
                string update = string.Format("pr_Modificar_Empresa '{0}','{1}','{2}','{3}','{4}','{5}'", textBoxRazonSocial.Text, textBoxCuit.Text, textBoxMail.Text, textBoxDireccion.Text, textBoxTelefono.Text, idEmpresa);
                try
                {
                    Database.ejecutarNonQueryShort(update);
                    MessageBox.Show("Empresa actualizada correctamente");
                    this.Hide();
                    Abm_Empresa_Espectaculo.AMB_Modificar_Eliminar nuevoMod = new AMB_Modificar_Eliminar();
                    nuevoMod.Show();
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error: " + exp.Message);
                }
            }
        }

        public void cargarTextBox() 
        {
            string query = string.Format("select * from SQLITO.Empresas where id_empresa = '{0}'", idEmpresa);

            textBoxRazonSocial.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["razonsocial"].ToString();
            textBoxCuit.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["cuit"].ToString();
            textBoxMail.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["mail"].ToString();
            textBoxDireccion.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["direccion"].ToString();
            textBoxTelefono.Text = Database.ObtenerDataSet(query).Tables[0].Rows[0]["telefono"].ToString();
          
        }
    }
}
