using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class ConexionBD
    {
        private static ConexionDB objConexionDB = null;
        private SqlConnection con;

        private ConexionDB()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=Restaurante;Integrated Security=True");
        }

        public static ConexionDB saberEstado()
        {
            if (objConexionDB == null)
            {
                objConexionDB = new ConexionDB();

            }
            return objConexionDB;
        }

        public SqlConnection getCon()
        {
            return con;
        }

        public void closeDB()
        {
            objConexionDB = null;
        }
    }
}
}
