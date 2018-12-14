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

namespace PalcoNet.Abm_Rol
{
    public partial class RoleMainWindow : BaseWindow
    {
        Session session { get; set; }

        //temporal para probar

        public RoleMainWindow(Session session)
        {
            InitializeComponent();
            this.session = session;
        }

        private void RoleMainWindow_Load(object sender, EventArgs e)
        {
            List <string> funcionalidadesDisponibles = Database.getFuncionalidades();
            foreach (string f in funcionalidadesDisponibles)
            {
                listBox_disponibles.Items.Add(f);
            }

            dgvRefresh();
            dgv_addButton(dgv_modify, "Modificar");
            dgv_addButton(dgv_delete, "Eliminar");
        }

        private void RoleMainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void dgvRefresh()
        {   
            DataTable roles = Database.getRoles_table();
            DataTable rolesActivos = Database.getRolesActivos_table();
            dgv_modify.DataSource = roles;
            dgv_delete.DataSource = rolesActivos;
            dgv_modify.Columns["habilitado"].Visible = false;
            dgv_delete.Columns["habilitado"].Visible = false;
        }

        private void dgv_modify_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                Rol rol = new Rol(dgv_modify.Rows[e.RowIndex].Cells["id_rol"].Value.ToString(),dgv_modify.Rows[e.RowIndex].Cells["descripcion"].Value.ToString());
                new Modify(rol).ShowDialog();
            }
        }

        private void dgv_delete_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                Rol rol = new Rol(dgv_delete.Rows[e.RowIndex].Cells["descripcion"].Value.ToString());
                Database.inhabilitarRol(rol);
                MessageBox.Show("El rol fue inhabilitado con éxito", "", MessageBoxButtons.OK);
                dgvRefresh();
                //sacar rol a clientes
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox_agregadas.SelectedItem != null)
            {
                errorAdv_asignadas.Hide();
                errorSeleccionNula.Hide();
                listBox_disponibles.Items.Add(listBox_agregadas.SelectedItem);
                listBox_agregadas.Items.Remove(listBox_agregadas.SelectedItem);
                listBox_disponibles.SelectedIndex = 0;
                listBox_disponibles.Sorted = true;
                
                if (listBox_agregadas.Items.Count > 0)
                {
                    listBox_agregadas.SelectedIndex = 0;
                }
            }

            else
            {
                errorAdv_asignadas.Show();
                errorSeleccionNula.Show();
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox_disponibles.SelectedItem != null)
            {
                errorAdv_disponibles.Hide();
                errorSeleccionNula.Hide();
                listBox_agregadas.Items.Add(listBox_disponibles.SelectedItem);
                listBox_disponibles.Items.Remove(listBox_disponibles.SelectedItem);
                listBox_agregadas.SelectedIndex = 0;
                listBox_disponibles.Sorted = true;

                if (listBox_disponibles.Items.Count > 0)
                {
                    listBox_disponibles.SelectedIndex = 0;
                }
            }

            else
            {
                errorAdv_disponibles.Show();
                errorSeleccionNula.Show();
                return;
            }
        }

        private void textBox_roleName_TextChanged(object sender, EventArgs e)
        {
            errorAdv_nombre.Hide();
            error_nocompleto.Hide();
            error_sololetras.Hide();
            return;
        }

        private void reiniciar()
        {
            textBox_roleName.Clear();
            List<string> funcionalidadesDisponibles = Database.getFuncionalidades();
            foreach (string f in funcionalidadesDisponibles)
            {
                if (!listBox_disponibles.Items.Contains(f))
                {
                    listBox_disponibles.Items.Add(f);
                }
            }
            listBox_agregadas.Items.Clear();
            return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_roleName.Text))
            {
                errorAdv_nombre.Show();
                error_nocompleto.Show();
                return;
            }

            else if (!textBox_soloLetras(this.textBox_roleName))
            {
                errorAdv_nombre.Show();
                error_sololetras.Show();
                return;
            }

            else
            {

                if (listBox_agregadas.Items.Count > 0)
                {

                    List<string> li = new List<string>();

                    foreach (string val in listBox_agregadas.Items)
                    {
                        li.Add(val);
                    }

                    Rol nuevoRol = new Rol(textBox_roleName.Text);

                    if (Database.rolExiste(nuevoRol))
                    {
                        MessageBox.Show("El rol ya existe en el sistema", "Error", MessageBoxButtons.OK);
                        textBox_roleName.Clear();
                        return;
                    }

                    else
                    {
                        Database.guardarRol(nuevoRol);
                        Database.agregarFuncionalidades(nuevoRol, li);
                        MessageBox.Show("El rol fue agregado con éxito", "", MessageBoxButtons.OK);
                        this.reiniciar();
                        this.dgvRefresh();
                        return;
                    }
                }

                else
                {
                    MessageBox.Show("Debe seleccionar al menos una funcionalidad", "Error", MessageBoxButtons.OK);
                    return;
                }
            }
        }
    }
}
