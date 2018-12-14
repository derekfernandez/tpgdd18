using System;
using System.Collections.Generic;
using System.Data;
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

        public string calle { get; set; }
        public string altura { get; set; }
        public string piso { get; set; }
        public string depto { get; set; }
        public string localidad { get; set; }
        public string cp { get; set; }

        public string titulartarjeta { get; set; }
        public string numtarjeta { get; set; }
        public string cvvtarjeta { get; set; }
        public string emisortarjeta { get; set; }

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
            setCalle(direccion);
            setAltura(direccion);
            setPiso(direccion);
            setDepto(direccion);
            setLocalidad(direccion);
            setCP(direccion);
            DataRow tarjeta = Database.getTarjetaDeCliente(this);

            if (Database.clienteTieneTarjeta(this))
            {
                this.titulartarjeta = tarjeta["nombre_titular"].ToString();
                this.numtarjeta = tarjeta["numero_tarjeta"].ToString();
                this.emisortarjeta = tarjeta["nombre_banco"].ToString();
                this.cvvtarjeta = tarjeta["cvv"].ToString();
            }

            else
            {
                this.titulartarjeta = "";
                this.numtarjeta = "";
                this.emisortarjeta = "";
                this.cvvtarjeta = "";
            }
        }

        public Cliente(String nombre, String apellido, String cuil, String tipo_doc, String nro_doc, String fecha_nac,
                            String fecha_creacion, String mail, String direccion, String tel, String idtarjeta, String iduser, String estado)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.cuil = cuil;
            this.tipo_doc = tipo_doc;
            this.nro_doc = nro_doc;
            this.fecha_nac = fecha_nac;
            this.fecha_creacion = fecha_creacion;
            this.mail = mail;
            this.direccion = direccion;
            this.tel = tel;
            this.idtarjeta = idtarjeta;
            this.iduser = iduser;
            this.estado = estado;
            setCalle(direccion);
            setAltura(direccion);
            setPiso(direccion);
            setDepto(direccion);
            setLocalidad(direccion);
            setCP(direccion);
            DataRow tarjeta = Database.getTarjetaDeCliente(this);
            this.titulartarjeta = tarjeta["nombre_titular"].ToString();
            this.numtarjeta = tarjeta["numero_tarjeta"].ToString();
            this.emisortarjeta = tarjeta["nombre_banco"].ToString();
            this.cvvtarjeta = tarjeta["cvv"].ToString();
        }

        public Cliente(string id)
        {
            this.id = id;
        }

        public void setCalle(string direccion)
        {
            string[] dir = direccion.Split(new Char[] { ',', 'º' });
            calle = dir[0];
        }

        public void setAltura(string direccion)
        {
            string[] dir = direccion.Split(new Char[] { ',', 'º' });
            altura = dir[1];
        }

        public void setPiso(string direccion)
        {
            string[] dir = direccion.Split(new Char[] { ',', 'º' });
            piso = dir[2];
        }

        public void setDepto(string direccion)
        {
            string[] dir = direccion.Split(new Char[] { ',', 'º' });
            depto = dir[3];
        }

        public void setLocalidad(string direccion)
        {
            string[] dir = direccion.Split(new Char[] { ',', 'º' });
            localidad = dir[4];
        }

        public void setCP(string direccion)
        {
            cp = direccion.Substring(direccion.Length - 4);
        }

        public string getCalle()
        {
            return calle;
        }

        public string getAltura()
        {
            return altura;
        }

        public string getPiso()
        {
            return piso;
        }

        public string getDepto()
        {
            return depto;
        }

        public string getLocalidad()
        {
            return localidad;
        }

        public string getCP()
        {
            return cp;
        }



    }
}
