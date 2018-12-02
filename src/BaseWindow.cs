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
    }
}
