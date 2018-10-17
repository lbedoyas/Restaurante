using ModelEntity;
using ModelNeg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Restarurante.Controllers
{
    public class PlatoController : Controller
    {
        private PlatoNeg objPlatoNeg;

        public PlatoController()
        {
            objPlatoNeg = new PlatoNeg();

        }

        // GET: Plato
        public ActionResult Index()
        {
            Plato objPlato = new Plato();
            List<Plato> lista = objPlatoNeg.findAll();
            return View(lista);
        }
        [HttpGet]
        public ActionResult Create()
        {
            mensajeInicioRegistrar();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Plato objplato)
        {
            mensajeInicioRegistrar();
            objPlatoNeg.create(objplato);
            return View("Create");
        }
        public ActionResult Delete(int id, Plato pla)
        {
            List<Plato> lista = objPlatoNeg.findAll();

            if (string.IsNullOrEmpty(id.ToString()))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                mensajeInicioRegistrar();
                objPlatoNeg.find(pla);
                var plato1 = objPlatoNeg.buscar(id);
                Plato plato = new Plato
                {
                    IdPlato = plato1.IdPlato,
                    nombrep = plato1.nombrep,
                    descrip = plato1.descrip,
                    nivel = plato1.nivel,
                    foto = plato1.foto,
                    precio = plato1.precio,
                    idCategoria = plato1.idCategoria

            };
                objPlatoNeg.delete(id);
                return View("Delete", plato1);

            }
        }
        public ActionResult Edit(int id, Plato pla)
        {
            List<Plato> lista = objPlatoNeg.findAll();
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                mensajeInicioRegistrar();
                objPlatoNeg.find(pla);
                var plato = objPlatoNeg.buscar(id);
                Plato plato2 = new Plato
                {
                    idCategoria = plato.idCategoria,
                    nombrep = plato.nombrep,
                    descrip = plato.descrip,
                    nivel = plato.nivel,
                    foto = plato.foto,
                    precio = plato.precio
                };
                objPlatoNeg.update(pla);
                return View("Edit", plato2);
                
            }

        }

        public void mensajeInicioRegistrar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos Del plato";
        }
    
    }
}
