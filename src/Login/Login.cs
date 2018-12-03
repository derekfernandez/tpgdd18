﻿using System;
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
    public partial class LoginUsuario : BaseWindow
    {
        public LoginUsuario()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.AcceptButton = loginBtn;
        }

        private void Login_FormClosed(object sender, EventArgs e)
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
                ElegirRol roleSelect = new ElegirRol(session);
            }

            else
            {
                MenuPrincipal main = new MenuPrincipal(session);
            }
        }

        private void loginFailed(LoginController login)
        {
            pwTextbox.Clear();
            failureMsgLabel.Text = login.msg;
            failureMsgLabel.Show();
        }
    }
}