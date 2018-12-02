using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Misc
{
    public class Session
    {
        public Usuario user { get; set; }
        public List<string> roles { get; set; }

        #region Constructores

        public Session(Usuario user, List<string> roles)
        {
            this.user = user;
            this.roles = roles;
        }

        #endregion

        public int cantRoles()
        {
            return roles.Count;
        }
    }

}
