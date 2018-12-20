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
    public partial class Modify : BaseWindow
    {
        public RoleMainWindow ventanaAnterior { get; set; }
        public Rol rol { get; set; }
        
        public Modify(Rol rol, RoleMainWindow ventanaAnterior)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.rol = rol;
            this.ventanaAnterior = ventanaAnterior;
        }

        private void Modify_Load(object sender, EventArgs e)
        {
            lblRol.Text = rol.descripcion;

            List<string> funcionalidadesPoseidas = Database.funcionalidesDe(rol);
            List<string> funcionalidades = Database.getFuncionalidades();

            foreach (string f in funcionalidades)
            {
                if (!funcionalidadesPoseidas.Contains(f))
                {
                    listBox_disponibles.Items.Add(f);
                }
            }

            foreach (string f in funcionalidadesPoseidas)
            {
                listBox_actuales.Items.Add(f);
            }

            textBox1.Text = rol.descripcion;

            if (!Database.rolHabilitado(rol))
            {
                lbl_habilitado.Hide();
                btn_habilitar.Enabled = true;
            }

            else
            {
                lbl_habilitado.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            errorAdv_nombre.Hide();
            error_sololetras.Hide();
            error_vacio.Hide();
            return;
        }

        //agregar a poseidas
        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox_disponibles.SelectedItem != null)
            {
                errorAdv_disponibles.Hide();
                error_nullselection.Hide();

                listBox_actuales.Items.Add(listBox_disponibles.SelectedItem);
                listBox_disponibles.Items.Remove(listBox_disponibles.SelectedItem);
                listBox_actuales.SelectedIndex = 0;
                listBox_actuales.Sorted = true;

                if (listBox_disponibles.Items.Count > 0)
                {
                    listBox_disponibles.SelectedIndex = 0;
                }
            }

            else
            {
                errorAdv_disponibles.Show();
                error_nullselection.Show();
                return;
            }
        }

        //quitar de poseidas
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox_actuales.SelectedItem != null)
            {
                errorAdv_actuales.Hide();
                error_nullselection.Hide();
                listBox_disponibles.Items.Add(listBox_actuales.SelectedItem);
                listBox_actuales.Items.Remove(listBox_actuales.SelectedItem);
                listBox_disponibles.SelectedIndex = 0;
                listBox_disponibles.Sorted = true;

                if (listBox_actuales.Items.Count > 0)
                {
                    listBox_actuales.SelectedIndex = 0;
                }
            }

            else
            {
                errorAdv_actuales.Show();
                error_nullselection.Show();
                return;
            }
        }

        //volver
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //modificar
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorAdv_nombre.Show();
                error_vacio.Show();
                return;
            }

            else if (!textBox_soloLetras(this.textBox1))
            {
                errorAdv_nombre.Show();
                error_sololetras.Show();
                return;
            }

            else if (Database.rolExiste(new Rol(textBox1.Text)) && textBox1.Text != rol.descripcion)
            {
                MessageBox.Show("El nombre ya existe en el sistema", "Error", MessageBoxButtons.OK);
                textBox1.Clear();
                return;
            }

            else
            {

                if (listBox_actuales.Items.Count > 0)
                {
                    Rol nuevoRol = new Rol(rol.id, textBox1.Text);
                    Database.updateRole(nuevoRol);

                    List<string> li = new List<string>();

                    foreach (string f in listBox_actuales.Items)
                    {
                        if (!Database.funcionalidesDe(nuevoRol).Contains(f))
                        {
                            li.Add(f);
                        }
                    }

                    Database.agregarFuncionalidades(nuevoRol, li);

                    List<string> li2 = new List<string>();

                    foreach (string func in listBox_disponibles.Items)
                    {
                        if (Database.funcionalidesDe(nuevoRol).Contains(func))
                        {
                            li2.Add(func);
                        }
                    }

                    Database.quitarFuncionalidades(nuevoRol, li2);
                    MessageBox.Show("Rol modificado con éxito", "", MessageBoxButtons.OK);
                    this.Close();
                }

                else
                {
                    Rol nuevoRol = new Rol(rol.id, textBox1.Text);
                    Database.updateRole(nuevoRol);

                    Database.inhabilitarRol(rol);
                    List<string> li2 = new List<string>();

                    foreach (string func in listBox_disponibles.Items)
                    {
                        if (Database.funcionalidesDe(nuevoRol).Contains(func))
                        {
                            li2.Add(func);
                        }
                    }

                    Database.quitarFuncionalidades(nuevoRol, li2);
                    MessageBox.Show("El rol fue inhabilitado", "", MessageBoxButtons.OK);
                    this.Close();
                }
            }

            ventanaAnterior.dgvRefresh();
        }

        private void btn_habilitar_Click(object sender, EventArgs e)
        {
            if (listBox_actuales.Items.Count < 1)
            {
                MessageBox.Show("Debe agregar al menos una funcionalidad para habilitar nuevamente el rol", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                Database.habilitarRol(rol);
                MessageBox.Show("El rol fue habilitado", "", MessageBoxButtons.OK);
                btn_habilitar.Enabled = false;
                lbl_habilitado.Show();
                ventanaAnterior.dgvRefresh();
                return;
            }
        }

        private void Modify_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
