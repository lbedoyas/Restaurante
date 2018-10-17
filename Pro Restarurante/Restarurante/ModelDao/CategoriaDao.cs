using ModelEntity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDao
{
    public class CategoriaDao
    {
        private ConexionDB objConexionDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        public CategoriaDao()
        {
            objConexionDB = ConexionDB.saberEstado();
        }

        public void create(Categoria objCategoria)
        {
            string create = "insert into categoria values('" + objCategoria.nombrec+ "','" + objCategoria.descrip + "','" + objCategoria.encarg + "')";
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
        public void delete(int objCategoria)
        {
            string delete = "Delete from categoria where  idCategoria= '" + objCategoria + "'";
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
        public void update(Categoria cat)
        {
            string update = "update categoria set nombrec='"+cat.nombrec+"', descrip='"+cat.descrip+"', encarg= '"+cat.encarg+"' where  idCategoria= '" + cat.idCategoria+ "'";
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
        public Categoria buscar(int id)
        {

            List<Categoria> listaCategoria = new List<Categoria>();
            string find = "select * from categoria where idCategoria = '"+ id + "'";

            comando = new SqlCommand(find, objConexionDB.getCon());
            objConexionDB.getCon().Open();
            reader = comando.ExecuteReader();
            Categoria objCategoria = new Categoria();
            while (reader.Read())
            {
                
                objCategoria.idCategoria = Int32.Parse(reader[0].ToString());
                objCategoria.nombrec = reader[1].ToString();
                objCategoria.descrip = reader[2].ToString();
                objCategoria.encarg = reader[3].ToString();
            }

            objConexionDB.getCon().Close();
            objConexionDB.closeDB();
            return objCategoria;
        }
        public bool find(Categoria objCategoria)
        {
            bool hayRegistros;
            string find = "select * from categoria where idCategoria='" + objCategoria.idCategoria + "'";

            comando = new SqlCommand(find, objConexionDB.getCon());
            objConexionDB.getCon().Open();
            reader = comando.ExecuteReader();
            hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objCategoria.idCategoria = Int32.Parse(reader[0].ToString());
                objCategoria.nombrec= reader[1].ToString();
                objCategoria.descrip =reader[2].ToString();
                objCategoria.encarg = reader[3].ToString();

            }
            else
            {
                //objCategoria.estado = 1;
            }
            objConexionDB.getCon().Close();
            objConexionDB.closeDB();

            return hayRegistros;
        }

        public List<Categoria> findAll()
        {

            List<Categoria> listaCategoria = new List<Categoria>();
            string find = "select * from categoria";

            comando = new SqlCommand(find, objConexionDB.getCon());
            objConexionDB.getCon().Open();
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Categoria objCategoria = new Categoria();
                objCategoria.idCategoria = Int32.Parse(reader[0].ToString());
                objCategoria.nombrec = reader[1].ToString();
                objCategoria.descrip = reader[2].ToString();
                objCategoria.encarg = reader[3].ToString();
                listaCategoria.Add(objCategoria);
            }

            objConexionDB.getCon().Close();
            objConexionDB.closeDB();
            return listaCategoria;
        }
    }
}
