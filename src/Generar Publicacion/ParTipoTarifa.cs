using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Generar_Publicacion
{
    public class ParTipoTarifa
    {
        public CheckBox cb;
        public NumericUpDown nud;

        public ParTipoTarifa(CheckBox cb, NumericUpDown nud)
        {
            setCB(cb);
            setNUD(nud);
            nud.Minimum = 0;
            nud.Maximum = 99999;
        }

        public CheckBox getCB()
        {
            return cb;
        }

        public NumericUpDown getNUD()
        {
            return nud;
        }

        public void setCB(CheckBox cb)
        {
            this.cb = cb;
        }

        public void setNUD(NumericUpDown nud)
        {
            this.nud = nud;
        }
    }
}
