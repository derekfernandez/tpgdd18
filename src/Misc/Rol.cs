using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Misc
{
    public class Rol
    {
        public string id { get; set; }
        public string descripcion { get; set; }
        public string habilitado { get; set; }

        public Rol(string descripcion)
        {
            this.descripcion = descripcion;
        }
    }
}
