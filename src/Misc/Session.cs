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

        public Boolean esAdministrativo()
        {
            return rol.descripcion.Equals("Administrativo");
        }

        public Boolean esAdminGeneral()
        {
            return rol.descripcion.Equals("Administrador General");
        }

        public Boolean esCliente()
        {
            return rol.descripcion.Equals("Cliente");
        }

        public Boolean esEmpresa()
        {
            return rol.descripcion.Equals("Empresa");
        }
    }

}
