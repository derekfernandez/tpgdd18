﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        #region Inicializacion

        private void Registro_Load(object sender, EventArgs e)
        {
            if (session != null)
            {
                btn_backcliente.Visible = false;
                btnmodify_back.Visible = true;
                groupBox_gral.Enabled = false;
                groupBox_gral.Visible = false;
                groupBox_empresa.Enabled = false;
                groupBox_empresa.Visible = false;
                groupBox_clientes.Enabled = true;
                groupBox_clientes.Visible = true;
                comboBox_cargarTiposDocumento(comboBox_tipodoc);
                dtp_fechanac.MaxDate = DateTime.Parse(ConfigurationManager.AppSettings["FechaSistema"].ToString());
                dtp_fechanac.MinDate = new DateTime(1910, 01, 01, 00, 00, 00);
            }

            else if (cliente != null)
            {
                btn_backcliente.Visible = false;
                btnmodify_back.Visible = true;
                lbl_showestado.Visible = true;
                lbl_estado.Visible = true;
                btn_habilitar.Visible = true;
                if (cliente.estado == "True")
                {
                    lbl_estado.Text = "Habilitado";
                    btn_habilitar.Enabled = false;
                }
                else
                {
                    lbl_estado.Text = "Inhabilitado";
                    btn_habilitar.Enabled = true;
                }
                groupBox_gral.Enabled = false;
                groupBox_gral.Visible = false;
                groupBox_empresa.Enabled = false;
                groupBox_empresa.Visible = false;
                groupBox_clientes.Enabled = true;
                groupBox_clientes.Visible = true;
                comboBox_cargarTiposDocumento(comboBox_tipodoc);
                dtp_fechanac.MaxDate = DateTime.Parse(ConfigurationManager.AppSettings["FechaSistema"].ToString());
                dtp_fechanac.MinDate = new DateTime(1910, 01, 01, 00, 00, 00);
                label1.Visible = false;
                lbl_modify.Visible = true;

                //cargando datos del cliente al form
                textBox_nombre.Text = cliente.nombre;
                textBox_apellido.Text = cliente.apellido;
                textBox_cuil.Text = cliente.cuil;
                textBox_doc.Text = cliente.nro_doc;
                if (cliente.tipo_doc == "DNI")
                {
                    comboBox_tipodoc.SelectedIndex = 0;
                }

                if (cliente.tipo_doc == "LE")
                {
                    comboBox_tipodoc.SelectedIndex = 2;
                }

                if (cliente.tipo_doc == "LC")
                {
                    comboBox_tipodoc.SelectedIndex = 1;
                }
                errorAdv_doc.Hide();
                textBox_mail.Text = cliente.mail;
                textBox_tel.Text = cliente.tel;
                textBox_banco.Text = Database.getBancoTarjeta(cliente);
                textBox_cvv.Text = Database.getCVVTarjeta(cliente);
                textBox_nrotarjeta.Text = Database.getNroTarjeta(cliente);
                lbl_seleccionfecha.Text = cliente.fecha_nac;
                lbl_ejcuil.Text = cliente.fecha_creacion;
                textBox_calle.Text = cliente.getCalle();
                textBox_nro.Text = cliente.getAltura();
                textBox_piso.Text = cliente.getPiso();
                textBox_depto.Text = cliente.getDepto();
                textBox_localidad.Text = cliente.getLocalidad();
                textBox_cp.Text = cliente.getCP();
                textBox_titular.Text = cliente.titulartarjeta;
                textBox_nrotarjeta.Text = cliente.numtarjeta;
                textBox_banco.Text = cliente.emisortarjeta;
                textBox_cvv.Text = cliente.cvvtarjeta;
            }

            else
            {
                comboBox_cargarRolesUsuario(comboBox_roles);
                comboBox_cargarTiposDocumento(comboBox_tipodoc);
                btn_next.Enabled = false;
                dtp_fechanac.MaxDate = DateTime.Parse(ConfigurationManager.AppSettings["FechaSistema"].ToString());
                dtp_fechanac.MinDate = new DateTime(1910, 01, 01, 00, 00, 00);
            } 
        }

        #endregion

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
            if (session != null)
            {
                this.Close();
            }

            else
            {
                this.Hide();
                new Login.Login().Show();
            }
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
                if (textBox_doc.Text.Length < 7 || textBox_doc.Text.Length > 8)
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
            if (textBox_soloNumeros(textBox_piso) || (!textBox_soloNumeros(textBox_piso) && textBox_piso.Text.Equals("PB")))
            {
                if (textBox_piso.Text.Equals("0"))
                {
                    textBox_piso.Text = "PB";
                }

                errorAdv_piso.Hide();
                return;
            }

            else
            {
                errorAdv_piso.Show();
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

            if (!check_cp(textBox_cp.Text))
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
            nrotarjetacounter.Text = textBox_nrotarjeta.Text.Length.ToString();
            lbl_tarjetalargoerror.Hide();

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

            else if (textBox_cvv.Text.Length != 3)
            {
                errorAdv_cvv.Show();
                lbl_cvvlen.Show();
                return;
            }

            else
            {
                errorAdv_cvv.Hide();
                lbl_factsolonros.Hide();
                lbl_cvvlen.Hide();
                return;
            }
        }

        private void btn_terminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_nombre.Text))
            {
                errorAdv_nombre.Show();
            }

            if (!string.IsNullOrWhiteSpace(textBox_doc.Text))
            {
                if (this.cliente != null && Database.documentoRepetido(comboBox_tipodoc.SelectedItem.ToString(), textBox_doc.Text) && 
                        !Database.documentoEsDeCliente(textBox_doc.Text, comboBox_tipodoc.SelectedItem.ToString(),cliente))
                {
                    MessageBox.Show("El documento ingresado ya se encuentra asociado a un cliente. Revise los datos e intente nuevamente", "", MessageBoxButtons.OK);
                    errorAdv_doc.Show();
                }

                else if (this.session != null && Database.documentoRepetido(comboBox_tipodoc.SelectedItem.ToString(), textBox_doc.Text))
                {
                    MessageBox.Show("El documento ingresado ya se encuentra asociado a un cliente. Revise los datos e intente nuevamente", "", MessageBoxButtons.OK);
                    errorAdv_doc.Show();
                }

                else if (this.session == null && this.cliente == null && Database.documentoRepetido(comboBox_tipodoc.SelectedItem.ToString(), textBox_doc.Text))
                {
                    MessageBox.Show("El documento ingresado ya se encuentra asociado a un cliente. Revise los datos e intente nuevamente", "", MessageBoxButtons.OK);
                    errorAdv_doc.Show();
                }
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

            if (string.IsNullOrWhiteSpace(textBox_tel.Text))
            {
                errorAdv_tel.Show();
            }

            if (string.IsNullOrWhiteSpace(textBox_titular.Text))
            {
                errorAdv_titular.Show();
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

            if (textBox_nrotarjeta.Text.Length != 16)
            {
                errorAdv_nrotarjeta.Show();
                lbl_tarjetalargoerror.Show();
            }

            //crear cliente
            if (camposNoVacios(this.groupBox_clientes, ep) && comboBox_tipodoc.SelectedIndex != -1 && (!string.IsNullOrWhiteSpace(lbl_seleccionfecha.Text))
                && cliente == null && session == null && !errorAdv_nombre.Visible && !errorAdv_apellido.Visible && !errorAdv_cuil.Visible && !errorAdv_doc.Visible
                && !errorAdv_tel.Visible && !errorAdv_mail.Visible && !errorAdv_fecha.Visible && !errorAdv_calle.Visible && !errorAdv_calle.Visible
                && !errorAdv_piso.Visible && !errorAdv_localidad.Visible && !errorAdv_titular.Visible && !errorAdv_cvv.Visible && !errorAdv_nrotarjeta.Visible
                && !errorAdv_nro.Visible && !errorAdv_cp.Visible)
            {
                if (!Database.cuilDuplicado(textBox_cuil.Text))
                {
                    string fechasistema = ConfigurationManager.AppSettings["FechaSistema"].ToString();
                    DateTime fechasistema_dt = DateTime.Parse(fechasistema);
                    lbl_ejcuil.Text = fechasistema_dt.ToShortDateString();

                    SqlCommand sql = Database.createQuery("INSERT INTO SQLITO.Tarjetas VALUES(@nom,@titular,@nro,@cvv)");
                    sql.Parameters.AddWithValue("@nom", textBox_banco.Text);
                    sql.Parameters.AddWithValue("@titular", textBox_titular.Text);
                    sql.Parameters.AddWithValue("@nro", textBox_nrotarjeta.Text);
                    sql.Parameters.AddWithValue("@cvv", textBox_cvv.Text);
                    Database.execNonQuery(sql);

                    SqlCommand cmd = Database.createQuery("SELECT TOP 1 id_tarjeta FROM SQLITO.Tarjetas ORDER BY id_tarjeta DESC");
                    string idtarjeta = Database.getValue(cmd);

                    Usuario user = new Usuario(textBox_usuario.Text, textBox_password.Text);
                    Database.guardarUsuario(user);
                    string iduser = Database.getIDFor(user);

                    SqlCommand q = Database.createQuery("INSERT INTO SQLITO.Roles_Usuarios VALUES(3,@id)");
                    q.Parameters.AddWithValue("@id", iduser);
                    Database.execNonQuery(q);

                    
                    Cliente nuevoCliente = new Cliente(textBox_nombre.Text, textBox_apellido.Text, textBox_cuil.Text,
                        comboBox_tipodoc.Text.ToString(), textBox_doc.Text, lbl_seleccionfecha.Text, ConfigurationManager.AppSettings["FechaSistema"].ToString(), textBox_mail.Text,
                        (textBox_calle.Text + "," + textBox_nro.Text + "," + textBox_piso.Text + "º" + textBox_depto.Text + "," + textBox_localidad.Text + ", CP: " + textBox_cp.Text),
                        textBox_tel.Text, idtarjeta, iduser, "1","0");
                    Database.guardarCliente(nuevoCliente);

                    MessageBox.Show("Usuario creado correctamente", "", MessageBoxButtons.OK);

                  
                    this.Hide();
                    new Login.Login().Show();
                    
                }

                else
                {
                    MessageBox.Show("CUIL Duplicado, intente nuevamente", "", MessageBoxButtons.OK);
                    textBox_cuil.Focus();
                    return;
                }
            }

            //crear cliente por administrador
            else if (camposNoVacios(this.groupBox_clientes, ep) && comboBox_tipodoc.SelectedIndex != -1 && (!string.IsNullOrWhiteSpace(lbl_seleccionfecha.Text))
                && cliente == null && session != null && !errorAdv_nombre.Visible && !errorAdv_apellido.Visible && !errorAdv_cuil.Visible && !errorAdv_doc.Visible
                && !errorAdv_tel.Visible && !errorAdv_mail.Visible && !errorAdv_fecha.Visible && !errorAdv_calle.Visible && !errorAdv_calle.Visible
                && !errorAdv_piso.Visible && !errorAdv_localidad.Visible && !errorAdv_titular.Visible && !errorAdv_cvv.Visible && !errorAdv_nrotarjeta.Visible
                && !errorAdv_nro.Visible && !errorAdv_cp.Visible)
            {
                if (!Database.cuilDuplicado(textBox_cuil.Text))
                {
                    
                    string fechasistema = ConfigurationManager.AppSettings["FechaSistema"].ToString();
                    DateTime fechasistema_dt = DateTime.Parse(fechasistema);
                    lbl_ejcuil.Text = fechasistema_dt.ToShortDateString();

                    SqlCommand sql = Database.createQuery("INSERT INTO SQLITO.Tarjetas VALUES(@nom,@titular,@nro,@cvv)");
                    sql.Parameters.AddWithValue("@nom", textBox_banco.Text);
                    sql.Parameters.AddWithValue("@titular", textBox_titular.Text);
                    sql.Parameters.AddWithValue("@nro", textBox_nrotarjeta.Text);
                    sql.Parameters.AddWithValue("@cvv", textBox_cvv.Text);
                    Database.execNonQuery(sql);

                    SqlCommand cmd = Database.createQuery("SELECT TOP 1 id_tarjeta FROM SQLITO.Tarjetas ORDER BY id_tarjeta DESC");
                    string idtarjeta = Database.getValue(cmd);

                    Usuario user = new Usuario(textBox_nombre.Text.ToLower()+textBox_apellido.Text, textBox_doc.Text);
                    Database.guardarUsuarioAdmin(user);
                    string iduser = Database.getIDFor(user);

                    SqlCommand q = Database.createQuery("INSERT INTO SQLITO.Roles_Usuarios VALUES(3,@id)");
                    q.Parameters.AddWithValue("@id", iduser);
                    Database.execNonQuery(q);

                    Cliente nuevoCliente = new Cliente(textBox_nombre.Text, textBox_apellido.Text, textBox_cuil.Text,
                        comboBox_tipodoc.Text.ToString(), textBox_doc.Text, lbl_seleccionfecha.Text, ConfigurationManager.AppSettings["FechaSistema"].ToString(), textBox_mail.Text,
                        (textBox_calle.Text + "," + textBox_nro.Text + "," + textBox_piso.Text + "º" + textBox_depto.Text + "," + textBox_localidad.Text + ", CP: " + textBox_cp.Text),
                        textBox_tel.Text, idtarjeta, iduser, "1","0");
                    Database.guardarCliente(nuevoCliente);

                    MessageBox.Show("Usuario creado correctamente", "", MessageBoxButtons.OK);

                    this.Close();
                }

                else
                {
                    MessageBox.Show("CUIL Duplicado, intente nuevamente", "", MessageBoxButtons.OK);
                    textBox_cuil.Focus();
                    return;
                }
            }

            //actualizar datos cliente
            else if (camposNoVacios(this.groupBox_clientes, ep) && comboBox_tipodoc.SelectedIndex != -1 && (!string.IsNullOrWhiteSpace(lbl_seleccionfecha.Text))
                    && cliente != null && !errorAdv_nombre.Visible && !errorAdv_apellido.Visible && !errorAdv_cuil.Visible && !errorAdv_doc.Visible
                    && !errorAdv_tel.Visible && !errorAdv_mail.Visible && !errorAdv_fecha.Visible && !errorAdv_calle.Visible && !errorAdv_calle.Visible
                    && !errorAdv_piso.Visible && !errorAdv_localidad.Visible && !errorAdv_titular.Visible && !errorAdv_cvv.Visible && !errorAdv_nrotarjeta.Visible
                    && !errorAdv_nro.Visible && !errorAdv_cp.Visible)
            {
                if (cliente.idtarjeta != String.Empty)
                {
                    if (!Database.cuilDuplicado(textBox_cuil.Text) || (Database.cuilDuplicado(textBox_cuil.Text) && Database.cuilEsDeCliente(textBox_cuil.Text,cliente)))
                    {
                        string fechacreacion_str = cliente.fecha_creacion;
                        DateTime fechacreacion_dt = DateTime.Parse(fechacreacion_str);
                        lbl_ejcuil.Text = fechacreacion_dt.ToShortDateString();
                        Tarjeta tarjetaModificada = new Tarjeta(textBox_nrotarjeta.Text, textBox_cvv.Text, textBox_banco.Text, textBox_titular.Text, cliente.idtarjeta);
                        Database.actualizarTarjeta(tarjetaModificada);
                        Cliente clienteModificado = new Cliente(cliente.id, textBox_nombre.Text, textBox_apellido.Text, textBox_cuil.Text,
                        comboBox_tipodoc.Text.ToString(), textBox_doc.Text, lbl_seleccionfecha.Text, lbl_ejcuil.Text, textBox_mail.Text,
                        (textBox_calle.Text + "," + textBox_nro.Text + "," + textBox_piso.Text + "º" + textBox_depto.Text + "," + textBox_localidad.Text + ", CP: " + textBox_cp.Text),
                        textBox_tel.Text, cliente.idtarjeta, cliente.iduser, cliente.estado, cliente.puntos);
                        Database.actualizarCliente(clienteModificado);

                        MessageBox.Show("Cliente modificado con éxito", "", MessageBoxButtons.OK);
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("CUIL Duplicado, intente nuevamente", "", MessageBoxButtons.OK);
                        textBox_cuil.Focus();
                        return;
                    }
                }

                else
                {
                    if (!Database.cuilDuplicado(textBox_cuil.Text))
                    {
                        string fechacreacion_str = cliente.fecha_creacion;
                        DateTime fechacreacion_dt = DateTime.Parse(fechacreacion_str);
                        lbl_ejcuil.Text = fechacreacion_dt.ToShortDateString();

                        SqlCommand sql = Database.createQuery("INSERT INTO SQLITO.Tarjetas VALUES(@nom,@titular,@nro,@cvv)");
                        sql.Parameters.AddWithValue("@nom", textBox_banco.Text);
                        sql.Parameters.AddWithValue("@titular", textBox_titular.Text);
                        sql.Parameters.AddWithValue("@nro", textBox_nrotarjeta.Text);
                        sql.Parameters.AddWithValue("@cvv", textBox_cvv.Text);
                        Database.execNonQuery(sql);

                        SqlCommand cmd = Database.createQuery("SELECT TOP 1 id_tarjeta FROM SQLITO.Tarjetas ORDER BY id_tarjeta DESC");
                        string idtarjeta = Database.getValue(cmd);

                        Cliente clienteModificado = new Cliente(cliente.id, textBox_nombre.Text, textBox_apellido.Text, textBox_cuil.Text,
                        comboBox_tipodoc.Text.ToString(), textBox_doc.Text, lbl_seleccionfecha.Text, lbl_ejcuil.Text, textBox_mail.Text,
                        (textBox_calle.Text + "," + textBox_nro.Text + "," + textBox_piso.Text + "º" + textBox_depto.Text + "," + textBox_localidad.Text + ", CP: " + textBox_cp.Text),
                        textBox_tel.Text, idtarjeta, cliente.iduser, cliente.estado,cliente.puntos);

                        Database.actualizarCliente(clienteModificado);

                        MessageBox.Show("Cliente modificado con éxito", "", MessageBoxButtons.OK);
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("CUIL Duplicado, intente nuevamente", "", MessageBoxButtons.OK);
                        return;
                    }
                }
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

            if (Database.razonSocialExiste(textBox_razonsocial.Text))
            {
                errorAdv_razonsocial.Show();
                MessageBox.Show("La razon social ingresada ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (camposNoVacios(this.groupBox_empresa, ep) && !errorAdv_razonsocial.Visible && !errorAdv_cuit.Visible
                && !errorAdv_telempresa.Visible && !errorAdv_mailempresa.Visible && !errorAdv_calleempresa.Visible && !errorAdv_nroempresa.Visible
                && !errorAdv_pisoempresa.Visible && !errorAdv_ciudadempresa.Visible && !errorAdv_localidadempresa.Visible && !errorAdv_cpempresa.Visible)
            {

                if (!Database.cuitDuplicado(textBox_cuit.Text))
                {

                    Usuario user = new Usuario(textBox_usuario.Text, textBox_password.Text);
                    Database.guardarUsuario(user);
                    string iduser = Database.getIDFor(user);
                    SqlCommand q = Database.createQuery("INSERT INTO SQLITO.Roles_Usuarios VALUES(1,@id)");
                    q.Parameters.AddWithValue("@id", iduser);
                    Database.execNonQuery(q);

                    SqlCommand cmd = Database.createQuery("INSERT INTO SQLITO.Empresas VALUES(@razonsoc,@fecha_creacion,@cuit,@mail,@dir,@tel,1,@userid)");
                    cmd.Parameters.AddWithValue("@razonsoc", textBox_razonsocial.Text);
                    cmd.Parameters.AddWithValue("@fecha_creacion", ConfigurationManager.AppSettings["FechaSistema"].ToString());
                    cmd.Parameters.AddWithValue("@cuit", textBox_cuit.Text);
                    cmd.Parameters.AddWithValue("@mail", textBox_mailempresa.Text);
                    cmd.Parameters.AddWithValue("@tel", textBox_telempresa.Text);
                    cmd.Parameters.AddWithValue("@userid", iduser);
                    cmd.Parameters.AddWithValue("@dir", (textBox_calleempresa.Text + "," + textBox_nroempresa.Text + "," + textBox_pisoempresa.Text
                        + "º" + textBox_deptoempresa.Text + "," + textBox_localidadempresa.Text + ", CP: " + textBox_cpempresa.Text + "," + textBox_ciudadempresa.Text));
                    Database.execNonQuery(cmd);

                    MessageBox.Show("Usuario creado correctamente", "", MessageBoxButtons.OK);
                    this.Hide();
                    new Login.Login().Show();
                }
              
                else
                {
                    MessageBox.Show("CUIT Duplicado, intente nuevamente", "", MessageBoxButtons.OK);
                    return;
                }
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
            if (!cuitFormatoValido(textBox_cuit.Text))
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
            if (textBox_soloNumeros(textBox_pisoempresa) || (!textBox_soloNumeros(textBox_pisoempresa) && textBox_pisoempresa.Text.Equals("PB")))
            {
                if (textBox_pisoempresa.Text.Equals("0"))
                {
                    textBox_pisoempresa.Text = "PB";
                }

                errorAdv_pisoempresa.Hide();
                return;
            }

            else
            {
                errorAdv_pisoempresa.Show();
                return;
            }
        }

        private void textBox_cpempresa_TextChanged(object sender, EventArgs e)
        {
            if (!check_cp(textBox_cpempresa.Text))
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

        private void textBox_titular_TextChanged(object sender, EventArgs e)
        {
            if (!textBox_soloLetras(textBox_titular))
            {
                errorAdv_titular.Show();
                return;
            }

            else
            {
                errorAdv_titular.Hide();
                return;    
            }
        }

        private void btn_habilitar_Click(object sender, EventArgs e)
        {
            btn_habilitar.Enabled = false;
            lbl_estado.Text = "Habilitado";
            Database.habilitarCliente(cliente);
            cliente.estado = "True";
            return;
        }

        private void btnmodify_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtp_fechanac_ValueChanged(object sender, EventArgs e)
        {
            lbl_seleccionfecha.Text = dtp_fechanac.Value.ToShortDateString();
            errorAdv_fecha.Hide();
            return;
        }
    }
}
