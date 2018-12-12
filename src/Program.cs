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
            //Application.Run(new Login.Login());
            Usuario u = new Usuario("empresa1");
            u.id = "775";
            Application.Run(new Generar_Publicacion.VentanaPrincipal(u));
        }

    }
}
