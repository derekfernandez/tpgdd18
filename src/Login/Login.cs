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

namespace PalcoNet.Login
{
    public partial class Login : BaseWindow
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.AcceptButton = loginBtn;
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void userTextbox_TextChanged(object sender, EventArgs e)
        {
            controllerError.Clear();
            failureMsgLabel.Hide();
        }

        private void pwTextbox_TextChanged(object sender, EventArgs e)
        {
            controllerError.Clear();
            failureMsgLabel.Hide();
        }

        private void byeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (camposNoVacios(this,controllerError))
            {
                LoginController login = Database.checkLogin(userTextbox.Text, pwTextbox.Text);

                    if (login.ok)
                    {
                        this.loginOK(login);
                    }
                    
                    else
                    {
                        this.loginFailed(login);
                    }
            }
        }

        private void loginOK(LoginController login)
        {
            this.Hide();
            string username = login.msg;

            Usuario user = new Usuario(username);
            user.id = Database.getIDFor(user);

            Session session = new Session(user, Database.getRolesFor(user));

            if (session.cantRoles() >1)
            {
                new ElegirRol(session).Show();
            }

            else
            {
                session.rol = new Rol(Database.getRolesFor(user).ElementAt(0));
                session.rol.id = Database.getIdRol(session.rol);
                session.rol.funcionalidades = Database.getFuncionalidadesDeRol(session.rol);
                new MenuPrincipal(session).Show();
             }
        }

        private void loginFailed(LoginController login)
        {
            pwTextbox.Clear();
            failureMsgLabel.Text = login.msg;
            failureMsgLabel.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Registro_de_Usuario.Registro().Show();
        }
    }
}