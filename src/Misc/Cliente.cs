using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Misc
{
    public class Cliente
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cuil { get; set; }
        public string tipo_doc { get; set; }
        public string nro_doc { get; set; }
        public string fecha_nac { get; set; }
        public string fecha_creacion { get; set; }
        public string mail { get; set; }
        public string direccion { get; set; }
        public string tel { get; set; }
        public string idtarjeta { get; set; }
        public string iduser { get; set; }
        public string estado { get; set; }

        public Cliente(String id,String nombre,String apellido,String cuil,String tipo_doc,String nro_doc,String fecha_nac,
                            String fecha_creacion,String mail,String direccion,String tel, String idtarjeta,String iduser, String estado)
        {
            this.id=id;
            this.nombre=nombre;
            this.apellido=apellido;
            this.cuil=cuil;
            this.tipo_doc=tipo_doc;
            this.nro_doc=nro_doc;
            this.fecha_nac=fecha_nac;
            this.fecha_creacion=fecha_creacion;
            this.mail=mail;
            this.direccion=direccion;
            this.tel=tel;
            this.idtarjeta=idtarjeta;
            this.iduser=iduser;
            this.estado=estado;
        }

        public Cliente(string id)
        {
            this.id = id;
        }
    }
}
