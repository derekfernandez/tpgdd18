using PalcoNet.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Usuario uss = new Usuario("unUS");
            Rol unROL = new Rol("nomROL");

            Session unaS = new Session(uss, unROL);

            Application.Run(new Abm_Grado.Grado(unaS));       
        }

    }
}
