using SOL_JUNIOR_SULCA.Entidades.Filtros;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Logicas.Genericos;
using SOL_JUNIOR_SULCA.WebApp.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace SOL_JUNIOR_SULCA.WebApp.Controllers
{
    public class SeccionController : Controller
    {
        private readonly SeccionLogica _seccionLogica;

        public SeccionController()
        {
            _seccionLogica = new SeccionLogica();
        }

        public ActionResult Index()
        {
            List<Seccion> lista = _seccionLogica.Listar();
            return View(lista);
        }
    }
}