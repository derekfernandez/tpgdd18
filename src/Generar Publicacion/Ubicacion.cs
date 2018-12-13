using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Generar_Publicacion
{
    public class Ubicacion
    {
        
        public string Fila { get; set; }
        public string Asiento { get; set; }
        public string TipoNombre { get; set; }
        public int TipoId { get; set; }
        public decimal Precio { get; set; }
        public int Id { get; set; }

        public Ubicacion(string fila, string asiento, string tipoNombre, int tipoId, decimal precio)
        {
            this.Fila = fila;
            this.Asiento = asiento;
            this.TipoNombre = tipoNombre;
            this.TipoId = tipoId;
            this.Precio = precio;
        }

        public Ubicacion(string fila, string asiento, string tipoNombre, int tipoId, decimal precio, int id)
        {
            this.Fila = fila;
            this.Asiento = asiento;
            this.TipoNombre = tipoNombre;
            this.TipoId = tipoId;
            this.Precio = precio;
            this.Id = id;
        }

    }
}
