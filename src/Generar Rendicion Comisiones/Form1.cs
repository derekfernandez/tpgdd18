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

namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class comisiones: Form
    {
        public comisiones()
        {
            InitializeComponent();
            label4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comisiones_Load(object sender, EventArgs e)
        {
            llenarEmpresas(comboBox1);
            string option = comboBox1.SelectedValue.ToString();
            SqlCommand query = Database.createQuery(@"SELECT id_compra as NumeroCompra,cantidad_entradas as Cantidad, fecha_realizacion as Fecha, valor_entrada as Monto
                                                    FROM SQLITO.Empresas JOIN SQLITO.Publicaciones ON id_empresa=empresa_id
																		 JOIN SQLITO.Ubicaciones ON publicacion_id=cod_publicacion 
																		 JOIN SQLITO.Compras ON cod_publicacion=ubicacion_id
																		 JOIN SQLITO.ItemsFactura ON compra_id IS NULL
                                                                         WHERE id_empresa = @empresa
                                                                         GROUP BY id_compra,cantidad_entradas,fecha_realizacion,valor_entrada
                                                                         ORDER BY fecha_realizacion ASC");
            query.Parameters.AddWithValue("@empresa", option);
            DataTable table = Database.getTable(query);
            this.dataGridView1.DataSource = table; 
            if(table.Rows.Count == 0)
            {
                numericUpDown1.Enabled = false;
                button2.Enabled = false;
                label4.Visible = true;
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string option = comboBox1.SelectedValue.ToString();
            
        }
        public void llenarEmpresas(ComboBox cb)
        {
            SqlCommand query = Database.createQuery("SELECT id_empresa,razonsocial FROM SQLITO.Empresas ORDER BY razonSocial ASC");
            cb.DataSource = Database.getTable(query);
            cb.DisplayMember = "razonsocial";
            cb.ValueMember = "id_empresa";
        }
    }
}
