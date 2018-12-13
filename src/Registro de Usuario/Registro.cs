using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Misc;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class Registro : BaseWindow
    {

        public Session session { get; set; }
        public Cliente cliente { get; set; }

        #region Constructores

        public Registro(Cliente cliente)
        {
            this.cliente = cliente;
            InitializeComponent();
        }

        public Registro(Session session)
        {
            this.session = session;
            InitializeComponent();
        }
      
        public Registro()
        {
            InitializeComponent();
        }

        #endregion

        private void Registro_Load(object sender, EventArgs e)
        {
            if (session != null)
            {
                groupBox_gral.Enabled = false;
                groupBox_gral.Visible = false;
                groupBox_empresa.Enabled = false;
                groupBox_empresa.Visible = false;
                groupBox_clientes.Enabled = true;
                groupBox_clientes.Visible = true;
                comboBox_cargarTiposDocumento(comboBox_tipodoc);
                monthCalendar_fechanac.MaxDate = DateTime.Parse(ConfigurationManager.AppSettings["FechaSistema"].ToString());
                monthCalendar_fechanac.MinDate = new DateTime(1910, 01, 01, 00, 00, 00);
            }

            else if (cliente != null)
            {
                groupBox_gral.Enabled = false;
                groupBox_gral.Visible = false;
                groupBox_empresa.Enabled = false;
                groupBox_empresa.Visible = false;
                groupBox_clientes.Enabled = true;
                groupBox_clientes.Visible = true;
                comboBox_cargarTiposDocumento(comboBox_tipodoc);
                monthCalendar_fechanac.MaxDate = DateTime.Parse(ConfigurationManager.AppSettings["FechaSistema"].ToString());
                monthCalendar_fechanac.MinDate = new DateTime(1910, 01, 01, 00, 00, 00);
                label1.Visible = false;
                lbl_modify.Visible = true;

                //cargando datos del cliente al form
                textBox_nombre.Text = cliente.nombre;
                textBox_apellido.Text = cliente.apellido;
                textBox_cuil.Text = cliente.cuil;
                textBox_doc.Text = cliente.nro_doc;
                comboBox_tipodoc.SelectedText = cliente.tipo_doc;
                textBox_mail.Text = cliente.mail;
                textBox_tel.Text = cliente.tel;
                textBox_banco.Text = Database.getBancoTarjeta(cliente);
                textBox_cvv.Text = Database.getCVVTarjeta(cliente);
                textBox_nrotarjeta.Text = Database.getNroTarjeta(cliente);
                lbl_seleccionfecha.Text = cliente.fecha_nac;
            }

            else
            {
                comboBox_cargarRolesUsuario(comboBox_roles);
                comboBox_cargarTiposDocumento(comboBox_tipodoc);
                btn_next.Enabled = false;
                monthCalendar_fechanac.MaxDate = DateTime.Parse(ConfigurationManager.AppSettings["FechaSistema"].ToString());
                monthCalendar_fechanac.MinDate = new DateTime(1910, 01, 01, 00, 00, 00);
            } 
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            if (Database.userExiste(textBox_usuario.Text))
            {
                errorAdv_usernodisp.Show();
                lbl_usernodisp.Show();
                return;
            }

            else if (string.IsNullOrWhiteSpace(textBox_usuario.Text))
            {
                lbl_uservacio.Show();
                errorAdv_usernodisp.Show();
                return;
            }

            else
            {
                if (!string.IsNullOrWhiteSpace(textBox_password.Text) && comboBox_roles.SelectedIndex != -1)
                {
                    btn_next.Enabled = true;
                }

                succesAdv_username.Show();
                return;
            }
        }

        private void textBox_usuario_TextChanged(object sender, EventArgs e)
        {
            lbl_usernodisp.Hide();
            lbl_uservacio.Hide();
            errorAdv_usernodisp.Hide();
            succesAdv_username.Hide();
            btn_next.Enabled = false;
        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {
            lbl_pwlength.Hide();
            errorAdv_pwlength.Hide();

            if (textBox_password.Text.Length < 6)
            {
                lbl_pwlength.Show();
                errorAdv_pwlength.Show();
                btn_next.Enabled = false;
                return;
            }

            else
            {
                if (succesAdv_username.Visible && comboBox_roles.SelectedIndex != -1)
                {
                    btn_next.Enabled = true;
                    return;
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login.Login().Show();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario(textBox_usuario.Text, textBox_password.Text);

            if (comboBox_roles.Text == "Cliente")
            {
                groupBox_clientes.Enabled = true;
                groupBox_clientes.Visible = true;
                groupBox_gral.Enabled = false;
                return;
            }

            else
            {   
                groupBox_empresa.Enabled = true;
                groupBox_empresa.Visible = true;
                groupBox_gral.Enabled = false;
                return;
            }
        }

        private void comboBox_roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_password.Text) && !(textBox_password.Text.Length < 6)
                        && succesAdv_username.Visible)
            {
                btn_next.Enabled = true;
                return;
            }
        }

        private void textBox_nombre_TextChanged(object sender, EventArgs e)
        {
            if (!textBox_soloLetras(textBox_nombre))
            {
                errorAdv_nombre.Show();
                lbl_nombreinvalido.Show();
                return;
            }

            else
            {
                errorAdv_nombre.Hide();
                lbl_nombreinvalido.Hide();
                return;
            }
        }

        private void textBox_apellido_TextChanged(object sender, EventArgs e)
        {
            if (!textBox_soloLetras(textBox_apellido))
            {
                errorAdv_apellido.Show();
                lbl_nombreinvalido.Show();
                return;
            }

            else
            {
                errorAdv_apellido.Hide();
                lbl_nombreinvalido.Hide();
                return;
            }
        }

        private void textBox_doc_TextChanged(object sender, EventArgs e)
        {
            if (comboBox_tipodoc.SelectedIndex == -1)
            {
                errorAdv_doc.Show();
                return;
            }

            else if (!textBox_soloNumeros(textBox_doc))
            {
                errorAdv_doc.Show();
                lbl_formatodoc.Show();
                return;
            }

            else
            {
                if (textBox_doc.Text.Length < 8 || textBox_doc.Text.Length > 9)
                {
                    errorAdv_doc.Show();
                    lbl_formatodoc.Show();
                    return;
                }

                else
                {
                    errorAdv_doc.Hide();
                    lbl_formatodoc.Hide();
                    return;
                }

            }
        }

        private void comboBox_tipodoc_SelectedIndexChanged(object sender, EventArgs e) { }

        private void textBox_cuil_TextChanged(object sender, EventArgs e)
        {
            if (cuilFormatoValido(textBox_cuil.Text))
            {
                errorAdv_cuil.Hide();
                lbl_cuilinvalido.Hide();
                return;
            }

            else
            {
                lbl_cuilinvalido.Show();
                errorAdv_cuil.Show();
                return;
            }
        }

        private void textBox_mail_TextChanged(object sender, EventArgs e)
        {
            if (!check_email(textBox_mail.Text))
            {
                errorAdv_mail.Show();
                lbl_mailinvalido.Show();
                return;
            }

            else
            {
                errorAdv_mail.Hide();
                lbl_mailinvalido.Hide();
                return;
            }
        }

        private void textBox_tel_TextChanged(object sender, EventArgs e)
        {
            if (!textBox_soloNumeros(textBox_tel))
            {
                errorAdv_tel.Show();
                lbl_telinvalido.Show();
                return;
            }

            else if (textBox_tel.Text.Length < 8 || textBox_tel.Text.Length > 12)
            {
                errorAdv_tel.Show();
                lbl_telinvalido.Show();
                return;
            }

            else
            {
                errorAdv_tel.Hide();
                lbl_telinvalido.Hide();
                return;
            }
        }

        private void monthCalendar_fechanac_DateChanged(object sender, DateRangeEventArgs e)
        {
            lbl_seleccionfecha.Text = monthCalendar_fechanac.SelectionStart.ToShortDateString();
            errorAdv_fecha.Hide();
            return;
        }

        private void textBox_calle_TextChanged(object sender, EventArgs e)
        {
            if (textBox_soloNumeros(textBox_calle))
            {
                errorAdv_calle.Show();
                return;
            }

            else
            {
                errorAdv_calle.Hide();
            }
        }

        private void textBox_nro_TextChanged(object sender, EventArgs e)
        {
            if (!textBox_soloNumeros(textBox_nro))
            {
                errorAdv_nro.Show();
                return;
            }

            else
            {
                errorAdv_nro.Hide();
                return;
            }
        }

        private void textBox_piso_TextChanged(object sender, EventArgs e)
        {
            if (!textBox_soloNumeros(textBox_piso))
            {
                errorAdv_piso.Show();
                return;
            }

            else
            {
                errorAdv_piso.Hide();
                return;
            }
        }

        private void textBox_localidad_TextChanged(object sender, EventArgs e)
        {
            if (textBox_soloNumeros(textBox_localidad))
            {
                errorAdv_localidad.Show();
                return;
            }

            else
            {
                errorAdv_localidad.Hide();
                return;
            }
        }

        private void textBox_cp_TextChanged(object sender, EventArgs e)
        {

            if (!textBox_soloNumeros(textBox_cp))
            {
                errorAdv_cp.Show();
                return;
            }

            else
            {
                errorAdv_cp.Hide();
                return;
            }
        }

        private void textBox_nrotarjeta_TextChanged(object sender, EventArgs e)
        {
            if (!textBox_soloNumeros(textBox_nrotarjeta))
            {
                errorAdv_nrotarjeta.Show();
                lbl_factsolonros.Show();
                return;
            }

            else
            {
                errorAdv_nrotarjeta.Hide();
                lbl_factsolonros.Hide();
                return;
            }
        }

        private void textBox_cvv_TextChanged(object sender, EventArgs e)
        {
            if (!textBox_soloNumeros(textBox_cvv))
            {
                errorAdv_cvv.Show();
                lbl_factsolonros.Show();
                return;
            }

            else
            {
                errorAdv_cvv.Hide();
                lbl_factsolonros.Hide();
                return;
            }
        }

        private void btn_terminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_nombre.Text))
            {
                errorAdv_nombre.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_apellido.Text))
            {
                errorAdv_apellido.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_doc.Text) || comboBox_tipodoc.SelectedIndex == -1)
            {
                errorAdv_doc.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_cuil.Text))
            {
                errorAdv_cuil.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_mail.Text))
            {
                errorAdv_mail.Show();
            }

            if (string.IsNullOrWhiteSpace(lbl_seleccionfecha.Text))
            {
                errorAdv_fecha.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_calle.Text))
            {
                errorAdv_calle.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_nro.Text))
            {
                errorAdv_nro.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_piso.Text))
            {
                errorAdv_piso.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_localidad.Text))
            {
                errorAdv_localidad.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_cp.Text))
            {
                errorAdv_cp.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_cvv.Text))
            {
                errorAdv_cvv.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_nrotarjeta.Text))
            {
                errorAdv_nrotarjeta.Show();

            }

            //crear cliente
            if (camposNoVacios(this.groupBox_clientes, ep) && comboBox_tipodoc.SelectedIndex != -1 && (!string.IsNullOrWhiteSpace(lbl_seleccionfecha.Text)))
            {
                MessageBox.Show("Usuario creado correctamente", "", MessageBoxButtons.OK);
                this.Hide();
                new Login.Login().Show();
            }

            else
            {
                ep.Clear();
                return;
            }
        }

        private void btn_backcliente_Click(object sender, EventArgs e)
        {
            groupBox_clientes.Enabled = false;
            groupBox_gral.Enabled = true;
            return;
        }

        private void btn_terminarempresa_Click(object sender, EventArgs e)
        {   
            if (string.IsNullOrWhiteSpace(textBox_razonsocial.Text))
            {
                errorAdv_razonsocial.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_cuit.Text))
            {
                errorAdv_cuit.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_telempresa.Text))
            {
                errorAdv_telempresa.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_mailempresa.Text))
            {
                errorAdv_mailempresa.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_calleempresa.Text))
            {
                errorAdv_calleempresa.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_nroempresa.Text))
            {
                errorAdv_nroempresa.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_ciudadempresa.Text))
            {
                errorAdv_ciudadempresa.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_localidadempresa.Text))
            {
                errorAdv_localidadempresa.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_cpempresa.Text))
            {
                errorAdv_cpempresa.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_pisoempresa.Text))
            {
                errorAdv_pisoempresa.Show();
            }

            //crear empresa
            if (camposNoVacios(this.groupBox_empresa, ep))
            {
                MessageBox.Show("Usuario creado correctamente", "", MessageBoxButtons.OK);
                this.Hide();
                new Login.Login().Show();
            }

            else
            {
                ep.Clear();
                return;
            }
        }

        private void btn_backempresa_Click(object sender, EventArgs e)
        {
            groupBox_empresa.Enabled = false;
            groupBox_gral.Enabled = true;
            return;
        }

        private void textBox_razonsocial_TextChanged(object sender, EventArgs e)
        {
            errorAdv_razonsocial.Hide();
            return;
        }

        private void textBox_cuit_TextChanged(object sender, EventArgs e)
        {
            if (!cuilFormatoValido(textBox_cuit.Text))
            {
                errorAdv_cuit.Show();
                lbl_cuitinvalido.Show();
                return;
            }

            else
            {
                errorAdv_cuit.Hide();
                lbl_cuitinvalido.Hide();
                return;
            }
        }

        private void textBox_mailempresa_TextChanged(object sender, EventArgs e)
        {
            if (!check_email(textBox_mailempresa.Text))
            {
                lbl_mailinvalidoempresa.Show();
                errorAdv_mailempresa.Show();
                return;
            }

            else
            {
                lbl_mailinvalidoempresa.Hide();
                errorAdv_mailempresa.Hide();
                return;
            }
        }

        private void textBox_telempresa_TextChanged(object sender, EventArgs e)
        {
            if (!textBox_soloNumeros(textBox_tel))
            {
                errorAdv_telempresa.Show();
                lbl_telinvalidoempresa.Show();
                return;
            }

            else if (textBox_telempresa.Text.Length < 8 || textBox_telempresa.Text.Length > 12)
            {
                errorAdv_telempresa.Show();
                lbl_telinvalidoempresa.Show();
                return;
            }

            else
            {
                errorAdv_telempresa.Hide();
                lbl_telinvalidoempresa.Hide();
                return;
            }
        }

        private void textBox_calleempresa_TextChanged(object sender, EventArgs e)
        {
            if (textBox_soloNumeros(textBox_calleempresa))
            {
                errorAdv_calleempresa.Show();
                return;
            }

            else
            {
                errorAdv_calleempresa.Hide();
                return;
            }
        }

        private void textBox_nroempresa_TextChanged(object sender, EventArgs e)
        {
            if (!textBox_soloNumeros(textBox_nroempresa))
            {
                errorAdv_nroempresa.Show();
                return;
            }

            else
            {
                errorAdv_nroempresa.Hide();
            }
        }

        private void textBox_pisoempresa_TextChanged(object sender, EventArgs e)
        {
            if (!textBox_soloNumeros(textBox_pisoempresa))
            {
                errorAdv_pisoempresa.Show();
                return;
            }

            else
            {
                errorAdv_pisoempresa.Hide();
                return;
            }
        }

        private void textBox_cpempresa_TextChanged(object sender, EventArgs e)
        {
            if (!textBox_soloNumeros(textBox_cpempresa))
            {
                errorAdv_cpempresa.Show();
                return;
            }

            else
            {
                errorAdv_cpempresa.Hide();
                return;
            }
        }

        private void textBox_ciudadempresa_TextChanged(object sender, EventArgs e)
        {
            if (textBox_soloNumeros(textBox_ciudadempresa))
            {
                errorAdv_ciudadempresa.Show();
                return;
            }

            else
            {
                errorAdv_ciudadempresa.Hide();
                return;
            }
        }

        private void textBox_localidadempresa_TextChanged(object sender, EventArgs e)
        {
            if (textBox_soloNumeros(textBox_localidadempresa))
            {
                errorAdv_localidadempresa.Show();
                return;
            }

            else
            {
                errorAdv_localidadempresa.Hide();
                return;
            }
        }
    }
}
