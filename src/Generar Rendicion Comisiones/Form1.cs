using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Misc;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class comisiones: Form
    {
        DateTime fechaConfig;

        public comisiones()
        {
            InitializeComponent();
            label4.Visible = false;
            fechaConfig = DateTime.Parse(ConfigurationManager.AppSettings["FechaSistema"]);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comisiones_Load(object sender, EventArgs e)
        {

            cargarRendicion();
            
            if(dataGridView1.Rows.Count == 0)
            {
                numericUpDown1.Enabled = false;
                button2.Enabled = false;
                label4.Visible = true;
            }
            

        }
        public void cargarRendicion()
        {
            SqlCommand query = Database.createQuery(@"SELECT id_empresa AS ID, razonsocial as Razon_Social, COUNT(*) as Cantidad
                                                      FROM SQLITO.Empresas as E
                                                       JOIN SQLITO.Publicaciones as P ON E.id_empresa=P.empresa_id
                                                       JOIN SQLITO.Ubicaciones AS U ON U.publicacion_id=P.cod_publicacion
                                                       JOIN SQLITO.Compras AS C ON C.ubicacion_id=U.id_ubicacion
                                                      WHERE C.id_compra NOT IN (SELECT I.compra_id FROM SQLITO.ItemsFactura AS I)
                                                      GROUP BY id_empresa, razonsocial");

            DataTable table = Database.getTable(query);
            this.dataGridView1.DataSource = table;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void button2_Click(object sender, EventArgs e)
        {
             string empresa = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (Int32.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()) < numericUpDown1.Value)
            {
                MessageBox.Show("El número de facturas a rendir es mayor que el real. Ingrese un valor válido!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(numericUpDown1.Value == 0)
            {
                MessageBox.Show("Ingrese un número de facturas a rendir mayor que 0", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //se busca el ultimo numero de factura 
                SqlCommand query2 = Database.createQuery(@"SELECT TOP 1 numero_factura FROM SQLITO.Facturas ORDER BY numero_factura DESC");
                string lastNumberOfFactura = Database.getValue(query2);
                int lastNumberFactura = Int32.Parse(lastNumberOfFactura) + 1;
                string numeroFacturaNuevo = lastNumberFactura.ToString();
                ////*************************************************************************//////////////////////////////////////
                //se crea la factura con valores aleatorios
                SqlCommand cmd = Database.createQuery(@"INSERT INTO SQLITO.Facturas (numero_factura,fecha_emision,total,empresa_id,medio_pago)
                                                           VALUES (@numeroFactura,@fecha,0,@idEmpresaElegida,'Efectivo')");
                cmd.Parameters.AddWithValue("@fecha", fechaConfig);
                cmd.Parameters.AddWithValue("@numeroFactura", numeroFacturaNuevo);
                cmd.Parameters.AddWithValue("@idEmpresaElegida", empresa);
                Database.execQuery(cmd);
                //Se insertan todos los items factura pertenecientes a la factura en cuestion
                SqlCommand query3 = Database.createQuery(@"INSERT INTO SQLITO.ItemsFactura (factura_id, compra_id, comision)
                                                            SELECT TOP (@tope) @numeroFactura, id_compra,((C.valor_entrada * P.publ_comision) / 100)
                                                            FROM SQLITO.Compras AS C
                                                             JOIN SQLITO.Ubicaciones AS U ON C.Ubicacion_id = U.id_ubicacion
                                                             JOIN SQLITO.Publicaciones AS P ON U.publicacion_id = P.cod_publicacion
                                                            WHERE P.empresa_id = @idEmpresaElegida AND C.id_compra NOT IN (SELECT I.compra_id
                                                                                                                            FROM SQLITO.ItemsFactura AS I)
                                                            ORDER BY C.fecha_realizacion");
                query3.Parameters.AddWithValue("@tope",Int32.Parse(numericUpDown1.Value.ToString()));
                query3.Parameters.AddWithValue("@numeroFactura", numeroFacturaNuevo);
                query3.Parameters.AddWithValue("@idEmpresaElegida", empresa);
                Database.execQuery(query3);
                //Se suman las comisiones de esa factura 
                SqlCommand query4 = Database.createQuery("SELECT SUM(comision) FROM SQLITO.ItemsFactura WHERE factura_id =@numeroFactura");
                query4.Parameters.AddWithValue("@numeroFactura", numeroFacturaNuevo);
                string comision = Database.getValue(query4);
                //Se updatean los campos para que la factura quede correctamente cargada
                SqlCommand query5 = Database.createQuery(@"Update SQLITO.Facturas set total = @comisionItemsFactura
                                                          WHERE numero_factura = @numeroFactura");
                query5.Parameters.AddWithValue("@comisionItemsFactura", float.Parse(comision, CultureInfo.InvariantCulture.NumberFormat));
                query5.Parameters.AddWithValue("@numeroFactura", numeroFacturaNuevo);
                Database.execQuery(query5);
                cargarRendicion();
                numericUpDown1.Value = 0;
                MessageBox.Show("Se efectuó la rendición correctamente!");

            }
        }
    }

}
