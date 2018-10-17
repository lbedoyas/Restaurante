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
    public class IngredController : Controller
    {
        // GET: Ingred
        private IngredNeg objIngredNeg;

        public IngredController()
        {
            objIngredNeg = new IngredNeg();

        }

        // GET: Plato
        public ActionResult Index()
        {
            Ingred objIngred = new Ingred();
            List<Ingred> lista = objIngredNeg.findAll();
            return View(lista);
        }
        [HttpGet]
        public ActionResult Create()
        {
            mensajeInicioRegistrar();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Ingred objIngred)
        {
            mensajeInicioRegistrar();
            objIngredNeg.create(objIngred);
            return View("Create");
        }
        public ActionResult Delete(int id, Ingred cat)
        {
            List<Ingred> lista = objIngredNeg.findAll();

            if (string.IsNullOrEmpty(id.ToString()))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                mensajeInicioRegistrar();
                objIngredNeg.find(cat);
                var ingred = objIngredNeg.buscar(id);
                Ingred ingred1 = new Ingred
                {
                    idIngred = ingred.idIngred,
                    nombreI = ingred.nombreI,
                    unidades = ingred.unidades,
                    almacen = ingred.almacen

                };
                objIngredNeg.delete(id);
                return View("Delete", ingred1);

            }
        }
        public ActionResult Edit(int id, Ingred ing)
        {
            List<Ingred> lista = objIngredNeg.findAll();
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                mensajeInicioRegistrar();
                objIngredNeg.find(ing);
                var ingred = objIngredNeg.buscar(id);
                Ingred ingred2 = new Ingred
                {
                    idIngred = ingred.idIngred,
                    nombreI = ingred.nombreI,
                    unidades = ingred.unidades,
                    almacen = ingred.almacen
                   
                };
                objIngredNeg.update(ing);
                return View("Edit", ingred2);

            }

        }
        public void mensajeInicioRegistrar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos Del plato";
        }
    }
}
