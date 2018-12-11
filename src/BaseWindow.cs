using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class BaseWindow : Form
    {   
        public BaseWindow()
        {
            InitializeComponent();
        }

        public bool camposNoVacios(Control window, ErrorProvider ep)
        {
            bool camposCompletos = true;

            foreach (Control obj in window.Controls)
            {
                if (obj is TextBox)
                {
                    TextBox textbox = (TextBox)obj;

                    if (string.IsNullOrWhiteSpace(textbox.Text))
                    {
                        camposCompletos = false;
                        ep.SetError(textbox, "Debe completar el campo");
                    }
                }
            }

            return camposCompletos;

        }

        public void fillSelect(ComboBox cb, List<String> d)
        {
            cb.Items.Clear();
            foreach (String val in d)
            {
                cb.Items.Add(val);
            }
        }

        public Boolean esLetra(Char letra)
        {
            return Char.IsLetter(letra) || Char.IsSeparator(letra) || Char.IsControl(letra);
        }

        public Boolean textBox_soloLetras(TextBox txb)
        {
            List<Char> li = new List<Char>();
                
            foreach (Char letra in txb.Text)
            {
                li.Add(letra);
            }

            return li.TrueForAll(ch => esLetra(ch));
        }

        public static void dgv_addButton(DataGridView dgv, string t)
        {
            DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
            boton.Text = t;
            boton.UseColumnTextForButtonValue = true;
            dgv.Columns.Add(boton);
        }

        private void BaseWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
