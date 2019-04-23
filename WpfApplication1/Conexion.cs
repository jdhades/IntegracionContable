using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

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
