using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public void limpiarTextBox(Control window)
        {
            foreach (Control obj in window.Controls)
            {
                if (obj is TextBox)
                {
                    TextBox textbox = (TextBox)obj;
                    textbox.Clear();
                }
            }
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

        public Boolean esNumero(Char caracter)
        {
            return Char.IsDigit(caracter);
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


        public Boolean textBox_soloNumeros(TextBox txb)
        {
            List<Char> li = new List<Char>();

            foreach (Char letra in txb.Text)
            {
                li.Add(letra);
            }

            return li.TrueForAll(ch => esNumero(ch));
        }

        public Boolean cuilFormatoValido(string cadena)
        {
            List<Char> aux = new List<Char>();

            foreach(char c in cadena)
            {
                aux.Add(c);
            }

            if (cadena.Length == 13)
            {
                if (esNumero(aux.ElementAt(0)) && esNumero(aux.ElementAt(1)) && (aux.ElementAt(2) == '-') && esNumero(aux.ElementAt(3))
                    && esNumero(aux.ElementAt(4)) && esNumero(aux.ElementAt(5)) && esNumero(aux.ElementAt(6)) && esNumero(aux.ElementAt(7))
                       && esNumero(aux.ElementAt(8)) && esNumero(aux.ElementAt(9)) && esNumero(aux.ElementAt(10))
                            && (aux.ElementAt(11) == '-') && esNumero(aux.ElementAt(12)))
                {
                    return true;
                }

                else return false;
            }

            else if (cadena.Length == 12)
            {
                if (esNumero(aux.ElementAt(0)) && esNumero(aux.ElementAt(1)) && (aux.ElementAt(2) == '-') && esNumero(aux.ElementAt(3))
                    && esNumero(aux.ElementAt(4)) && esNumero(aux.ElementAt(5)) && esNumero(aux.ElementAt(6)) && esNumero(aux.ElementAt(7))
                       && esNumero(aux.ElementAt(8)) && esNumero(aux.ElementAt(9)) && (aux.ElementAt(10) == '-')
                            && esNumero(aux.ElementAt(11)))
                {
                    return true;
                }

                else return false;
            }

            else return false;
        }

        public Boolean cuitFormatoValido(string cadena)
        {
            List<Char> aux = new List<Char>();

            foreach (char c in cadena)
            {
                aux.Add(c);
            }

            if (cadena.Length == 14)
            {
                if (esNumero(aux.ElementAt(0)) && esNumero(aux.ElementAt(1)) && (aux.ElementAt(2) == '-') && esNumero(aux.ElementAt(3))
                    && esNumero(aux.ElementAt(4)) && esNumero(aux.ElementAt(5)) && esNumero(aux.ElementAt(6)) && esNumero(aux.ElementAt(7))
                       && esNumero(aux.ElementAt(8)) && esNumero(aux.ElementAt(9)) && esNumero(aux.ElementAt(10))
                            && (aux.ElementAt(11) == '-') && esNumero(aux.ElementAt(12)) && esNumero(aux.ElementAt(13)))
                {
                    return true;
                }

                else return false;
            }

            else if (cadena.Length == 13)
            {
                if (esNumero(aux.ElementAt(0)) && esNumero(aux.ElementAt(1)) && (aux.ElementAt(2) == '-') && esNumero(aux.ElementAt(3))
                    && esNumero(aux.ElementAt(4)) && esNumero(aux.ElementAt(5)) && esNumero(aux.ElementAt(6)) && esNumero(aux.ElementAt(7))
                       && esNumero(aux.ElementAt(8)) && esNumero(aux.ElementAt(9)) && (aux.ElementAt(10) == '-')
                            && esNumero(aux.ElementAt(11)) && esNumero(aux.ElementAt(12)))
                {
                    return true;
                }

                else return false;
            }

            else return false;
        }

        public Boolean textBoxVacio(TextBox txb)
        { 
            return string.IsNullOrWhiteSpace(txb.Text);
        }

        public static Boolean check_email(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }

        public static Boolean check_cp(string cp)
        {
            Regex regex = new Regex(@"^[a-z]*[0-9][a-z0-9]*$");
            Match m = regex.Match(cp);
            return m.Success;
        }

        public static void dgv_addButton(DataGridView dgv, string t)
        {
            DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
            boton.Text = t;
            boton.Name = "Accion";
            boton.UseColumnTextForButtonValue = true;
            dgv.Columns.Add(boton);
        }

        public static void dgv_eliminarColumna(DataGridView dgv, string t)
        {
            dgv.Columns.Remove(t);
        }

        public static void comboBox_cargarTiposDocumento(ComboBox cb)
        {
            cb.Items.Add("DNI");
            cb.Items.Add("LC");
            cb.Items.Add("LE");
        }

        public static void comboBox_cargarRolesUsuario(ComboBox cb)
        {
            cb.Items.Add("Cliente");
            cb.Items.Add("Empresa");
        }

        private void BaseWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
