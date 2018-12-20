using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using PalcoNet.Controllers;
using System.Security.Cryptography;


namespace PalcoNet.Misc
{
    class Database
    {
        #region Atributos

        private static String connectionString = ConfigurationManager.AppSettings["sqlConnection"].ToString();
        private static SqlConnection connection = new SqlConnection(connectionString);

        #endregion

        #region General

        public static SqlConnection getConnection()
        {
            return connection;
        }

        public static SqlCommand createQuery(string query)
        {
            return new SqlCommand(query, getConnection());
        }

        public static void abrir()
        {
            connection.Open(); 
        }
        public static void cerrar()
        {
            connection.Close();
        }

        public static void execQuery(SqlCommand query)
        {
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        public static void execNonQuery(SqlCommand cmd)
        {

            try
            {
                abrir();
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cerrar();
            }
                
        }

        public static SqlDataReader execDataReader(SqlCommand cmd)
        {
            abrir();
            SqlDataReader reader = cmd.ExecuteReader();
            cerrar();
            return reader;  
        }

        public static object getScalarValue(SqlCommand cmd)
        {
            abrir();
            object value = cmd.ExecuteScalar();
            cerrar();
            return value;
        }


        public static DataSet getDataSet(SqlCommand cmd)
        {
            DataSet dataSet = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataSet);

            return dataSet;
        }

        public static DataTable getTable(SqlCommand cmd)
        {
            DataSet dataSet = getDataSet(cmd);
            DataTable table = dataSet.Tables[0];

            return table;
        }

        public static List<string> getList(SqlCommand cmd)
        {
            DataTable table = getTable(cmd);
            List<string> lista = new List<string>();

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    lista.Add(row[0].ToString());
                }
            }

            return lista;
        }

        public static DataRow getRow(SqlCommand cmd)
        {
            DataTable table = getTable(cmd);
            if (table.Rows.Count > 0)
            {
                return table.Rows[0];
            }

            else return null;
        }

        public static string getValue(SqlCommand query)
        {
            List<string> lista = getList(query);

            if (lista.Count > 0)
            {
                return lista[0];
            }

            else
            {
                return "";
            }
        }
        public static int countRows(SqlCommand cmd)
        {
            int cantRows = getTable(cmd).Rows.Count;
            return cantRows;
         
        }

        #endregion

        #region Metodos Simplificados / Genericos 

        /*Agregado Agus: 
        -Unifico metodos para llamadas mas simples.
        -Agrego getListaGenerica
        -Agrego una funcion que obtiene un valor usando ExecuteScalar
         */

        //Querys tipo update, insert, delete, o llamadas a proc que no devuelvan tablas
        public static void ejecutarNonQueryShort(string query)
        {
            
            Database.execNonQuery(Database.createQuery(query));  
            
        }
        
        public static void ejecutarProc(string query)
        {
            int filasAfectadas = 0;
            abrir();
            try
            {
                SqlCommand comando = new SqlCommand(query, connection);


                filasAfectadas = comando.ExecuteNonQuery();


                if (filasAfectadas == 0)
                {
                    throw new Exception("0 filas afectadas");
                }
            }

            catch (Exception)
            {
                throw;
            }

            finally 
            {
                cerrar();
            }
                

          }
        
        //obtiene un DS con la query simplemente
        public static DataSet ObtenerDataSet(string query)
        {
            DataSet dataSet = new DataSet();
            
            SqlDataAdapter adapter = new SqlDataAdapter(query,connection);
            adapter.Fill(dataSet);
            
            return dataSet;
        }


        //Reemplaza a getValue
        public static T ejecutarExecuteScalar<T>(string query)
        {
            abrir();
            T variable = (T)(Database.createQuery(query)).ExecuteScalar();
            cerrar();
            return variable;
        }

        public static List<T> getListaGenerica<T>(SqlCommand cmd)
        {
            DataTable table = getTable(cmd);
            List<T> lista = new List<T>();

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    lista.Add((T)row[0]);
                }
            }

            return lista;
        }
 
        #endregion

        #region Auxiliares

        public static byte[] encriptarPassword(string pw)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding encoder = Encoding.UTF8;
                return hash.ComputeHash(encoder.GetBytes(pw));
            }
        }

        public static Boolean cuilDuplicado(string cuil)
        {
            SqlCommand sql = createQuery("SELECT COUNT(*) FROM SQLITO.Clientes WHERE cuil = @cuil");
            sql.Parameters.AddWithValue("@cuil", cuil);
            return (Convert.ToInt32(getValue(sql)) != 0);
        }

        public static Boolean cuitDuplicado(string cuit)
        {
            SqlCommand sql = createQuery("SELECT COUNT(*) FROM SQLITO.Empresas WHERE cuit = @cuit");
            sql.Parameters.AddWithValue("@cuit", cuit);
            return (Convert.ToInt32(getValue(sql)) != 0);
        }

        #endregion

        #region Login

        public static LoginController checkLogin(string username, string pw)
        {
            SqlCommand query = createQuery(@"SELECT username, password, intentos_fallidos, habilitado
                FROM SQLITO.Usuarios WHERE username = @username");
            query.Parameters.AddWithValue("@username", username);
            DataRow row = getRow(query);

            if (row != null)
            {
                return checkAcc(row, pw);
            }

            else return userNotFound();
        }

        public static LoginController checkAcc(DataRow row, string pw)
        {
            string username = (string)row["username"];
            byte[] encryptedPassword = (byte[])row["password"];
            int intentos = (int)row["intentos_fallidos"];

            Usuario user = new Usuario(username);

            if (intentos >= 3 || estaInhabilitado(user))
            {
                return blockedAcc(user, intentos);
            }

            else return checkPassword(username, pw, encryptedPassword, intentos);
        }

        public static LoginController userNotFound()
        {
            return new LoginController().sendNotFoundMsg();
        }

        public static LoginController blockedAcc(Usuario user, int retries)
        {
            return new LoginController().sendBlockMsg();
        }

        public static LoginController checkPassword(string username, string pw, byte[] encryptedPassword, int retries)
        {
            byte[] hash = encriptarPassword(pw);

            if (hash.SequenceEqual(encryptedPassword))
            {
                return loginCorrecto(new Usuario(username));
            }

            else
            {
                retries = retries + 1;
                SqlCommand update = createQuery("UPDATE SQLITO.Usuarios SET intentos_fallidos = @intentos WHERE username = @username");
                update.Parameters.AddWithValue("@username",username);
                update.Parameters.AddWithValue("@intentos", retries);

                execNonQuery(update);

                if (retries >= 3)
                {
                    blockUser(new Usuario(username));
                    return new LoginController().sendBlockMsg();
                }

                else return new LoginController().sendPasswordMatchingFailure();
            }
        }

        public static LoginController loginCorrecto(Usuario user)
        {
            SqlCommand update = createQuery("UPDATE SQLITO.Usuarios SET intentos_fallidos = 0 WHERE username = @username");
            update.Parameters.AddWithValue("@username", user.username);
            execNonQuery(update);

            return new LoginController().succeed(user.username);
        }

        #endregion

        #region User

        public static byte[] getPasswordFor(Usuario usuario)
        {
            SqlCommand query = createQuery("SELECT password FROM SQLITO.Usuarios WHERE username = @username");
            query.Parameters.AddWithValue("@username", usuario.username);
            return Encoding.UTF8.GetBytes(getValue(query));
        }

        public static string getIDFor(Usuario user)
        {
            SqlCommand query = createQuery("SELECT id_usuario FROM SQLITO.Usuarios WHERE username = @username");
            query.Parameters.AddWithValue("@username", user.username);
            return getValue(query);
        }

        public static List<string> getRolesFor(Usuario user)
        {
            SqlCommand query = createQuery(@"SELECT descripcion FROM SQLITO.Roles r JOIN SQLITO.Roles_Usuarios ru 
                    ON r.id_rol = ru.rol_id JOIN SQLITO.Usuarios u ON u.id_usuario = ru.usuario_id
                    WHERE username = @username");
            query.Parameters.AddWithValue("@username", user.username);
            return getList(query);
        }

        public static void blockUser(Usuario user)
        {
            SqlCommand update = createQuery("UPDATE SQLITO.Usuarios SET habilitado = 0 WHERE username = @username");
            update.Parameters.AddWithValue("@username", user.username);
            execNonQuery(update);
            String query = getIdPorUsername(user);
            SqlCommand query2 = createQuery("SELECT id_cliente FROM SQLITO.Clientes WHERE usuario_id = @id");
            query2.Parameters.AddWithValue("@id", query);
            String res = getValue(query2);
            SqlCommand query3 = createQuery("UPDATE SQLITO.Clientes SET estado = 0 WHERE id_cliente = @res");
            query3.Parameters.AddWithValue("@res", res);
            execNonQuery(query3);
        }

        public static bool estaInhabilitado(Usuario user)
        {
            SqlCommand query = createQuery("SELECT habilitado FROM SQLITO.Usuarios WHERE username = @username");
            query.Parameters.AddWithValue("@username", user.username);

            var temp = bool.Parse(getValue(query));

            if(temp)
            {
              return false;
            }

            else return true;
        }

        public static Boolean userExiste(string username)
        {
            SqlCommand query = createQuery("SELECT COUNT(*) FROM SQLITO.Usuarios WHERE username = @username");
            query.Parameters.AddWithValue("@username", username);
            return (Convert.ToInt32(getValue(query)) != 0);
        }

        public static void guardarUsuario(Usuario user)
        {
            SqlCommand query = createQuery("INSERT INTO SQLITO.Usuarios VALUES(@username,@password,0,1,1)");
            query.Parameters.AddWithValue("@username", user.username);
            query.Parameters.AddWithValue("@password", encriptarPassword(user.password));
            execNonQuery(query);
        }

        public static void guardarUsuarioAdmin(Usuario user)
        {
            SqlCommand query = createQuery("INSERT INTO SQLITO.Usuarios VALUES(@username,@password,0,1,0)");
            query.Parameters.AddWithValue("@username", user.username);
            query.Parameters.AddWithValue("@password", encriptarPassword(user.password));
            execNonQuery(query);
        }

        public static string ultimoIdAlmacenado()
        {
            SqlCommand query = createQuery("SELECT TOP 1 id_usuario FROM SQLITO.Usuarios ORDER BY 1 DESC");
            var parcial = Int32.Parse(getValue(query)) + 1;
            return parcial.ToString();
        }

        public static Boolean tieneContraseniaActivada(Usuario user)
        {
            SqlCommand sql = createQuery("SELECT contraseniaActivada FROM SQLITO.Usuarios WHERE username = @usr");
            sql.Parameters.AddWithValue("@usr", user.username);
            var ret = Boolean.Parse(getValue(sql));

            if (ret)
            {
                return true;
            }

            else return false;
        }

        public static void actualizarCliente(Cliente cliente)
        {
            SqlCommand query = createQuery(@"UPDATE SQLITO.Clientes SET nombre = @nom, apellido = @ap, cuil = @cuil, tipo_documento = @tipodoc,
                numero_documento = @nrodoc, fecha_nacimiento = @fecha_nac, fecha_creacion = @fecha_creacion, mail = @mail, direccion = @direccion,
                telefono = @tel, tarjeta_id = @idtarjeta, usuario_id = @iduser, estado = @estado WHERE id_cliente = @idcliente");
            query.Parameters.AddWithValue("@nom", cliente.nombre);
            query.Parameters.AddWithValue("@ap", cliente.apellido);
            query.Parameters.AddWithValue("@cuil", cliente.cuil);
            query.Parameters.AddWithValue("@tipodoc", cliente.tipo_doc);
            query.Parameters.AddWithValue("@nrodoc", cliente.nro_doc);
            query.Parameters.AddWithValue("@fecha_nac", DateTime.Parse(cliente.fecha_nac));
            query.Parameters.AddWithValue("@fecha_creacion", DateTime.Parse(cliente.fecha_creacion));
            query.Parameters.AddWithValue("@mail", cliente.mail);
            query.Parameters.AddWithValue("@direccion", cliente.direccion);
            query.Parameters.AddWithValue("@tel", cliente.tel);
            query.Parameters.AddWithValue("@idtarjeta", cliente.idtarjeta);
            query.Parameters.AddWithValue("@iduser", cliente.iduser);
            query.Parameters.AddWithValue("@estado", cliente.estado);
            query.Parameters.AddWithValue("@idcliente", cliente.id);
            execQuery(query);
        }

        #endregion

        #region Tarjeta

        public static Boolean clienteTieneTarjeta(Cliente cliente)
        {
            SqlCommand q = createQuery("SELECT tarjeta_id FROM SQLITO.Clientes WHERE id_cliente = @id");
            q.Parameters.AddWithValue("@id", cliente.id);
            if (getValue(q) != string.Empty)
            {
                return true;
            }

            else return false;
        }

        public static void guardarTarjeta(Tarjeta tarjeta)
        {
            SqlCommand query = createQuery(@"INSERT INTO SQLITO.Tarjetas (nombre_banco,nombre_titular,numero_tarjeta,cvv)
                    VALUES(@banco, @titular, @num, @cvv)");
            query.Parameters.AddWithValue("@banco", tarjeta.banco);
            query.Parameters.AddWithValue("@titular", tarjeta.titular);
            query.Parameters.AddWithValue("@num", tarjeta.nro);
            query.Parameters.AddWithValue("@cvv", tarjeta.cvv);
            execQuery(query);
        }

        public static void actualizarTarjeta(Tarjeta tarjeta)
        {
            SqlCommand query = createQuery(@"UPDATE SQLITO.Tarjetas SET nombre_banco = @banco, nombre_titular = @titular,
                numero_tarjeta = @num, cvv = @cvv WHERE id_tarjeta = @idtarjeta");
            query.Parameters.AddWithValue("@banco", tarjeta.banco);
            query.Parameters.AddWithValue("@titular", tarjeta.titular);
            query.Parameters.AddWithValue("@num", tarjeta.nro);
            query.Parameters.AddWithValue("@cvv", tarjeta.cvv);
            query.Parameters.AddWithValue("@idtarjeta", tarjeta.id);
            execNonQuery(query);
        }

        public static string getTarjetaPorNumero(string nro)
        {
            SqlCommand query = createQuery("SELECT id_tarjeta FROM SQLITO.Tarjetas WHERE numero_tarjeta = @nro");
            query.Parameters.AddWithValue("@nro", nro);
            return getValue(query);
        }

        #endregion

        #region Clientes

        public static Boolean documentoRepetido(string tipodoc, string nrodoc)
        {
            SqlCommand sql = createQuery("SELECT COUNT(*) FROM SQLITO.Clientes WHERE tipo_documento = @tipodoc AND numero_documento = @nrodoc");
            sql.Parameters.AddWithValue("@tipodoc", tipodoc);
            sql.Parameters.AddWithValue("@nrodoc", nrodoc);
            return (Convert.ToInt32(getValue(sql)) != 0);
        }

        public static string getIdPorUsuario(Usuario user)
        {
            SqlCommand sql = createQuery("SELECT id_cliente FROM SQLITO.Clientes WHERE usuario_id = @user");
            sql.Parameters.AddWithValue("@user", user.id);
            return getValue(sql);
        }

        public static string getIdPorUsername(Usuario user)
        {
            SqlCommand sql = createQuery("SELECT id_usuario FROM SQLITO.Usuarios WHERE username = @user");
            sql.Parameters.AddWithValue("@user", user.username);
            return getValue(sql);
        }

        public static void guardarCliente(Cliente cliente)
        { 
            SqlCommand query = createQuery(@"INSERT INTO SQLITO.Clientes VALUES(@nom, @ap, @cuil, @tipodoc, @nrodoc, @fecha_nac,
                 @fecha_creacion, @mail, @direccion, @tel, @id_tarjeta, @id_user, 1, 0)");
            query.Parameters.AddWithValue("@nom", cliente.nombre);
            query.Parameters.AddWithValue("@ap", cliente.apellido);
            query.Parameters.AddWithValue("@cuil", cliente.cuil);
            query.Parameters.AddWithValue("@tipodoc", cliente.tipo_doc);
            query.Parameters.AddWithValue("@nrodoc", cliente.nro_doc);
            query.Parameters.AddWithValue("@fecha_nac", DateTime.Parse(cliente.fecha_nac));
            query.Parameters.AddWithValue("@fecha_creacion", DateTime.Parse(cliente.fecha_creacion));
            query.Parameters.AddWithValue("@mail", cliente.mail);
            query.Parameters.AddWithValue("@direccion", cliente.direccion);
            query.Parameters.AddWithValue("@tel", cliente.tel);
            query.Parameters.AddWithValue("@id_tarjeta", cliente.idtarjeta);
            query.Parameters.AddWithValue("@id_user", cliente.iduser);
            execNonQuery(query);
        }

        public static void habilitarCliente(Cliente cliente)
        {
            SqlCommand query = createQuery("UPDATE SQLITO.Clientes SET estado = 1 WHERE id_cliente = @id");
            query.Parameters.AddWithValue("@id", cliente.id);
            execNonQuery(query);
            SqlCommand query2 = createQuery("SELECT usuario_id FROM SQLITO.Clientes WHERE id_cliente = @idd");
            query2.Parameters.AddWithValue("@idd", cliente.id);
            String res = getValue(query2);
            SqlCommand query3 = createQuery("UPDATE SQLITO.Usuarios SET habilitado = 1, intentos_fallidos = 0 WHERE id_usuario = @res");
            query3.Parameters.AddWithValue("@res", res);
            execNonQuery(query3);
        }

        public static DataRow getTarjetaDeCliente(Cliente cliente)
        {
            SqlCommand query = createQuery("SELECT * FROM SQLITO.Tarjetas WHERE id_tarjeta = @id");
            query.Parameters.AddWithValue("@id", cliente.idtarjeta);
            return getRow(query);
        }

        public static DataTable getClientesPorNombre(string nombre)
        {
            SqlCommand query = createQuery("SELECT * FROM SQLITO.Clientes WHERE nombre LIKE '%' + @nombre + '%' AND nombre != 'Admin' ORDER BY nombre");
            query.Parameters.AddWithValue("@nombre",nombre);
            return getTable(query);
        }

        public static DataTable getClientesPorApellido(string apellido)
        {
            SqlCommand query = createQuery("SELECT * FROM SQLITO.Clientes WHERE apellido LIKE '%' + @apellido + '%' AND nombre != 'Admin' ORDER BY apellido");
            query.Parameters.AddWithValue("@apellido",apellido);
            return getTable(query);
        }

        public static DataTable getClientesPorNroDoc(string nrodoc)
        {
            SqlCommand query = createQuery("SELECT * FROM SQLITO.Clientes WHERE numero_documento = @nrodoc AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nrodoc", nrodoc);
            return getTable(query);
        }

        public static DataTable getClientesPorEmail(string email)
        {
            SqlCommand query = createQuery("SELECT * FROM SQLITO.Clientes WHERE mail LIKE '%' + @email + '%' AND nombre != 'Admin' ORDER BY mail");
            query.Parameters.AddWithValue("@email", email);
            return getTable(query);
        }

        public static DataTable getClientesPorNombre_Apellido(string nombre, string apellido)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE nombre LIKE '%' + @nom + '%' AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE apellido LIKE '%' + @ap + '%') AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nom", nombre);
            query.Parameters.AddWithValue("@ap", apellido);
            return getTable(query);
        }

        public static DataTable getClientesPorNombre_nroDoc(string nombre, string nrodoc)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE nombre LIKE '%' + @nom + '%' AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE numero_documento = @nrodoc) AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nom", nombre);
            query.Parameters.AddWithValue("@nrodoc", nrodoc);
            return getTable(query);
        }

        public static DataTable getClientesPorNombre_mail(string nombre, string mail)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE nombre LIKE '%' + @nom + '%' AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE mail LIKE '%' + @mail + '%') AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nom", nombre);
            query.Parameters.AddWithValue("@mail", mail);
            return getTable(query);
        }

        public static DataTable getClientesPorApellido_nroDoc(string apellido, string nrodoc)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE apellido LIKE '%' + @ap + '%' AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE numero_documento = @nrodoc) AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@ap", apellido);
            query.Parameters.AddWithValue("@nrodoc", nrodoc);
            return getTable(query);
        }

        public static DataTable getClientesPorApellido_mail(string apellido, string mail)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE apellido LIKE '%' + @ap + '%' AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE mail LIKE '%' + @mail + '%') AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@ap", apellido);
            query.Parameters.AddWithValue("@mail", mail);
            return getTable(query);
        }

        public static DataTable getClientesPorMail_nroDoc(string mail, string nrodoc)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE mail LIKE '%' + @mail + '%' AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE numero_documento = @nrodoc) AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@mail", mail);
            query.Parameters.AddWithValue("@nrodoc", nrodoc);
            return getTable(query);
        }

        public static DataTable getClientesPorNombre_apellido_nrodoc(string nombre, string apellido, string nrodoc)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE nombre LIKE '%' + @nom + '%' AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE apellido LIKE '%' + @ap + '%' AND numero_documento = @nrodoc) AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nom", nombre);
            query.Parameters.AddWithValue("@ap", apellido);
            query.Parameters.AddWithValue("@nrodoc", nrodoc);
            return getTable(query);
        }

        public static DataTable getClientesPorNombre_apellido_mail(string nombre, string apellido, string mail)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE nombre LIKE '%' + @nom + '%' AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE apellido LIKE '%' + @ap + '%' AND mail LIKE '%' + @mail + '%') AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nom", nombre);
            query.Parameters.AddWithValue("@ap", apellido);
            query.Parameters.AddWithValue("@mail", mail);
            return getTable(query);
        }

        public static DataTable getClientesPorNombre_nroDoc_mail(string nombre, string nrodoc, string mail)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE nombre LIKE '%' + @nom + '%' AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE mail LIKE '%' + @mail + '%' AND numero_documento = @nrodoc) AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nom", nombre);
            query.Parameters.AddWithValue("@nrodoc",nrodoc);
            query.Parameters.AddWithValue("@mail", mail);
            return getTable(query);
        }

        public static DataTable getClientesPorApellido_nroDoc_mail(string apellido, string nrodoc, string mail)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE apellido LIKE '%' + @ap + '%' AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE mail LIKE '%' + @mail + '%' AND numero_documento = @nrodoc) AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nrodoc",nrodoc);
            query.Parameters.AddWithValue("@ap", apellido);
            query.Parameters.AddWithValue("@mail", mail);
            return getTable(query);
        }

        public static DataTable getClientesPorNombre_apellido_nroDoc_mail(string nombre, string apellido, string nrodoc, string mail)
        { 
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE nombre LIKE '%' + @nom + '%' AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE apellido LIKE '%' + @ap + '%' AND mail LIKE '%' + @mail + '%' AND
                    numero_documento = @nrodoc) AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nom", nombre);
            query.Parameters.AddWithValue("@ap", apellido);
            query.Parameters.AddWithValue("@mail", mail);
            query.Parameters.AddWithValue("@nrodoc", nrodoc);
            return getTable(query);
        }

        public static DataTable getClientesHabilitadosPorNombre(string nombre)
        {
            SqlCommand query = createQuery("SELECT * FROM SQLITO.Clientes WHERE nombre LIKE '%' + @nombre + '%' AND estado = 1  AND nombre != 'Admin' ORDER BY nombre");
            query.Parameters.AddWithValue("@nombre", nombre);
            return getTable(query);
        }

        public static DataTable getClientesHabilitadosPorApellido(string apellido)
        {
            SqlCommand query = createQuery("SELECT * FROM SQLITO.Clientes WHERE apellido LIKE '%' + @apellido + '%' AND nombre != 'Admin' AND estado = 1 ORDER BY apellido");
            query.Parameters.AddWithValue("@apellido", apellido);
            return getTable(query);
        }

        public static DataTable getClientesHabilitadosPorNroDoc(string nrodoc)
        {
            SqlCommand query = createQuery("SELECT * FROM SQLITO.Clientes WHERE numero_documento = @nrodoc AND estado = 1  AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nrodoc", nrodoc);
            return getTable(query);
        }

        public static DataTable getClientesHabilitadosPorEmail(string email)
        {
            SqlCommand query = createQuery("SELECT * FROM SQLITO.Clientes WHERE mail LIKE '%' + @email + '%' AND estado = 1 AND nombre != 'Admin' ORDER BY mail");
            query.Parameters.AddWithValue("@email", email);
            return getTable(query);
        }

        public static DataTable getClientesHabilitadosPorNombre_Apellido(string nombre, string apellido)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE nombre LIKE '%' + @nom + '%' AND estado = 1 AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE apellido LIKE '%' + @ap + '%') AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nom", nombre);
            query.Parameters.AddWithValue("@ap", apellido);
            return getTable(query);
        }

        public static DataTable getClientesHabilitadosPorNombre_nroDoc(string nombre, string nrodoc)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE nombre LIKE '%' + @nom + '%' AND estado = 1 AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE numero_documento = @nrodoc) AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nom", nombre);
            query.Parameters.AddWithValue("@nrodoc", nrodoc);
            return getTable(query);
        }

        public static DataTable getClientesHabilitadosPorNombre_mail(string nombre, string mail)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE nombre LIKE '%' + @nom + '%' AND estado = 1 AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE mail LIKE '%' + @mail + '%') AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nom", nombre);
            query.Parameters.AddWithValue("@mail", mail);
            return getTable(query);
        }

        public static DataTable getClientesHabilitadosPorApellido_nroDoc(string apellido, string nrodoc)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE apellido LIKE '%' + @ap + '%' AND estado = 1 AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE numero_documento = @nrodoc) AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@ap", apellido);
            query.Parameters.AddWithValue("@nrodoc", nrodoc);
            return getTable(query);
        }

        public static DataTable getClientesHabilitadosPorApellido_mail(string apellido, string mail)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE apellido LIKE '%' + @ap + '%' AND estado = 1 AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE mail LIKE '%' + @mail + '%') AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@ap", apellido);
            query.Parameters.AddWithValue("@mail", mail);
            return getTable(query);
        }

        public static DataTable getClientesHabilitadosPorMail_nroDoc(string mail, string nrodoc)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE mail LIKE '%' + @mail + '%' AND estado = 1 AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE numero_documento = @nrodoc) AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@mail", mail);
            query.Parameters.AddWithValue("@nrodoc", nrodoc);
            return getTable(query);
        }

        public static DataTable getClientesHabilitadosPorNombre_apellido_nrodoc(string nombre, string apellido, string nrodoc)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE nombre LIKE '%' + @nom + '%' AND estado = 1 AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE apellido LIKE '%' + @ap + '%' AND numero_documento = @nrodoc) AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nom", nombre);
            query.Parameters.AddWithValue("@ap", apellido);
            query.Parameters.AddWithValue("@nrodoc", nrodoc);
            return getTable(query);
        }

        public static DataTable getClientesHabilitadosPorNombre_apellido_mail(string nombre, string apellido, string mail)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE nombre LIKE '%' + @nom + '%' AND estado = 1 AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE apellido LIKE '%' + @ap + '%' AND mail LIKE '%' + @mail + '%') AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nom", nombre);
            query.Parameters.AddWithValue("@ap", apellido);
            query.Parameters.AddWithValue("@mail", mail);
            return getTable(query);
        }

        public static DataTable getClientesHabilitadosPorNombre_nroDoc_mail(string nombre, string nrodoc, string mail)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE nombre LIKE '%' + @nom + '%' AND estado = 1 AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE mail LIKE '%' + @mail + '%' AND numero_documento = @nrodoc) AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nom", nombre);
            query.Parameters.AddWithValue("@nrodoc", nrodoc);
            query.Parameters.AddWithValue("@mail", mail);
            return getTable(query);
        }

        public static DataTable getClientesHabilitadosPorApellido_nroDoc_mail(string apellido, string nrodoc, string mail)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE apellido LIKE '%' + @ap + '%' AND estado = 1  AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE mail LIKE '%' + @mail + '%' AND numero_documento = @nrodoc) AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nrodoc", nrodoc);
            query.Parameters.AddWithValue("@ap", apellido);
            query.Parameters.AddWithValue("@mail", mail);
            return getTable(query);
        }

        public static DataTable getClientesHabilitadosPorNombre_apellido_nroDoc_mail(string nombre, string apellido, string nrodoc, string mail)
        {
            SqlCommand query = createQuery(@"SELECT * FROM SQLITO.Clientes WHERE nombre LIKE '%' + @nom + '%' AND estado = 1 AND id_cliente
                 IN (SELECT id_cliente FROM SQLITO.Clientes WHERE apellido LIKE '%' + @ap + '%' AND mail LIKE '%' + @mail + '%' AND
                    numero_documento = @nrodoc) AND nombre != 'Admin'");
            query.Parameters.AddWithValue("@nom", nombre);
            query.Parameters.AddWithValue("@ap", apellido);
            query.Parameters.AddWithValue("@mail", mail);
            query.Parameters.AddWithValue("@nrodoc", nrodoc);
            return getTable(query);
        }

        public static string getNroTarjeta(Cliente cliente)
        { 
            SqlCommand query = createQuery(@"SELECT numero_tarjeta FROM SQLITO.Tarjetas t JOIN SQLITO.Clientes c 
                                                ON t.id_tarjeta = c.tarjeta_id AND c.tarjeta_id = @id");
            query.Parameters.AddWithValue("@id", cliente.idtarjeta);
            return getValue(query);
        }

        public static string getCVVTarjeta(Cliente cliente)
        {
            SqlCommand query = createQuery(@"SELECT cvv FROM SQLITO.Tarjetas t JOIN SQLITO.Clientes c 
                                                ON t.id_tarjeta = c.tarjeta_id AND c.tarjeta_id = @id");
            query.Parameters.AddWithValue("@id", cliente.idtarjeta);
            return getValue(query);
        }

        public static string getBancoTarjeta(Cliente cliente)
        {
            SqlCommand query = createQuery(@"SELECT nombre_banco FROM SQLITO.Tarjetas t JOIN SQLITO.Clientes c 
                                                ON t.id_tarjeta = c.tarjeta_id AND c.tarjeta_id = @id");
            query.Parameters.AddWithValue("@id", cliente.idtarjeta);
            return getValue(query);
        }

        public static void inhabilitarCliente(Cliente cliente)
        {
            SqlCommand query = createQuery("UPDATE SQLITO.Clientes SET estado = 0 WHERE id_cliente = @id");
            query.Parameters.AddWithValue("@id", cliente.id);
            execNonQuery(query);
            SqlCommand query2 = createQuery("SELECT usuario_id FROM SQLITO.Clientes WHERE id_cliente = @idd");
            query2.Parameters.AddWithValue("@idd", cliente.id);
            String res = getValue(query2);
            SqlCommand query3 = createQuery("UPDATE SQLITO.Usuarios SET habilitado = 0 WHERE id_usuario = @res");
            query3.Parameters.AddWithValue("@res", res);
            execNonQuery(query3);
            
        }

        public static Boolean documentoEsDeCliente(string nrodoc, string tipodoc, Cliente cliente)
        {
            SqlCommand q = createQuery(@"SELECT numero_documento FROM SQLITO.Clientes WHERE tipo_documento = @tipodoc
                                AND numero_documento = @nrodoc AND id_cliente = @id");
            q.Parameters.AddWithValue("@tipodoc", tipodoc);
            q.Parameters.AddWithValue("@nrodoc", nrodoc);
            q.Parameters.AddWithValue("@id", cliente.id);
            return (getValue(q) != "");
        }

        public static Boolean cuilEsDeCliente(string cuil, Cliente cliente)
        {
            SqlCommand q = createQuery("SELECT cuil FROM SQLITO.Clientes WHERE cuil = @cuil AND id_cliente = @id");
            q.Parameters.AddWithValue("@cuil", cuil);
            q.Parameters.AddWithValue("@id", cliente.id);
            return (getValue(q) != "");
        }

        #endregion

        #region Puntos


        #endregion

        #region Rol

        public static Boolean rolExiste(Rol rol)
        {
            SqlCommand query = createQuery("SELECT COUNT(*) FROM SQLITO.Roles WHERE LOWER(descripcion) = LOWER(@desc)");
            query.Parameters.AddWithValue("@desc", rol.descripcion);
            return (Convert.ToInt32(getValue(query)) != 0);
        }

        public static List<string> getRoles()
        {
            SqlCommand query = createQuery("SELECT DISTINCT(descripcion) FROM SQLITO.Roles");
            return getList(query); 
        }

        public static DataTable getRoles_table()
        {
            SqlCommand query = createQuery("SELECT * FROM SQLITO.Roles ORDER BY id_rol");
            return getTable(query);
        }

        public static DataTable getRolesActivos_table()
        {
            SqlCommand query = createQuery("SELECT * FROM SQLITO.Roles WHERE habilitado = 1");
            return getTable(query);
        }

        public static List<string> getFuncionalidades()
        {
            SqlCommand query = createQuery("SELECT DISTINCT(descripcion) FROM SQLITO.Funcionalidades");
            return getList(query); 
        }

        public static List<string> getFuncionalidadesDeRol(Rol rol)
        {
            SqlCommand query = createQuery(@"SELECT DISTINCT(funcionalidad_id) FROM SQLITO.Funcionalidades_Roles
                    WHERE rol_id = @idrol");
            query.Parameters.AddWithValue("@idrol", getIdRol(rol));
            return getList(query);
        }

        public static Boolean rolHabilitado(Rol rol)
        {
            SqlCommand query = createQuery("SELECT habilitado FROM SQLITO.Roles WHERE descripcion = @desc");
            query.Parameters.AddWithValue("@desc", rol.descripcion);
            return Boolean.Parse(getValue(query));
        }

        public static void guardarRol(Rol rol)
        {
            SqlCommand query = createQuery("INSERT INTO SQLITO.Roles VALUES (@nombreRol,1)");
            query.Parameters.AddWithValue("@nombreRol", rol.descripcion);
            execNonQuery(query);
        }

        public static void agregarFuncionalidad(Rol rol, string func)
        {
            SqlCommand query = createQuery("INSERT INTO SQLITO.Funcionalidades_Roles VALUES(@func_id,@rol_id)");
            query.Parameters.AddWithValue("@func_id", getIdFuncionalidad(func));
            query.Parameters.AddWithValue("@rol_id",getIdRol(rol));
            execNonQuery(query);
        }

        public static void agregarFuncionalidades(Rol rol, List<string> func)
        {
            foreach (string f in func)
            {
                agregarFuncionalidad(rol, f);
            }
        }

        public static string getIdRol(Rol rol)
        {
            SqlCommand query = createQuery("SELECT id_rol FROM SQLITO.Roles WHERE descripcion = @desc");
            query.Parameters.AddWithValue("@desc", rol.descripcion);
            return getValue(query);
        }

        public static void inhabilitarRol(Rol rol)
        {
            SqlCommand query = createQuery("UPDATE SQLITO.Roles SET habilitado = 0 WHERE descripcion = @desc");
            query.Parameters.AddWithValue("@desc", rol.descripcion);
            execNonQuery(query);
        }

        public static void habilitarRol(Rol rol)
        {
            SqlCommand query = createQuery("UPDATE SQLITO.Roles SET habilitado = 1 WHERE descripcion = @desc");
            query.Parameters.AddWithValue("@desc", rol.descripcion);
            execNonQuery(query);
        }

        public static List<string> funcionalidesDe(Rol rol)
        {
            SqlCommand query = createQuery(@"SELECT f.descripcion FROM SQLITO.Funcionalidades f 
                JOIN SQLITO.Funcionalidades_Roles fr ON f.id_funcionalidad = fr.funcionalidad_id
                WHERE fr.rol_id = @id");
            query.Parameters.AddWithValue("@id", getIdRol(rol));
            return getList(query);
        }

        public static void updateRole(Rol rol)
        {
            SqlCommand query = createQuery("UPDATE SQLITO.Roles SET descripcion = @desc WHERE id_rol = @id");
            query.Parameters.AddWithValue("@desc", rol.descripcion);
            query.Parameters.AddWithValue("@id", rol.id);
            execNonQuery(query);
        }

        #endregion

        #region Funcionalidad

        private static string getIdFuncionalidad(string func)
        {
            SqlCommand query = createQuery("SELECT id_funcionalidad FROM SQLITO.Funcionalidades WHERE descripcion = @desc");
            query.Parameters.AddWithValue("@desc",func);
            return getValue(query);    
        }

        #endregion
    }
}
