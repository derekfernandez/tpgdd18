using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Misc
{
    class EstadisticasUtils
    {

        public static int ObtenerNumeroTrimestre(string opcionCombo)
        {
            
            int n = 0;

            if(opcionCombo.Equals("1 (Ene-Mar)"))
            {
                n = 1;
            }
            else if (opcionCombo.Equals("2 (Abr-Jun)"))
            {
                n = 2;
            }
            else if (opcionCombo.Equals("3 (Jul-Sep)"))
            {
                n = 3;
            }
            else if (opcionCombo.Equals("4 (Oct-Dec)"))
            {
                n = 4;
            }

            return n;

        }

    }
}
