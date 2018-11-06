
namespace Ceres.Backend.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Ceres.Comunes.Models;
    using Ceres.Servicios.Models;
    using PagedList;
    public class Marca_comercialController : Controller
    {
        private SerMarca_comercial _Marca_comercial = new SerMarca_comercial();

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Codigo = String.IsNullOrEmpty(sortOrder) ? "Codigo" : "Codigo-";
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


            var Marca_comercial = _Marca_comercial.ListaMarca_comercial;

            if (Marca_comercial != null)
            {
                var Marcas = from s in Marca_comercial
                             select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    Marcas = Marcas.Where(s => s.Descripcion.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "Codigo":
                        Marcas = Marcas.OrderBy(s => s.Cve_marca_comercial);
                        break;
                    case "Codigo-":
                        Marcas = Marcas.OrderByDescending(s => s.Cve_marca_comercial);
                        ViewBag.Codigo = "Codigo";
                        break;
                    case "Descripcion":
                        Marcas = Marcas.OrderByDescending(s => s.Descripcion);
                        break;
                    case "Estatus":
                        Marcas = Marcas.OrderBy(s => s.Estatus);
                        break;
                    case "Estatus-":
                        Marcas = Marcas.OrderByDescending(s => s.Estatus);
                        ViewBag.Estatus = "Estatus";
                        break;
                    default:  // Name ascending  
                        Marcas = Marcas.OrderBy(s => s.Descripcion);
                        break;
                }

                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(Marcas.ToPagedList(pageNumber, pageSize));
                
            }
           return View(Marca_comercial.ToPagedList(0,0));
            
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }


        [HttpPost]
        public ActionResult Create(Marca_comercial Marca_comercial)
        {


            _Marca_comercial.Guardar(Marca_comercial);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Modificar(string codigo)
        {

            if (string.IsNullOrEmpty(codigo))
            {

                return null;

            }
            var art = _Marca_comercial.ListaMarca_comercial.Where(a => a.Cve_marca_comercial == codigo).FirstOrDefault();


            return PartialView(art);
        }



        [HttpPost]
        public ActionResult Modificar(Marca_comercial Marca_comercial)
        {

            _Marca_comercial.Modificar(Marca_comercial);

            return RedirectToAction("Index");


        }
    }
}