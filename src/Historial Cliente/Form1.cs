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
        private int PgSize = 20;
        private int CurrentPageIndex = 0;
        private int TotalPage = 0;
        int PreviousPageOffSet = 0;

        public int cliente { get; set; }

        public historial(int clienteId)
        {
            this.cliente = clienteId;
        }

        public historial()
        {
            InitializeComponent();

        }
        private void CalculateTotalPages()
        {
            SqlCommand query = Database.createQuery("SELECT id_compra AS Numero, P.descripcion as Descripcion, asiento as Asiento, fila as Fila, valor_entrada as Valor,fecha_realizacion as FechaCompra, cantidad_entradas as Cantidad, ISNULL(cantidad_puntos,0) as Puntos FROM SQLITO.Compras JOIN SQLITO.Ubicaciones as U ON ubicacion_id = id_ubicacion JOIN SQLITO.Publicaciones AS P ON publicacion_id = P.cod_publicacion ORDER BY fecha_realizacion ASC ");
            int rowCount = Database.countRows(query);
            TotalPage = rowCount / PgSize;
            // if any row left after calculated pages, add one more page 
            if (rowCount % PgSize > 0)
                TotalPage += 1;
        }
        private DataTable GetCurrentRecords(int page)
        {
            SqlCommand cmd;
           if (page == 1)
            {
                cmd = Database.createQuery("SELECT TOP @page id_compra AS Numero, P.descripcion as Descripcion, asiento as Asiento, fila as Fila, valor_entrada as Valor,fecha_realizacion as FechaCompra, cantidad_entradas as Cantidad, ISNULL(cantidad_puntos,0) as Puntos FROM SQLITO.Compras JOIN SQLITO.Ubicaciones as U ON ubicacion_id = id_ubicacion JOIN SQLITO.Publicaciones AS P ON publicacion_id = P.cod_publicacion ORDER BY fecha_realizacion ASC ");
                cmd.Parameters.AddWithValue("@page", PgSize);
            }
           else
            {
                PreviousPageOffSet = (page - 1) * PgSize;
                cmd = Database.createQuery(@"SELECT TOP @page id_compra AS Numero," +
                    " P.descripcion as Descripcion, asiento as Asiento, fila as Fila, valor_entrada as Valor,fecha_realizacion as FechaCompra, cantidad_entradas as Cantidad, ISNULL(cantidad_puntos,0) as Puntos " +
                   "FROM SQLITO.Compras JOIN SQLITO.Ubicaciones as U ON ubicacion_id = id_ubicacion JOIN SQLITO.Publicaciones AS P ON publicacion_id = P.cod_publicacion " +
                    "WHERE id_compra NOT IN (SELECT TOP  @prev id_compra FROM SQLITO.Compras JOIN SQLITO.Ubicaciones ON ubicacion_id = id_ubicacion JOIN SQLITO.Publicaciones ON publicacion_id = cod_publicacion) ORDER BY fecha_realizacion ASC");
                cmd.Parameters.AddWithValue("@page", PgSize);
                cmd.Parameters.AddWithValue("@prev", PreviousPageOffSet);

            }

            return Database.getTable(cmd); 
        }


        private void historial_Load(object sender, EventArgs e)
        {
            SqlCommand query = Database.createQuery("SELECT id_compra AS Numero, P.descripcion as Descripcion, asiento as Asiento, fila as Fila, valor_entrada as Valor,fecha_realizacion as FechaCompra, cantidad_entradas as Cantidad, ISNULL(cantidad_puntos,0) as Puntos FROM SQLITO.Compras JOIN SQLITO.Ubicaciones as U ON ubicacion_id = id_ubicacion JOIN SQLITO.Publicaciones AS P ON publicacion_id = P.cod_publicacion WHERE cliente_id = @cliente ORDER BY fecha_realizacion ASC ");
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
            query.Parameters.AddWithValue("@cliente", this.cliente);
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
            this.dataGridView1.DataSource = Database.getTable(query);
            //Esto es para paginacion que todavia no funciona
            // this.dataGridView1.DataSource = GetCurrentRecords(this.CurrentPageIndex);
            button2.Visible = false;
            button3.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex > 1)
            {
                this.CurrentPageIndex--;
                this.dataGridView1.DataSource =
            GetCurrentRecords(this.CurrentPageIndex);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex < this.TotalPage)
            {
                this.CurrentPageIndex++;
                this.dataGridView1.DataSource =
            GetCurrentRecords(this.CurrentPageIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
