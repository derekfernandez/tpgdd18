using PalcoNet.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Comprar
{
    public partial class RegistrarTarjeta : Form
    {

        private String idCliente;
        ErrorProvider errorProvider;
        //Booleano para saber si la tarjeta fue registrada o no; en caso de que el cliente toque 'X' y no registre una
        //No deberia permitirle realizar una compra hasta no registrar bien una tarjeta
        public bool targetaRegistrada { get; set; }
        public String idTarjeta { get; set; }
        
        public RegistrarTarjeta(String idCliente)
        {
            
            InitializeComponent();

            errorProvider = new ErrorProvider();
            this.idCliente = idCliente;
            //Que arranque en false, y se ponga en true solo si se registra una satisfactoriamente
            targetaRegistrada = false;

            tbNumero.MaxLength = 16;
            tbCodigo.MaxLength = 3;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbTitular.Text = "";
            tbNumero.Text = "";
            tbBanco.Text = "";
            tbCodigo.Text = "";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            #region ManejoErrores

            errorProvider.Clear();
            long numErroneo;
            int codErroneo;

            if (string.IsNullOrWhiteSpace(tbNumero.Text))
            {
                errorProvider.SetError(tbNumero, "Por favor, ingrese un numero de tarjeta");
                return;
            }
            if (tbNumero.TextLength < 16)
            {
                errorProvider.SetError(tbNumero, "Numero de tarjeta no valido. Debe ser de 16 digitos");
                return;
            }
            if (!Int64.TryParse(tbNumero.Text, out numErroneo))
            {
                errorProvider.SetError(tbNumero, "Numero de tarjeta no valido. Solo puede contener numeros");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbTitular.Text))
            {
                errorProvider.SetError(tbTitular, "Por favor, ingrese el nombre del titular de la tarjeta");
                return;
            }
            if(!tbTitular.Text.All(c => Char.IsLetter(c) || Char.IsWhiteSpace(c)))
            {
                errorProvider.SetError(tbTitular, "Nombre de titular invalido. Solo puede ingresar letras y espacios");
                return;
            }
            if (tbCodigo.TextLength < 3)
            {
                errorProvider.SetError(tbCodigo, "Codigo de seguridad invalido. Debe ser de 3 digitos");
                return;
            }
            if (!Int32.TryParse(tbCodigo.Text, out codErroneo))
            {
                errorProvider.SetError(tbCodigo, "Codigo de seguridad invalido. Solo puede contener numeros");
                return;
            }

            //Me fijo que no exista ninguna tarjeta con el mismo numero
            String queryValidacion = "SELECT id_tarjeta FROM SQLITO.Tarjetas WHERE numero_tarjeta = " + tbNumero.Text;
            SqlCommand cmdValidacion = Database.createQuery(queryValidacion);
            DataTable dt = Database.getTable(cmdValidacion);
            if (dt.Rows.Count > 0)
            {
                errorProvider.SetError(tbNumero, "Ya existe una tarjeta con ese numero; ingrese otra");
                return;
            }

            #endregion ManejoErrores

            #region ManejoCamposIncompletos

            String banco;

            if (string.IsNullOrWhiteSpace(tbBanco.Text))
            {
                banco = "NULL";
            }
            else
            {
                banco = tbBanco.Text;
            }

            #endregion ManejoCamposIncompletos

            #region PersistirTarjeta

            String queryInsert = "INSERT INTO SQLITO.Tarjetas (nombre_banco, nombre_titular, numero_tarjeta, cvv) VALUES";
            queryInsert += "(@Banco, @Titular, @Numero, @CVV)";
            SqlCommand cmdInsert = Database.createQuery(queryInsert);

            cmdInsert.Parameters.AddWithValue("@Banco", banco);
            cmdInsert.Parameters.AddWithValue("@Titular", tbTitular.Text);
            cmdInsert.Parameters.AddWithValue("@Numero", tbNumero.Text);
            cmdInsert.Parameters.AddWithValue("@CVV", tbCodigo.Text);

            Database.execQuery(cmdInsert);

            #endregion PersistirTarjeta

            #region ActualizarCliente

            //Busco el ID de la ultima tarjeta insertada, es el de la que cabo de persistir; me lo guardo en la variable local
            String queryId = "SELECT TOP 1 id_tarjeta FROM SQLITO.Tarjetas ORDER BY id_tarjeta DESC";
            SqlCommand cmdId = Database.createQuery(queryId);
            idTarjeta = Database.getValue(cmdId);

            //Por ultimo, actualizo al cliente en la base de datos, y le pongo la tarjeta recien ingresada
            String queryCliente = "UPDATE SQLITO.Clientes SET tarjeta_id = @TarjetaID WHERE id_cliente = @ClienteID";
            SqlCommand cmdCliente = Database.createQuery(queryCliente);
            cmdCliente.Parameters.AddWithValue("@TarjetaID", idTarjeta);
            cmdCliente.Parameters.AddWithValue("@ClienteID", idCliente);
            Database.execQuery(cmdCliente);

            #endregion ActualizarCliente

            targetaRegistrada = true;
            MessageBox.Show("Tarjeta registrada exitosamente! Compra realizada con exito");
            this.Close();

        }
    }
}
