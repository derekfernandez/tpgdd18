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
<<<<<<< HEAD
            Application.Run(new Canje_Puntos.Form1());
=======
            Application.Run(new Listado_Estadistico.VentanaSeleccion());
            //Application.Run(new Listado_Estadistico.ListadoPeoresEmpresas(2018, 2));
            //Application.Run(new Login.Login());
>>>>>>> 7222f1cea5adc201d7824f7da7e063b15fa10577
        }
        //Login.login();
    }
}
