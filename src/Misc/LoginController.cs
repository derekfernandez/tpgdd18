using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Controllers
{
    public class LoginController
    {

        #region Atributos

        public bool ok { get; set; }
        public string msg { get; set; }

        #endregion

        public LoginController succeed(string username)
        {
            ok = true;
            msg = username;
            return this;
        }

        public LoginController failure()
        {
            ok = false;
            msg = "Usuario y/o contraseña incorrectos";
            return this;
        }

        public LoginController sendBlockMsg()
        {
            ok = false;
            msg = "Usuario Deshabilitado";
            return this;
        }

        internal LoginController sendNotFoundMsg()
        {
            ok = false;
            msg = "Usuario incorrecto";
            return this;
        }

        internal LoginController sendPasswordMatchingFailure()
        {
            ok = false;
            msg = "Password incorrecto";
            return this;
        }
    }
}
