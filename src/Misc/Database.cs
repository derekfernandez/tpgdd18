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
                SqlCommand update = createQuery("UPDATE SQLITO.Usuarios SET intentos_fallidos = @intentos");
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
