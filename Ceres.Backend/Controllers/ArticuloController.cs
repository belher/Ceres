

namespace Ceres.Backend.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Ceres.Comunes.Models;
    using Ceres.Servicios.Models;
    using PagedList;

    public class ArticuloController : Controller
    {

        private SerArticulo _articulo = new SerArticulo();

        //public ActionResult Index()
        //{
        //    return View(_articulo.ListaArticulo);
        //}


        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Codigo = String.IsNullOrEmpty(sortOrder) ? "Codigo": "Codigo-";
            ViewBag.Descripcion = String.IsNullOrEmpty(sortOrder) ? "Descripcion" : "";
            ViewBag.Estatus = String.IsNullOrEmpty(sortOrder) ? "Estatus" : "Estatus-";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var articulo = _articulo.ListaArticulo;

            var articulos = from s in articulo
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                articulos = articulos.Where(s => s.Nombre.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Codigo":
                    articulos = articulos.OrderBy(s => s.CveArticulo);
                    break;
                case "Codigo-":
                    articulos = articulos.OrderByDescending(s => s.CveArticulo);
                    ViewBag.Codigo = "Codigo";
                    break;
                case "Descripcion":
                    articulos = articulos.OrderByDescending(s => s.Nombre);
                    break;
                case "Estatus":
                    articulos = articulos.OrderBy(s => s.Estatus);
                    break;
                case "Estatus-":
                    articulos = articulos.OrderByDescending(s => s.Estatus);
                    ViewBag.Estatus = "Estatus";
                    break;
                default:  // Name ascending  
                    articulos = articulos.OrderBy(s => s.Nombre);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(articulos.ToPagedList(pageNumber, pageSize));
        }






        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }


        [HttpPost]
        public ActionResult Create(Articulo  Articulo)
        {


            _articulo.Guardar(Articulo);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Modificar(string codigo)
        {

            if (string.IsNullOrEmpty(codigo))
            {
                
              return null;

            }
            var art = _articulo.ListaArticulo.Where(a => a.CveArticulo == codigo).FirstOrDefault();
            

            return PartialView(art);
        }



        [HttpPost]
        public ActionResult Modificar(Articulo Articulo)
        {

            _articulo.Modificar(Articulo);

            return RedirectToAction("Index");


        }


    }
}