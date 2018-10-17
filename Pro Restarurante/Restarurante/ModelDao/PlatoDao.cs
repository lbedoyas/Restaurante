using ModelEntity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDao
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
            string create = "insert into plato values('"  + objPlato.nombrep + "','" + objPlato.descrip + "','" + objPlato.nivel + "','" + objPlato.foto + "','" + objPlato.precio + "','" + objPlato.idCategoria + "')";
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
        public void delete(int objPlato)
        {
            string delete = "Delete from plato where  idPlato= '" + objPlato + "'";
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
        public void update(Plato pla)
        {
            string update = "update plato set nombrep='" + pla.nombrep + "', descrip='" + pla.descrip + "', nivel= '" + pla.nivel + "' , foto = '" + pla.foto + "', precio = '"+ pla.precio +"'  where  idPlato= '" + pla.IdPlato + "'";
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
        public bool find(Plato objPlato)
        {
            bool hayRegistros;
            string find = "select*from plato where idplato='" + objPlato.IdPlato + "'";

            comando = new SqlCommand(find, objConexionDB.getCon());
            objConexionDB.getCon().Open();
            reader = comando.ExecuteReader();
            hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objPlato.IdPlato = Int32.Parse(reader[0].ToString());
                objPlato.nombrep = reader[1].ToString();
                objPlato.descrip = reader[2].ToString();
                objPlato.nivel = Convert.ToInt32(reader[3].ToString());
                objPlato.foto = reader[4].ToString();
                objPlato.precio = Convert.ToDecimal(reader[5].ToString());
                objPlato.idCategoria= Convert.ToInt32(reader[6].ToString());
            }
            else
            {
                //objCategoria.estado = 1;
            }
            objConexionDB.getCon().Close();
            objConexionDB.closeDB();

            return hayRegistros;
        }
        public Plato buscar(int id)
        {

            List<Plato> listaPlato = new List<Plato>();
            string find = "select * from plato where idPlato = '" + id + "'";

            comando = new SqlCommand(find, objConexionDB.getCon());
            objConexionDB.getCon().Open();
            reader = comando.ExecuteReader();
            Plato objPlato = new Plato();
            while (reader.Read())
            {

                objPlato.IdPlato = Int32.Parse(reader[0].ToString());
                objPlato.nombrep = reader[1].ToString();
                objPlato.descrip = reader[2].ToString();
                objPlato.nivel = Int32.Parse(reader[3].ToString());
                objPlato.foto = reader[4].ToString();
                objPlato.precio =Decimal.Parse(reader[5].ToString());
                objPlato.idCategoria = Int32.Parse(reader[6].ToString());
            }

            objConexionDB.getCon().Close();
            objConexionDB.closeDB();
            return objPlato;
        }

        public List<Plato> findAll()
        {

            List<Plato> listaPlato = new List<Plato>();
            string find = "select * from plato";

            comando = new SqlCommand(find, objConexionDB.getCon());
            objConexionDB.getCon().Open();
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Plato objPlato = new Plato();
                objPlato.IdPlato = Int32.Parse(reader[0].ToString());
                objPlato.nombrep = reader[1].ToString();
                objPlato.descrip = reader[2].ToString();
                objPlato.nivel = Convert.ToInt32(reader[3].ToString());
                objPlato.foto = reader[4].ToString();
                objPlato.precio = Convert.ToDecimal(reader[5].ToString());
                objPlato.idCategoria = Convert.ToInt32(reader[6].ToString());
                listaPlato.Add(objPlato);
            }

            objConexionDB.getCon().Close();
            objConexionDB.closeDB();
            return listaPlato;
        }
    }
}
