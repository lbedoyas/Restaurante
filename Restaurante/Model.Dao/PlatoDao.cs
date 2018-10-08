using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model.Entity;
using Model.Dao;

namespace Model.Dao
{
    public class PlatoDao
    {
        private ConexionDB objConexionDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public PlatoDao()
        {
            objConexionDB = ConexionDB.saberEstado();
        }

        public void create(Plato objPlato)
        {
            comando = new SqlCommand(create, objConexionDB.getCon());
            objConexionDB.getCon().Open();
            comando.ExecuteNonQuery();
        }
			    objConexionDB.getCon().Close();
                objConexionDB.closeDB();
			}
        }
    }
}
