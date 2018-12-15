using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Misc;

namespace PalcoNet
{
    public partial class CambioPassword : Form
    {
        public Session session { get; set; }

        public CambioPassword(Session session)
        {
            InitializeComponent();
            this.session = session;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                if (textbox_ingresopw.Text != textbox_reingresopw.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK);
                    textbox_reingresopw.Clear();
                    return;
                }

                else
                {
                    SqlCommand query = Database.createQuery(@"UPDATE SQLITO.Usuarios SET password = @pw");
                    query.Parameters.AddWithValue("@pw", Database.encriptarPassword(textbox_ingresopw.Text));
                    query.Parameters.AddWithValue("@username", session.user.username);
                    Database.execNonQuery(query);
                    MessageBox.Show("La contraseña se cambió correctamente. Deberá ingresar la nueva contraseña en su próximo login", "Éxito", MessageBoxButtons.OK);
                    this.Close();
                }
            }
        }
    }
