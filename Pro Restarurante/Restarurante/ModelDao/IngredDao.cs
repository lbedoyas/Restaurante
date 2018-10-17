using ModelEntity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDao
{
    public class IngredDao
    {
        private ConexionDB objConexionDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public IngredDao()
        {
            objConexionDB = ConexionDB.saberEstado();
        }

        public void create(Ingred objIngred)
        {
            string create = "insert into ingred values('" + objIngred.nombreI + "','" + objIngred.unidades + "','" + objIngred.almacen +  "')";
            try
            {
                comando = new SqlCommand(create, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
        }
        public void update(Ingred ing)
        {
            string update = "update ingred set nombrei='" + ing.nombreI + "', unidades='" + ing.unidades + "', almacen= '" + ing.almacen + "'  where  idIngred = '" + ing.idIngred + "'";
            try
            {
                comando = new SqlCommand(update, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
        }
        public bool find(Ingred objIngred)
        {
            bool hayRegistros;
            string find = "select * from ingred where idIngred='" + objIngred.idIngred + "'";

            comando = new SqlCommand(find, objConexionDB.getCon());
            objConexionDB.getCon().Open();
            reader = comando.ExecuteReader();
            hayRegistros = reader.Read();
            if (hayRegistros)
            {
               objIngred.nombreI = reader[1].ToString();
                objIngred.unidades = Convert.ToDecimal(reader[2].ToString());
               objIngred.almacen = Convert.ToDecimal(reader[3].ToString());
               
            }
            else
            {
                //objCategoria.estado = 1;
            }
            objConexionDB.getCon().Close();
            objConexionDB.closeDB();

            return hayRegistros;
        }
        public void delete(int objIngred)
        {
            string delete = "Delete from ingred where  idIngred= '" + objIngred + "'";
            try
            {
                comando = new SqlCommand(delete, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
        }
        public Ingred buscar(int id)
        {

            List<Categoria> listaCategoria = new List<Categoria>();
            string find = "select * from ingred where idIngred = '" + id + "'";

            comando = new SqlCommand(find, objConexionDB.getCon());
            objConexionDB.getCon().Open();
            reader = comando.ExecuteReader();
            Ingred objIngred = new Ingred();
            while (reader.Read())
            {
                objIngred.idIngred = Int32.Parse(reader[0].ToString());
                objIngred.nombreI = reader[1].ToString();
                objIngred.unidades = Convert.ToDecimal(reader[2].ToString());
                objIngred.almacen = Convert.ToDecimal(reader[3].ToString());

            }

            objConexionDB.getCon().Close();
            objConexionDB.closeDB();
            return objIngred;
        }
        public List<Ingred> findAll()
        {

            List<Ingred> listaIngred = new List<Ingred>();
            string find = "select * from ingred";

            comando = new SqlCommand(find, objConexionDB.getCon());
            objConexionDB.getCon().Open();
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                
                Ingred objIngred = new Ingred();
                objIngred.idIngred = Int32.Parse(reader[0].ToString());
                objIngred.nombreI = reader[1].ToString();
                objIngred.unidades = Convert.ToDecimal(reader[2].ToString());
                objIngred.almacen = Convert.ToDecimal(reader[3].ToString());
                listaIngred.Add(objIngred);
            }

            objConexionDB.getCon().Close();
            objConexionDB.closeDB();
            return listaIngred;
        }
    }
}
