using SOL_JUNIOR_SULCA.Entidades.Filtros;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Logicas.Genericos;
using SOL_JUNIOR_SULCA.WebApp.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace SOL_JUNIOR_SULCA.WebApp.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly MatriculaLogica _matriculaLogica;
        private readonly SeccionLogica _seccionLogica;
        private readonly AlumnoLogica _alumnoLogica;

        public MatriculaController()
        {
            _matriculaLogica = new MatriculaLogica();
            _seccionLogica = new SeccionLogica();
            _alumnoLogica = new AlumnoLogica();
        }

        public ActionResult Index()
        {
            List<Matricula> lista = _matriculaLogica.Listar(null, true);
            return View(lista);
        }

        public ActionResult Nuevo()
        {
            Matricula _ = new Matricula();

            List<Seccion> secciones = _seccionLogica.Listar(new SeccionFiltro { ConVacantes = true });
            List<Alumno> alumnos = _alumnoLogica.Listar(new AlumnoFiltro { Estado = Entidades.Constantes.EstadoAlumno.ACTIVO });

            ViewBag.Secciones = secciones;
            ViewBag.Alumnos = alumnos;

            return View(_);
        }

        [HttpPost]
        public ActionResult Nuevo(MatriculaModel.Nuevo model)
        {
            try
            {
                Validar(model);
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView("_Error");
                }

                Matricula _ = model.Get();

                _matriculaLogica.Guardar(_);

                return Json(new
                {
                    mensaje = "Se registro correctamente"
                });
            }
            catch (System.Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ViewBag.Message = ex.Message;
                return PartialView("_Error");
            }
        }

        public ActionResult Anular(int id)
        {
            bool sePuedeAnular = _matriculaLogica.SePuedeAnular(id);
            if (!sePuedeAnular)
            {
                TempData["Error"] = "No se pudo anular la matricula";
                return RedirectToAction("Index");
            }

            Matricula _ = new Matricula { Id = id };
            _matriculaLogica.Anular(_);

            TempData["Mensaje"] = "Se anulo la matricula";
            return RedirectToAction("Index");
        }

        #region Metodos

        [NonAction]
        private void Validar(MatriculaModel.Nuevo entidad)
        {
            ModelState.Clear();
            if (!entidad.Tipo.HasValue) ModelState.AddModelError("Tipo", "Es necesario seleccionar un tipo.");
        }

        #endregion
    }
}