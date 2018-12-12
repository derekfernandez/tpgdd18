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

namespace PalcoNet.Historial_Cliente
{
    public partial class historial : Form
    {
        public int cliente { get; set; }

        public historial(int clienteId)
        {
            this.cliente = clienteId;
        }
        public historial()
        {
            InitializeComponent();
        }

        private void historial_Load(object sender, EventArgs e)
        {
            SqlCommand query = Database.createQuery("SELECT id_compra AS Numero, P.descripcion as Descripcion, asiento as Asiento, fila as Fila, valor_entrada as Valor,fecha_realizacion as FechaCompra, cantidad_entradas as Cantidad, ISNULL(cantidad_puntos,0) as Puntos FROM SQLITO.Compras JOIN SQLITO.Ubicaciones as U ON ubicacion_id = id_ubicacion JOIN SQLITO.Publicaciones AS P ON publicacion_id = P.cod_publicacion ");
            dataGridView1.DataSource = Database.getTable(query);
            
        }
    }
}
