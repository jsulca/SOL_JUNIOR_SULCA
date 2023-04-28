using SOL_JUNIOR_SULCA.Contextos;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOL_JUNIOR_SULCA.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Matricula item = new Matricula
            {
                Id = 1,
                Codigo = "001",
                NroDocumento = "700",
                Nombre = "Junior",
                Apellido = "Sulca",
                Estado = Entidades.Constantes.EstadoMatricula.ACTIVO,
            };

            List<Matricula> lista = new List<Matricula>();
            using (DataBaseContexto ctx = new DataBaseContexto())
            {
                lista = ctx.Matricula.ToList();
            }


            return View(lista);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}