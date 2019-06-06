using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Windows.Forms;
using System.Configuration;

namespace WpfApplication1
{
    public class Conexion
    {
        public SqlConnection con; //obj conexion
        private SqlCommandBuilder cmb;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;
        public SqlCommand comando;
       
        public string Cadena { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

         private static string nCon;
        internal static string providerName;

        public static string GetConexion()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConnectionStringSettings cs = config.ConnectionStrings.ConnectionStrings["default"];

                if (cs == null)
                    throw new ArgumentNullException("nameConnectionString", "El nombre de la cadena de conexión no existe" + " en el archivo de configuración de la aplicación.");

                nCon = cs.ConnectionString;
                if ((nCon == string.Empty))
                    throw new ArgumentNullException("nameConnectionString", "No existe la cadena de conexion en el valor" + " con nombre especificado.");
                //nCon = String.Empty

                providerName = cs.ProviderName;
                if (providerName == string.Empty)
                    throw new ArgumentNullException("nameConnectionString", "El proveedor .net especificado" + " actualmente no se encuentra soportado.");
                return string.Empty;

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.ToString());
                return ex.Message;
                //Throw ex
                nCon = "";
            }
        }

        public static SqlConnection Conectar()
        {

            SqlConnection cnMDB = new SqlConnection();
            if (string.IsNullOrEmpty(nCon))
                GetConexion();
            if (nCon != null)
            {
                try
                {
                    cnMDB.ConnectionString = nCon;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return cnMDB;

        }

        public static void BuilConnectionString(string DataSource, string InitialCatalog, string UserId, string Password)
        {
	        // Obtenemos el archivo de configuración de la aplicación.
	        //
	        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

	        // Obtenemos la sección connectionStrings.
	        //
	        ConnectionStringsSection section = config.ConnectionStrings;

	        // Obtenemos el objeto ConnectionStringSettings
	        // correspondiente al nombre de la cadena de
	        // conexión especificada.

            ConnectionStringSettings settings = section.ConnectionStrings["default"];

            //if ((settings == null))
            //    return;


	        // Creamos el objeto
	        DbConnectionStringBuilder builder = new DbConnectionStringBuilder();

	        // Le asignamos el valor de la cadena de conexión
            builder.ConnectionString = settings.ConnectionString;

	        builder["Data Source"] = DataSource;
	        builder["Initial Catalog"] = InitialCatalog;
	        builder["User Id"] = UserId;
	        builder["Password"] = Password;

	        // Le asignamos la cadena de conexión existente  
	        // en el objeto DbConnectionStringBuilder.  
	        //
            settings.ConnectionString = builder.ConnectionString;

	        // Modificamos la cadena de conexión en el archivo app.config.
	        //
            AddAndSaveOneConnectionStringSettings(config, settings);

        }

        public static void AddAndSaveOneConnectionStringSettings(System.Configuration.Configuration configuration, System.Configuration.ConnectionStringSettings connectionStringSettings)
        {
            // You cannot add to ConfigurationManager.ConnectionStrings using
            // ConfigurationManager.ConnectionStrings.Add
            // (connectionStringSettings) -- This fails.

            // But you can add to the configuration section and refresh the ConfigurationManager.

            // Get the connection strings section; Even if it is in another file.
            ConnectionStringsSection connectionStringsSection = configuration.ConnectionStrings;

            // Add the new element to the section.
            connectionStringsSection.ConnectionStrings.Add(connectionStringSettings);

            // Save the configuration file.
            configuration.Save(ConfigurationSaveMode.Minimal);

            // This is this needed. Otherwise the connection string does not show up in
            // ConfigurationManager
            ConfigurationManager.RefreshSection("connectionStrings");
        }
       /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="cadena"></param>

        public void Conectar(string cadena)
        {
            con = new SqlConnection(cadena);
        }

        public Conexion(string cadena)
        {
            Cadena = cadena;
            Conectar(Cadena);
        }

        public void Abrir() // Metodo para Abrir la Conexion
        {

            con.Open();

        }

        public void Cerrar() // Metodo para Cerrar la Conexion
        {

            con.Close();

        }

        public void Consultar(string sql, string tabla)
        {
            ds.Tables.Clear();
            da = new SqlDataAdapter(sql, con);
            cmb = new SqlCommandBuilder(da);
            da.Fill(ds, tabla);
        }

        public bool Eliminar(string sql)
        {
            con.Open();
            
            comando = new SqlCommand(sql, con);
            comando.CommandTimeout = 240;
            int i = comando.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool actualizar(string tabla, string campos, string condicion)
        {
            con.Open();
            string sql = "update " + tabla +" set " + campos + " where " + condicion;
            comando = new SqlCommand(sql, con);
            int i = comando.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable conasultar2(string Comando, string Tabla) // Metodo para Ejecutar Comandos
        {

            SqlDataAdapter CMD = new SqlDataAdapter(Comando, con); // Creamos un DataAdapter con el Comando y la Conexion

            DataSet DS = new DataSet(); // Creamos el DataSet que Devolvera el Metodo

            CMD.Fill(DS, Tabla); // Ejecutamos el Comando en la Tabla
            DataTable dt = new DataTable();
            dt = DS.Tables[Tabla]; // Regresamos el DataSet
            return dt;
        }

        public bool insertar(string sql)
        {
            con.Open();
            comando = new SqlCommand(sql, con);
            int i = comando.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Int32 escalar(string sql)
        {
            con.Open();
            comando = new SqlCommand(sql, con);
            comando.CommandTimeout = 240;
            Int32 i = (Int32) comando.ExecuteScalar();
            con.Close();
                return i;
            
        }

        public SqlDataReader consulta3(string sql)
        {
            con.Open();
            comando = new SqlCommand(sql, con);
            comando.CommandTimeout = 240;
            SqlDataReader lector = comando.ExecuteReader();
            //con.Close();
            return lector;
        }
    }
}

    


     