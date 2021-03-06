﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Misc;

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    /// <summary>
    /// Todavia falta: Ver el tema de la sesion y toda la parte de back
    /// </summary>
    public partial class ABM_Menu_Empresa : Form
    {
        public Session session { get; set; }

        public ABM_Menu_Empresa(Session session)
        {
            this.session = session;
            InitializeComponent();
        }

        private void btnNuevaEmpresa_Click(object sender, EventArgs e)
        {
            ABM_Alta_Empresa nuevaAlta = new ABM_Alta_Empresa();
            nuevaAlta.ShowDialog();
        }

        private void btnModEliminar_Click(object sender, EventArgs e)
        {
            AMB_Modificar_Eliminar nuevoEditar = new AMB_Modificar_Eliminar();
            nuevoEditar.ShowDialog();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }


     
    }
}
