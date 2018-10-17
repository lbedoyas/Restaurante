using ModelDao;
using ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelNeg
{
    public class PlatoNeg
    {
        private PlatoDao objPlatoDao;
        public PlatoNeg()
        {
            objPlatoDao = new PlatoDao();

        }
        public void create(Plato objplato)
        {
            objPlatoDao.create(objplato);

            return;

        }
        public void delete(int objPlato)
        {
            objPlatoDao.delete(objPlato);

            return;

        }
        public bool find(Plato objPlato)
        {
            return objPlatoDao.find(objPlato);
        }
        public Plato buscar(int id)
        {
            return objPlatoDao.buscar(id);
        }
        public void update(Plato objPlato)
        {
            objPlatoDao.update(objPlato);

            return;
        }
        public List<Plato> findAll()
        {
            return objPlatoDao.findAll();
        }
    }
}
