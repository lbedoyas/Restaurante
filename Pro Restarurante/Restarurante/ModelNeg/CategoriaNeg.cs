using ModelDao;
using ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelNeg
{
    public class CategoriaNeg
    {
        private CategoriaDao objCategoriaDao;
        public CategoriaNeg()
        {
            objCategoriaDao = new CategoriaDao();

        }
        public void create(Categoria objCategoria)
        {
            objCategoriaDao.create(objCategoria);

            return;

        }
        public void delete(int objCategoria)
        {
            objCategoriaDao.delete(objCategoria);

            return;

        }
        public void update(Categoria objCategoria)
        {
            objCategoriaDao.update(objCategoria);

            return;

        }
        public Categoria buscar(int id)
        {
            return objCategoriaDao.buscar(id);
        }
        public bool find(Categoria objCategoria)
        {
            return objCategoriaDao.find(objCategoria);
        }

        public List<Categoria> findAll()
        {
            return objCategoriaDao.findAll();
        }
    }
}
