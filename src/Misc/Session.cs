using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Misc
{
    public class Session
    {
        public Usuario usuario;
        public Rol role;

        public Usuario user { get; set; }
        public List<string> roles { get; set; }
        public Rol rol { get; set; }

        
        public Session(Usuario user, List<string> roles)
        {
            this.user = user;
            this.roles = roles;
        }

        public Session(Usuario usuario, Rol rol)
        {
            this.usuario = usuario;
            this.rol = rol;
        }

        public int cantRoles()
        {
            return roles.Count;
        }
    }

}
