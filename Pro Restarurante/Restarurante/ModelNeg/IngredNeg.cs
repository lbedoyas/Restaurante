using ModelDao;
using ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelNeg
{
    public class IngredNeg
    {
        private IngredDao objIngredDao;
        public IngredNeg()
        {
            objIngredDao = new IngredDao();

        }
        public void create(Ingred objIngred)
        {
            objIngredDao.create(objIngred);

            return;

        }
        public bool find(Ingred objIngred)
        {
            return objIngredDao.find(objIngred);
        }
        public void delete(int id)
        {
            objIngredDao.delete(id);

            return;

        }
        public Ingred buscar(int id)
        {
           return  objIngredDao.buscar(id);

        }
        public void update(Ingred objIngred)
        {
            objIngredDao.update(objIngred);

            return;
        }
        public List<Ingred>findAll()
        {
            return objIngredDao.findAll();
        }
    }
}
