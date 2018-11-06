
namespace Ceres.Backend.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Ceres.Servicios.Models;
    using PagedList;

    public class GrupoFamiliaController : Controller
    {
        // GET: GrupoFamilia

        private serGrupoFamilia _setGrupoFamilia = new serGrupoFamilia();

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


            var GrupoFamilia = _setGrupoFamilia .ListaGrupoFamilia ;

            var gf = from s in GrupoFamilia
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                gf = gf.Where(s => s.Descripcion.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Codigo":
                    gf = gf.OrderBy(s => s.cve_Grupo_Familia);
                    break;
                case "Codigo-":
                    gf = gf.OrderByDescending(s => s.cve_Grupo_Familia);
                    ViewBag.Codigo = "Codigo";
                    break;
                case "Descripcion":
                    gf = gf.OrderByDescending(s => s.Descripcion);
                    break;
                case "Estatus":
                    gf = gf.OrderBy(s => s.Estatus);
                    break;
                case "Estatus-":
                    gf = gf.OrderByDescending(s => s.Estatus);
                    ViewBag.Estatus = "Estatus";
                    break;
                default:  // Name ascending  
                    gf = gf.OrderBy(s => s.Descripcion);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(gf.ToPagedList(pageNumber, pageSize));
        }


    }
}