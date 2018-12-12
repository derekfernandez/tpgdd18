using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Generar_Publicacion
{
    public partial class DisposicionUbicaciones : Form
    {

        private ErrorProvider errorProvider;

        private List<Ubicacion> ubicacionesIngresadas;
        private BindingList<Ubicacion> ubicacionesBinding;
        private BindingSource ubicacionesSource;

        //Arrays para coherencia de Tipos habilitados
        private CheckBox[] checkBoxes;
        private NumericUpDown[] numerics;
        public ParTipoTarifa[] paresTT;
        private ItemCombo[] itemsComboTipo;
        
        public DisposicionUbicaciones(ParTipoTarifa[] pares, List<Ubicacion> ubicacionesIngresadas)
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();

            //Registro en los arrays los CBs y NUDs propios de esta instancia
            RegistrarCheckBoxes();
            RegistrarNUDs();
            RegistrarItemsCombo();

            //Tomo lo que me pasa el constructor (ubicaciones y tipos/tarifas existentes) y los guardo
            ActualizarPares(pares);
            this.ubicacionesIngresadas = ubicacionesIngresadas;

            //Actualizo el DataGridView con las ubicaciones que me pasaron por parametro y ajusto preferencias
            ActualizarDatosDGV();
        }

        #region Inicializacion

        //Actualizar NUDs y CBs locales con el valor de los pares pasados por parametro en el constructor
        public void ActualizarPares(ParTipoTarifa[] pares)
        {

            //Primero, registro los pares que me pasaron por constructor y los guardo en el array local
            paresTT = pares;

            int i;
            //A todos los NUDs y CBs les pongo los valores de los pares del constructor
            for (i = 0; i < 9; i++)
            {
                if(paresTT[i] != null)
                {
                    numerics[i].ReadOnly = paresTT[i].nud.ReadOnly;
                    numerics[i].Controls[0].Visible = paresTT[i].nud.Controls[0].Visible;
                    if (numerics[i].ReadOnly == false)
                    {
                        numerics[i].Value = paresTT[i].nud.Value;
                    }
                    checkBoxes[i].Checked = paresTT[i].cb.Checked;
                }
            }

        }

        //Registrar NumericUpAndDown's locales de esta instancia en el array
        public void RegistrarNUDs()
        {

            numerics = new NumericUpDown[9];
            numerics[0] = numPlateaAlta;
            numerics[1] = numPlateaBaja;
            numerics[2] = numVip;
            numerics[3] = numCampo;
            numerics[4] = numCampoVip;
            numerics[5] = numPullman;
            numerics[6] = numSuperPullman;
            numerics[7] = numCabecera;
            numerics[8] = numSinNumerar;

        }

        ////Registrar CheckBoxes locales de esta instancia en el array
        public void RegistrarCheckBoxes()
        {
            checkBoxes = new CheckBox[9];
            checkBoxes[0] = cbPlateaAlta;
            checkBoxes[1] = cbPlateaBaja;
            checkBoxes[2] = cbVip;
            checkBoxes[3] = cbCampo;
            checkBoxes[4] = cbCampoVip;
            checkBoxes[5] = cbPullman;
            checkBoxes[6] = cbSuperPullman;
            checkBoxes[7] = cbCabecera;
            checkBoxes[8] = cbSinNumerar;
        }

        //Crea el array de items posibles del ComboBox con los mismos; seran cargados a su lista de Items
        //recién a medida que se vayan tildando los CheckBoxes necesarios; los vengo a buscar aca
        public void RegistrarItemsCombo()
        {
            itemsComboTipo = new ItemCombo[9];
            itemsComboTipo[0] = new ItemCombo("Platea Alta", 4446);
            itemsComboTipo[1] = new ItemCombo("Platea Baja", 4447);
            itemsComboTipo[2] = new ItemCombo("VIP", 4448);
            itemsComboTipo[3] = new ItemCombo("Campo", 4449);
            itemsComboTipo[4] = new ItemCombo("Campo VIP", 4450);
            itemsComboTipo[5] = new ItemCombo("Pullman", 4451);
            itemsComboTipo[6] = new ItemCombo("Super Pullman", 4452);
            itemsComboTipo[7] = new ItemCombo("Cabecera", 4453);
            itemsComboTipo[8] = new ItemCombo("Sin Numerar", 4454);
            //Seteo el nombre a mostrar y el valor intrinseco de los items del ComboBox, en base a atributos de la clase
            comboTipo.DisplayMember = "Nombre";
            comboTipo.ValueMember = "Id";
        }

        //Accion a realizar al tildar un checkbox, para mantener actualizados los componentes correspondientes
        private void HabilitarTipo(int indice)
        {
            //Primero activo el NUD asociado a ese tipo local a esta instancia
            numerics[indice].ReadOnly = false;
            numerics[indice].Controls[0].Visible = true;
            //Agrego el tipo (su nombre y su valor, el ID en la base de datos) a los items del ComboBox de tipos
            comboTipo.Items.Add(itemsComboTipo[indice]);
            //Guardo los cambios y lo registro en el array de pares de esta instancia (para mantenerlo actualizado)
            paresTT[indice].cb.Checked = true;
            paresTT[indice].nud.ReadOnly = false;
            paresTT[indice].nud.Controls[0].Visible = true;
            //Guardo el valor del control en el array de pares, asi queda ahi
            paresTT[indice].nud.Value = numerics[indice].Value;
        }

        //Accion a realizar al destildar un checkbox, para mantener actualizados los componentes correspondientes
        private void InhabilitarTipo(int indice)
        {
            //Primero desactivo el NUD asociado a ese tipo local a esta instancia
            numerics[indice].ReadOnly = true;
            numerics[indice].Controls[0].Visible = false;
            //Remuevo el tipo (su nombre y su valor, el ID en la base de datos) de los items del ComboBox de tipos
            comboTipo.Items.Remove(itemsComboTipo[indice]);
            //Guardo los cambios y lo registro en el array de pares de esta instancia (para mantenerlo actualizado)
            paresTT[indice].cb.Checked = false;
            paresTT[indice].nud.ReadOnly = true;
            paresTT[indice].nud.Controls[0].Visible = false;
            //Borro todas las ubicaciones del tipo inhabilitado. Rehabilitarlo no las hara reaparecer
            EliminarUbicacionesDeTipo(indice);
            //El valor del NUD lo dejo como estaba, total si no esta habilitado no me cambia en nada
        }

        private void ActualizarDatosDGV()
        {
            ubicacionesBinding = new BindingList<Ubicacion>(ubicacionesIngresadas);
            ubicacionesSource = new BindingSource(ubicacionesBinding, null);
            dgvUbicacionesElegidas.DataSource = ubicacionesSource;
            //Uso las tres columnas, les pongo nombre y un tamaño autoajustable
            dgvUbicacionesElegidas.Columns[3].Visible = false;
            dgvUbicacionesElegidas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvUbicacionesElegidas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvUbicacionesElegidas.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        #endregion Inicializacion

        #region ValidacionUbicaciones

        //Me devuelve la ubicacion en la fila y el asiento especificados, o bien NULL si no existe entre las ingresadas
        private Ubicacion UbicacionExistente(string fila, string asiento)
        {
            Ubicacion hallada = ubicacionesIngresadas.Find(u => (u.Fila.Equals(fila)) && (u.Asiento.Equals(asiento)));
            return hallada;
        }

        private void EliminarUbicacionesDeTipo(int indiceTipo)
        {
            //Le sumo 4446 a indice ya que hay una cierta correspondencia: Platea Alta = 0, 4446; Platea Baja = 1, 4447; ...
            ubicacionesIngresadas.RemoveAll(u => (u.TipoId == (indiceTipo + 4446)));
            ActualizarDatosDGV();
        }

        #endregion ValidacionUbicaciones

        #region Eventos

        private void cbPlateaAlta_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPlateaAlta.Checked == true)
            {
                HabilitarTipo(0);
            }
            else
            {
                InhabilitarTipo(0);
            }
        }

        private void cbPlateaBaja_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPlateaBaja.Checked == true)
            {
                HabilitarTipo(1);
            }
            else
            {
                InhabilitarTipo(1);
            }
        }

        private void cbVip_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVip.Checked == true)
            {
                HabilitarTipo(2);
            }
            else
            {
                InhabilitarTipo(2);
            }
        }

        private void cbCampo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCampo.Checked == true)
            {
                HabilitarTipo(3);
            }
            else
            {
                InhabilitarTipo(3);
            }
        }

        private void cbCampoVip_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCampoVip.Checked == true)
            {
                HabilitarTipo(4);
            }
            else
            {
                InhabilitarTipo(4);
            }
        }

        private void cbPullman_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPullman.Checked == true)
            {
                HabilitarTipo(5);
            }
            else
            {
                InhabilitarTipo(5);
            }
        }

        private void cbSuperPullman_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSuperPullman.Checked == true)
            {
                HabilitarTipo(6);
            }
            else
            {
                InhabilitarTipo(6);
            }
        }

        private void cbCabecera_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCabecera.Checked == true)
            {
                HabilitarTipo(7);
            }
            else
            {
                InhabilitarTipo(7);
            }
        }

        private void cbSinNumerar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSinNumerar.Checked == true)
            {
                HabilitarTipo(8);
            }
            else
            {
                InhabilitarTipo(8);
            }
        }

        private void numPlateaAlta_ValueChanged(object sender, EventArgs e)
        {
            paresTT[0].nud.Value = numPlateaAlta.Value;
        }

        private void numPlateaBaja_ValueChanged(object sender, EventArgs e)
        {
            paresTT[1].nud.Value = numPlateaBaja.Value;
        }

        private void numVip_ValueChanged(object sender, EventArgs e)
        {
            paresTT[2].nud.Value = numVip.Value;
        }

        private void numCampo_ValueChanged(object sender, EventArgs e)
        {
            paresTT[3].nud.Value = numCampo.Value;
        }

        private void numCampoVip_ValueChanged(object sender, EventArgs e)
        {
            paresTT[4].nud.Value = numCampoVip.Value;
        }

        private void numPullman_ValueChanged(object sender, EventArgs e)
        {
            paresTT[5].nud.Value = numPullman.Value;
        }

        private void numSuperPullman_ValueChanged(object sender, EventArgs e)
        {
            paresTT[6].nud.Value = numSuperPullman.Value;
        }

        private void numCabecera_ValueChanged(object sender, EventArgs e)
        {
            paresTT[7].nud.Value = numCabecera.Value;
        }

        private void numSinNumerar_ValueChanged(object sender, EventArgs e)
        {
            paresTT[8].nud.Value = numSinNumerar.Value;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            //Primero, limpio el EP para que no queden rastros de errores anteriores (no haya dobles errores)
            errorProvider.Clear();
            //Luego, manejo cada error
            if (comboTipo.SelectedIndex < 0)
            {
                errorProvider.SetError(comboTipo, "Debe especificar un tipo");
                return;
            }
            if (((ItemCombo)comboTipo.SelectedItem).Id == 4454)
            {
                if (!(string.IsNullOrWhiteSpace(tbAsiento.Text)) || !(string.IsNullOrWhiteSpace(tbFila.Text)))
                {
                    errorProvider.SetError(comboTipo, "Una ubicacion del tipo Sin Numerar no puede poseer fila ni asiento");
                    return;
                }
            }
            else
            {
                if ((string.IsNullOrWhiteSpace(tbFila.Text)))
                {
                    errorProvider.SetError(tbFila, "Debe especificar una fila");
                    return;
                }
                if ((string.IsNullOrWhiteSpace(tbAsiento.Text)))
                {
                    errorProvider.SetError(tbAsiento, "Debe especificar un asiento");
                    return;
                }
                if (UbicacionExistente(tbFila.Text, tbAsiento.Text) != null)
                {
                    errorProvider.SetError(dgvUbicacionesElegidas, "Ya existe una ubicacion en esa fila y ese asiento");
                    return;
                }
            }

            //Como obtener nombre e id del tipo de ubicacion
            MessageBox.Show(comboTipo.SelectedItem.ToString());
            MessageBox.Show(((ItemCombo)comboTipo.SelectedItem).Id.ToString());

            //Creo la ubicacion elegida y la agrego a la lista
            Ubicacion nuevaUbicacion = new Ubicacion(tbFila.Text, tbAsiento.Text,
                                                     comboTipo.SelectedItem.ToString(),         //Nombre del tipo
                                                     ((ItemCombo)comboTipo.SelectedItem).Id);   //Id intrinseca del tipo

            ubicacionesIngresadas.Add(nuevaUbicacion);
            ActualizarDatosDGV();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            //Primero, limpio el EP para que no queden rastros de errores anteriores (no haya dobles errores)
            errorProvider.Clear();
            //Luego, manejo los errores
            if ((string.IsNullOrWhiteSpace(tbFila.Text)))
            {
                errorProvider.SetError(tbFila, "Debe especificar una fila");
                return;
            }
            if ((string.IsNullOrWhiteSpace(tbAsiento.Text)))
            {
                errorProvider.SetError(tbAsiento, "Debe especificar un asiento");
                return;
            }

            //Me fijo si la ubicacion a eliminar existe o no; si no es asi, no puedo eliminar
            bool hallado;
            hallado = ubicacionesIngresadas.Exists(u => u.Fila.Equals(tbFila.Text) && u.Asiento.Equals(tbAsiento.Text));

            if (!hallado)
            {
                errorProvider.SetError(dgvUbicacionesElegidas, "No existe la ubicacion, no se puede eliminar");
                return;
            }

            //Es un RemoveAll solo para poder pasarle una lambda, pero deberia borrar un solo objeto
            ubicacionesIngresadas.RemoveAll(u => u.Fila.Equals(tbFila.Text) && u.Asiento.Equals(tbAsiento.Text));
            ActualizarDatosDGV();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Eventos
    }

}
