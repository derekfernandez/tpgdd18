﻿using PalcoNet.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Listado_Estadistico
{
    public partial class VentanaSeleccion : Form
    {

        private ErrorProvider errorProvider;
        
        public VentanaSeleccion()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            dtpAño.Format = DateTimePickerFormat.Custom;
            dtpAño.CustomFormat = "yyyy";
            dtpAño.ShowUpDown = true;
        }

        private void btnPeoresEmpresas_Click(object sender, EventArgs e)
        {
            
            if (dtpAño.Value == null)
            {
                errorProvider.SetError(dtpAño, "Debe ingresar un año");
                return;
            }
            else if (comboTrim.SelectedIndex < 0)
            {
                errorProvider.SetError(comboTrim, "Debe elegir un trimestre");
                return;
            }

            errorProvider.Clear();
            ListadoPeoresEmpresas lpe = new ListadoPeoresEmpresas(dtpAño.Value.Year,
                                            EstadisticasUtils.ObtenerNumeroTrimestre(comboTrim.SelectedItem.ToString()));
            lpe.ShowDialog();

        }

        private void btnClientesPuntos_Click(object sender, EventArgs e)
        {
            
            if (dtpAño.Value == null)
            {
                errorProvider.SetError(dtpAño, "Debe ingresar un año");
                return;
            }
            else if (comboTrim.SelectedIndex < 0)
            {
                errorProvider.SetError(comboTrim, "Debe elegir un trimestre");
                return;
            }

            errorProvider.Clear();
            ListadoClientesPuntos lcp = new ListadoClientesPuntos(dtpAño.Value.Year,
                                            EstadisticasUtils.ObtenerNumeroTrimestre(comboTrim.SelectedItem.ToString()));
            lcp.ShowDialog();

        }


    }
}