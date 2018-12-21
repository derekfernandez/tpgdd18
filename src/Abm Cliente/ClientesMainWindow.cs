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

namespace PalcoNet.Abm_Cliente
{
    public partial class ClientesMainWindow : BaseWindow
    {

        public Session session { get; set; }

        public ClientesMainWindow(Session session)
        {
            this.session = session;
            InitializeComponent();
        }

        public ClientesMainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void ClientesMainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel_registrocliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Registro_de_Usuario.Registro(session).ShowDialog();
        }

        #region modificar

        private void btn_clean_Click(object sender, EventArgs e)
        {   
            limpiarTextBox(this.tab_modificar);
            if (dgv_clientesmodificar.DataSource != null)
            {
                dgv_eliminarColumna(dgv_clientesmodificar, "Accion");
            }

            dgv_clientesmodificar.DataSource = null;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
          
            if (textBoxVacio(textBox_apellido) && textBoxVacio(textBox_nrodoc) && textBoxVacio(textBox_mail) && !textBoxVacio(textBox_nombre))
            {
                dgv_clientesmodificar.DataSource = Database.getClientesPorNombre(textBox_nombre.Text);
                dgv_clientesmodificar.Columns["estado"].Visible = false;
                if (dgv_clientesmodificar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_clientesmodificar, "Modificar");
                }
                return;
            }

            if (!textBoxVacio(textBox_apellido) && textBoxVacio(textBox_nrodoc) && textBoxVacio(textBox_mail) && textBoxVacio(textBox_nombre))
            {

                dgv_clientesmodificar.DataSource = Database.getClientesPorApellido(textBox_apellido.Text);
                dgv_clientesmodificar.Columns["estado"].Visible = false;
                if (dgv_clientesmodificar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_clientesmodificar, "Modificar");
                }
                return;
            }

            if (textBoxVacio(textBox_apellido) && !textBoxVacio(textBox_nrodoc) && textBoxVacio(textBox_mail) && textBoxVacio(textBox_nombre))
            {
                dgv_clientesmodificar.DataSource = Database.getClientesPorNroDoc(textBox_nrodoc.Text);
                dgv_clientesmodificar.Columns["estado"].Visible = false;
                if (dgv_clientesmodificar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_clientesmodificar, "Modificar");
                }
                return;
            }

            if (textBoxVacio(textBox_apellido) && textBoxVacio(textBox_nrodoc) && !textBoxVacio(textBox_mail) && textBoxVacio(textBox_nombre))
            {
                dgv_clientesmodificar.DataSource = Database.getClientesPorEmail(textBox_mail.Text);
                dgv_clientesmodificar.Columns["estado"].Visible = false;
                if (dgv_clientesmodificar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_clientesmodificar, "Modificar");
                }
                return;
            }

            if (!textBoxVacio(textBox_apellido) && textBoxVacio(textBox_nrodoc) && textBoxVacio(textBox_mail) && !textBoxVacio(textBox_nombre))
            {
                dgv_clientesmodificar.DataSource = Database.getClientesPorNombre_Apellido(textBox_nombre.Text,textBox_apellido.Text);
                dgv_clientesmodificar.Columns["estado"].Visible = false;
                if (dgv_clientesmodificar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_clientesmodificar, "Modificar");
                }
                return;
            }

            if (textBoxVacio(textBox_apellido) && textBoxVacio(textBox_nrodoc) && !textBoxVacio(textBox_mail) && !textBoxVacio(textBox_nombre))
            {
                dgv_clientesmodificar.DataSource = Database.getClientesPorNombre_mail(textBox_nombre.Text, textBox_mail.Text);
                dgv_clientesmodificar.Columns["estado"].Visible = false;
                if (dgv_clientesmodificar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_clientesmodificar, "Modificar");
                }
                return;
            }

            if (textBoxVacio(textBox_apellido) && !textBoxVacio(textBox_nrodoc) && textBoxVacio(textBox_mail) && !textBoxVacio(textBox_nombre))
            {
                dgv_clientesmodificar.DataSource = Database.getClientesPorNombre_nroDoc(textBox_nombre.Text, textBox_nrodoc.Text);
                dgv_clientesmodificar.Columns["estado"].Visible = false;
                if (dgv_clientesmodificar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_clientesmodificar, "Modificar");
                }
                return;
            }

            if (!textBoxVacio(textBox_apellido) && !textBoxVacio(textBox_nrodoc) && textBoxVacio(textBox_mail) && textBoxVacio(textBox_nombre))
            {
                dgv_clientesmodificar.DataSource = Database.getClientesPorApellido_nroDoc(textBox_apellido.Text, textBox_nrodoc.Text);
                dgv_clientesmodificar.Columns["estado"].Visible = false;
                if (dgv_clientesmodificar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_clientesmodificar, "Modificar");
                }
                return;
            }

            if (!textBoxVacio(textBox_apellido) && textBoxVacio(textBox_nrodoc) && !textBoxVacio(textBox_mail) && textBoxVacio(textBox_nombre))
            {
                dgv_clientesmodificar.DataSource = Database.getClientesPorApellido_mail(textBox_apellido.Text, textBox_mail.Text);
                dgv_clientesmodificar.Columns["estado"].Visible = false;
                if (dgv_clientesmodificar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_clientesmodificar, "Modificar");
                }
                return;
            }

            if (textBoxVacio(textBox_apellido) && !textBoxVacio(textBox_nrodoc) && !textBoxVacio(textBox_mail) && textBoxVacio(textBox_nombre))
            {
                dgv_clientesmodificar.DataSource = Database.getClientesPorMail_nroDoc(textBox_mail.Text, textBox_nrodoc.Text);
                dgv_clientesmodificar.Columns["estado"].Visible = false;
                if (dgv_clientesmodificar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_clientesmodificar, "Modificar");
                }
                return;
            }

            if (!textBoxVacio(textBox_apellido) && !textBoxVacio(textBox_nrodoc) && textBoxVacio(textBox_mail) && !textBoxVacio(textBox_nombre))
            {
                dgv_clientesmodificar.DataSource = Database.getClientesPorNombre_apellido_nrodoc(textBox_nombre.Text, textBox_apellido.Text, textBox_nrodoc.Text);
                dgv_clientesmodificar.Columns["estado"].Visible = false;
                if (dgv_clientesmodificar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_clientesmodificar, "Modificar");
                }
                return;
            }

            if (!textBoxVacio(textBox_apellido) && textBoxVacio(textBox_nrodoc) && !textBoxVacio(textBox_mail) && !textBoxVacio(textBox_nombre))
            {
                dgv_clientesmodificar.DataSource = Database.getClientesPorNombre_apellido_mail(textBox_nombre.Text, textBox_apellido.Text, textBox_mail.Text);
                dgv_clientesmodificar.Columns["estado"].Visible = false;
                if (dgv_clientesmodificar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_clientesmodificar, "Modificar");
                }
                return;
            }

            if (textBoxVacio(textBox_apellido) && !textBoxVacio(textBox_nrodoc) && !textBoxVacio(textBox_mail) && !textBoxVacio(textBox_nombre))
            {
                dgv_clientesmodificar.DataSource = Database.getClientesPorNombre_nroDoc_mail(textBox_nombre.Text, textBox_nrodoc.Text, textBox_mail.Text);
                dgv_clientesmodificar.Columns["estado"].Visible = false;
                if (dgv_clientesmodificar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_clientesmodificar, "Modificar");
                }
                return;
            }

            if (!textBoxVacio(textBox_apellido) && !textBoxVacio(textBox_nrodoc) && !textBoxVacio(textBox_mail) && textBoxVacio(textBox_nombre))
            {
                dgv_clientesmodificar.DataSource = Database.getClientesPorApellido_nroDoc_mail(textBox_apellido.Text, textBox_nrodoc.Text, textBox_mail.Text);
                dgv_clientesmodificar.Columns["estado"].Visible = false;
                if (dgv_clientesmodificar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_clientesmodificar, "Modificar");
                }
                return;
            }

            if (!textBoxVacio(textBox_apellido) && !textBoxVacio(textBox_nrodoc) && !textBoxVacio(textBox_mail) && !textBoxVacio(textBox_nombre))
            {
                dgv_clientesmodificar.DataSource = Database.getClientesPorNombre_apellido_nroDoc_mail(textBox_nombre.Text, textBox_apellido.Text, textBox_nrodoc.Text, textBox_mail.Text);
                dgv_clientesmodificar.Columns["estado"].Visible = false;
                if (dgv_clientesmodificar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_clientesmodificar, "Modificar");
                }
                return;
            }
        }

        #endregion

        #region Eliminar

        private void btn_searcheliminar_Click(object sender, EventArgs e)
        {
            if (textBoxVacio(textBox_apellidoeliminar) && textBoxVacio(textBox_nrodoceliminar) && textBoxVacio(textBox_maileliminar)
                    && !textBoxVacio(textBox_nombreeliminar))
            {
                dgv_eliminar.DataSource = Database.getClientesHabilitadosPorNombre(textBox_nombreeliminar.Text);
                dgv_eliminar.Columns["estado"].Visible = false;
                if (dgv_eliminar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_eliminar, "Eliminar");
                }
                return;
            }

            if (!textBoxVacio(textBox_apellidoeliminar) && textBoxVacio(textBox_nrodoceliminar) && textBoxVacio(textBox_maileliminar)
                    && textBoxVacio(textBox_nombreeliminar))
            {
                dgv_eliminar.DataSource = Database.getClientesHabilitadosPorApellido(textBox_apellidoeliminar.Text);
                dgv_eliminar.Columns["estado"].Visible = false; 
                if (dgv_eliminar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_eliminar, "Eliminar");
                }
                return;
            }

            if (textBoxVacio(textBox_apellidoeliminar) && !textBoxVacio(textBox_nrodoceliminar) && textBoxVacio(textBox_maileliminar)
                    && textBoxVacio(textBox_nombreeliminar))
            {
                dgv_eliminar.DataSource = Database.getClientesHabilitadosPorNroDoc(textBox_nrodoceliminar.Text);
                dgv_eliminar.Columns["estado"].Visible = false; 
                if (dgv_eliminar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_eliminar, "Eliminar");
                }
                return;
            }

            if (textBoxVacio(textBox_apellidoeliminar) && textBoxVacio(textBox_nrodoceliminar) && !textBoxVacio(textBox_maileliminar)
                    && textBoxVacio(textBox_nombreeliminar))
            {
                dgv_eliminar.DataSource = Database.getClientesHabilitadosPorEmail(textBox_maileliminar.Text);
                dgv_eliminar.Columns["estado"].Visible = false; 
                if (dgv_eliminar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_eliminar, "Eliminar");
                }
                return;
            }

            if (!textBoxVacio(textBox_apellidoeliminar) && textBoxVacio(textBox_nrodoceliminar) && textBoxVacio(textBox_maileliminar)
                    && !textBoxVacio(textBox_nombreeliminar))
            {
                dgv_eliminar.DataSource = Database.getClientesHabilitadosPorNombre_Apellido(textBox_nombreeliminar.Text,
                    textBox_apellidoeliminar.Text);
                dgv_eliminar.Columns["estado"].Visible = false; 
                if (dgv_eliminar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_eliminar, "Eliminar");
                }
                return;
            }

            if (textBoxVacio(textBox_apellidoeliminar) && textBoxVacio(textBox_nrodoceliminar) && !textBoxVacio(textBox_maileliminar)
                    && !textBoxVacio(textBox_nombreeliminar))
            {
                dgv_eliminar.DataSource = Database.getClientesHabilitadosPorNombre_mail(textBox_nombreeliminar.Text, textBox_maileliminar.Text);
                dgv_eliminar.Columns["estado"].Visible = false; 
                if (dgv_eliminar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_eliminar, "Eliminar");
                }
                return;
            }

            if (textBoxVacio(textBox_apellidoeliminar) && !textBoxVacio(textBox_nrodoceliminar) && textBoxVacio(textBox_maileliminar)
                    && !textBoxVacio(textBox_nombreeliminar))
            {
                dgv_eliminar.DataSource = Database.getClientesHabilitadosPorNombre_nroDoc(textBox_nombreeliminar.Text,
                    textBox_nrodoceliminar.Text);
                dgv_eliminar.Columns["estado"].Visible = false; 
                if (dgv_eliminar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_eliminar, "Eliminar");
                }
                return;
            }

            if (!textBoxVacio(textBox_apellidoeliminar) && !textBoxVacio(textBox_nrodoceliminar) && textBoxVacio(textBox_maileliminar)
                    && textBoxVacio(textBox_nombreeliminar))
            {
                dgv_eliminar.DataSource = Database.getClientesHabilitadosPorApellido_nroDoc(textBox_apellidoeliminar.Text,
                    textBox_nrodoceliminar.Text);
                dgv_eliminar.Columns["estado"].Visible = false; 
                if (dgv_eliminar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_eliminar, "Eliminar");
                }
                return;
            }

            if (!textBoxVacio(textBox_apellidoeliminar) && textBoxVacio(textBox_nrodoceliminar) && !textBoxVacio(textBox_maileliminar)
                    && textBoxVacio(textBox_nombreeliminar))
            {
                dgv_eliminar.DataSource = Database.getClientesHabilitadosPorApellido_mail(textBox_apellidoeliminar.Text, textBox_maileliminar.Text);
                dgv_eliminar.Columns["estado"].Visible = false; 
                if (dgv_eliminar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_eliminar, "Eliminar");
                }
                return;
            }

            if (textBoxVacio(textBox_apellidoeliminar) && !textBoxVacio(textBox_nrodoceliminar) && !textBoxVacio(textBox_maileliminar)
                    && textBoxVacio(textBox_nombreeliminar))
            {
                dgv_eliminar.DataSource = Database.getClientesHabilitadosPorMail_nroDoc(textBox_maileliminar.Text,
                    textBox_nrodoceliminar.Text);
                dgv_eliminar.Columns["estado"].Visible = false; 
                if (dgv_eliminar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_eliminar, "Eliminar");
                }
                return;
            }

            if (!textBoxVacio(textBox_apellidoeliminar) && !textBoxVacio(textBox_nrodoceliminar) && textBoxVacio(textBox_maileliminar)
                    && !textBoxVacio(textBox_nombreeliminar))
            {
                dgv_eliminar.DataSource = Database.getClientesHabilitadosPorNombre_apellido_nrodoc(textBox_nombreeliminar.Text,
                    textBox_apellidoeliminar.Text, textBox_nrodoceliminar.Text);
                dgv_eliminar.Columns["estado"].Visible = false; 
                if (dgv_eliminar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_eliminar, "Eliminar");
                }
                return;
            }

            if (!textBoxVacio(textBox_apellidoeliminar) && textBoxVacio(textBox_nrodoceliminar) && !textBoxVacio(textBox_maileliminar)
                    && !textBoxVacio(textBox_nombreeliminar))
            {
                dgv_eliminar.DataSource = Database.getClientesHabilitadosPorNombre_apellido_mail(textBox_nombreeliminar.Text,
                    textBox_apellidoeliminar.Text, textBox_maileliminar.Text);
                dgv_eliminar.Columns["estado"].Visible = false; 
                if (dgv_eliminar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_eliminar, "Eliminar");
                }
                return;
            }

            if (textBoxVacio(textBox_apellidoeliminar) && !textBoxVacio(textBox_nrodoceliminar) && !textBoxVacio(textBox_maileliminar)
                    && !textBoxVacio(textBox_nombreeliminar))
            {
                dgv_eliminar.DataSource = Database.getClientesHabilitadosPorNombre_nroDoc_mail(textBox_nombreeliminar.Text,
                    textBox_nrodoceliminar.Text, textBox_maileliminar.Text);
                dgv_eliminar.Columns["estado"].Visible = false; 
                if (dgv_eliminar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_eliminar, "Eliminar");
                }
                return;
            }

            if (!textBoxVacio(textBox_apellidoeliminar) && !textBoxVacio(textBox_nrodoceliminar) && !textBoxVacio(textBox_maileliminar)
                    && textBoxVacio(textBox_nombreeliminar))
            {
                dgv_eliminar.DataSource = Database.getClientesHabilitadosPorApellido_nroDoc_mail(textBox_apellidoeliminar.Text,
                    textBox_nrodoceliminar.Text, textBox_maileliminar.Text);
                dgv_eliminar.Columns["estado"].Visible = false; 
                if (dgv_eliminar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_eliminar, "Eliminar");
                }
                return;
            }

            if (!textBoxVacio(textBox_apellidoeliminar) && !textBoxVacio(textBox_nrodoceliminar) && !textBoxVacio(textBox_maileliminar)
                    && !textBoxVacio(textBox_nombreeliminar))
            {
                dgv_eliminar.DataSource = Database.getClientesHabilitadosPorNombre_apellido_nroDoc_mail(textBox_nombreeliminar.Text,
                    textBox_apellidoeliminar.Text, textBox_nrodoceliminar.Text, textBox_maileliminar.Text);
                dgv_eliminar.Columns["estado"].Visible = false; 
                if (dgv_eliminar.Columns.Count == 15)
                {
                    dgv_addButton(dgv_eliminar, "Eliminar");
                }
                return;
            }
        }

        private void btn_cleaneliminar_Click(object sender, EventArgs e)
        {
            textBox_maileliminar.Clear();
            textBox_nombreeliminar.Clear();
            textBox_nrodoceliminar.Clear();
            textBox_apellidoeliminar.Clear();
            if (dgv_eliminar.DataSource != null)
            {
                dgv_eliminarColumna(dgv_eliminar, "Accion");
            }

            dgv_eliminar.DataSource = null;
            dgv_eliminar.DataSource = null;
            return;
        }

        private void dgv_eliminar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                Cliente cliente = new Cliente(dgv_eliminar.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString());
                Database.inhabilitarCliente(cliente);
                MessageBox.Show("El cliente fue inhabilitado satisfactoriamente", "", MessageBoxButtons.OK);
                dgv_eliminar.Rows.RemoveAt(e.RowIndex);
                
                if (dgv_clientesmodificar.DataSource != null)
                {
                    dgv_eliminarColumna(dgv_clientesmodificar, "Accion");
                    dgv_clientesmodificar.DataSource = null;
                }
            }
        }

        #endregion

        private void dgv_clientesmodificar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {   
                Cliente cliente = new Cliente(dgv_clientesmodificar.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString(),
                    dgv_clientesmodificar.Rows[e.RowIndex].Cells["nombre"].Value.ToString(), dgv_clientesmodificar.Rows[e.RowIndex].Cells["apellido"].Value.ToString(),
                    dgv_clientesmodificar.Rows[e.RowIndex].Cells["cuil"].Value.ToString(), dgv_clientesmodificar.Rows[e.RowIndex].Cells["tipo_documento"].Value.ToString(),
                    dgv_clientesmodificar.Rows[e.RowIndex].Cells["numero_documento"].Value.ToString(), dgv_clientesmodificar.Rows[e.RowIndex].Cells["fecha_nacimiento"].Value.ToString(),
                    dgv_clientesmodificar.Rows[e.RowIndex].Cells["fecha_creacion"].Value.ToString(), dgv_clientesmodificar.Rows[e.RowIndex].Cells["mail"].Value.ToString(),
                    dgv_clientesmodificar.Rows[e.RowIndex].Cells["direccion"].Value.ToString(), dgv_clientesmodificar.Rows[e.RowIndex].Cells["telefono"].Value.ToString(),
                    dgv_clientesmodificar.Rows[e.RowIndex].Cells["tarjeta_id"].Value.ToString(), dgv_clientesmodificar.Rows[e.RowIndex].Cells["usuario_id"].Value.ToString(),
                    dgv_clientesmodificar.Rows[e.RowIndex].Cells["estado"].Value.ToString(), dgv_clientesmodificar.Rows[e.RowIndex].Cells["puntos_gastados"].Value.ToString());

                new Registro_de_Usuario.Registro(cliente).ShowDialog();
                if (dgv_clientesmodificar.DataSource != null)
                {
                    dgv_eliminarColumna(dgv_clientesmodificar, "Accion");
                }

                dgv_clientesmodificar.DataSource = null;

                if (dgv_eliminar.DataSource != null)
                {
                    dgv_eliminarColumna(dgv_eliminar, "Accion");
                    dgv_eliminar.DataSource = null;
                }
            }
        }
    }
}