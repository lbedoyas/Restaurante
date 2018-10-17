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
    public class CategoriaController : Controller
    {
        // GET: Categoria
        private CategoriaNeg objCategoriaNeg;

        public CategoriaController()
        {
            objCategoriaNeg = new CategoriaNeg();
        }

        // GET: Plato
        public ActionResult Index()
        {
            Categoria objCategoria = new Categoria();
            List<Categoria> lista = objCategoriaNeg.findAll();
            return View(lista);
        }
        [HttpGet]
        public ActionResult Create()
        {
            mensajeInicioRegistrar();
            return View();
        }
      
        [HttpPost]
        public ActionResult Create(Categoria objCategoria)
        {
            mensajeInicioRegistrar();
            objCategoriaNeg.create(objCategoria);
            return View("Create");
        }
        public ActionResult Delete(int id, Categoria cat)
        {
            List<Categoria> lista = objCategoriaNeg.findAll();

            if (string.IsNullOrEmpty(id.ToString()))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                mensajeInicioRegistrar();
                objCategoriaNeg.find(cat);
                var categoria = objCategoriaNeg.buscar(id);
                Categoria categoria2 = new Categoria
                {
                    idCategoria = categoria.idCategoria,
                    descrip = categoria.descrip,
                    encarg = categoria.encarg,
                    nombrec = categoria.nombrec

                };
                objCategoriaNeg.delete(id);
                return View("Delete", categoria2);
               
            }
        }
        public ActionResult edit(int id, Categoria cat)
        {
            List<Categoria> lista = objCategoriaNeg.findAll();
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }else {
                mensajeInicioRegistrar();
                objCategoriaNeg.find(cat);
                var categoria = objCategoriaNeg.buscar(id);
                Categoria categoria2 = new Categoria
                {
                    idCategoria = categoria.idCategoria,
                    nombrec = categoria.nombrec,
                    descrip = categoria.descrip,
                    encarg = categoria.encarg,

                };
               
                return View("Edit", categoria2);
                objCategoriaNeg.update(cat);
            }
            
        }

        public void mensajeInicioRegistrar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos Del plato";
        }
    }
}
