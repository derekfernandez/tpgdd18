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

namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class comisiones: Form
    {
        DateTime fechaConfig;

        public comisiones()
        {
            InitializeComponent();
            label4.Visible = false;
            fechaConfig = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comisiones_Load(object sender, EventArgs e)
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
           
            
            if(table.Rows.Count == 0)
            {
                numericUpDown1.Enabled = false;
                button2.Enabled = false;
                label4.Visible = true;
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string empresa = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (Int32.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()) > numericUpDown1.Value)
            {
                MessageBox.Show("El numero de facturas a rendir es mayor que el real. Ingrese un valor valido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand query2 = Database.createQuery(@"SELECT TOP 1 numero_factura FROM SQLITO.Facturas ORDER BY numero_factura DESC");
                string lastNumberOfFactura = Database.getValue(query2);
                int lastNumberFactura = Int32.Parse(lastNumberOfFactura) + 1;

                SqlCommand query3 = Database.createQuery(@"INSERT INTO SQLITO.ItemsFactura (factura_id, compra_id, comision)
                                                            SELECT TOP @tope @IdFactura, id_compra,((C.valor_entrada * P.comision) / 100)
                                                            FROM SQLITO.Compras AS C
                                                             JOIN SQLITO.Ubicaciones AS U ON C.Ubicacion_id = U.id_ubicacion
                                                             JOIN SQLITO.Publicaciones AS P ON U.publicacion_id = P.cod_publicacion
                                                            WHERE P.empresa_id = @idEmpresaElegida AND C.id_compra NOT IN (SELECT I.compra_id
                                                                                                                            FROM SQLITO.ItemsFactura AS I)
                                                            ORDER BY C.fecha_realizacion");
                query2.Parameters.AddWithValue("@tope",numericUpDown1.Value.ToString());
                query2.Parameters.AddWithValue("@IdFactura", lastNumberOfFactura);
                query2.Parameters.AddWithValue("@idEmpresaElegida", empresa);
                Database.execQuery(query2);
                SqlCommand query4 = Database.createQuery("SELECT SUM(comision) FROM SQLITO.ItemsFactura WHERE factura_id = @IdFactura");
                query4.Parameters.AddWithValue("@IdFactura", lastNumberFactura);
                string comision = Database.getValue(query4);
                SqlCommand query5 = Database.createQuery(@"INSERT INTO SQLITO.Facturas (fecha_emision,total,empresa_id,medio_pago)
                                                           VALUES (@fecha,@totalFactura,@idEmpresaElegida,'Efectivo')");
                query2.Parameters.AddWithValue("@fecha", fechaConfig);
                query2.Parameters.AddWithValue("@totalFactura", comision);
                query2.Parameters.AddWithValue("@idEmpresaElegida", empresa);
                Database.execQuery(query5);

            }
        }
    }

}
