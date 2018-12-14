using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Misc
{
    class Tarjeta
    {
        public string id { get; set; }
        public string nro { get; set; }
        public string cvv { get; set; }
        public string banco { get; set; }
        public string titular { get; set; }


        public Tarjeta(string nro, string cvv, string banco, string titular,string id)
        {
            this.id = id;
            this.nro = nro;
            this.cvv = cvv;
            this.banco = banco;
            this.titular = titular;
        }

        public Tarjeta(string nro, string cvv, string banco, string titular)
        {
            this.nro = nro;
            this.cvv = cvv;
            this.banco = banco;
            this.titular = titular;
        }
    }
}
