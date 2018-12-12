using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Generar_Publicacion
{
    public class ItemCombo
    {
        
        public string Nombre { get; set; }
        public int Id { get; set; }

        public ItemCombo(string nombre, int id)
        {
            this.Nombre = nombre;
            this.Id = id;
        }

        public override string ToString()
        {
            return Nombre;
        }

    }
}
