﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Misc
{
    public class Usuario
    {

        public string username { get; set; }
        public string id { get; set; }

        #region Constructores

        public Usuario(string username)
        {
            this.username = username;
        }

        #endregion
    }
}
