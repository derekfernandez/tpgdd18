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
        public List<string> funcionalidades { get; set; }

        public Rol(string descripcion)
        {
            this.descripcion = descripcion;
        }

        public Rol(string id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }

        public Rol(string id, string descripcion, string habilitado, List<string> funcionalidades)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.habilitado = habilitado;
            this.funcionalidades = funcionalidades;
        }
    }
}
