using SOL_JUNIOR_SULCA.Entidades.Filtros;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Logicas.Genericos;
using SOL_JUNIOR_SULCA.WebApp.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace SOL_JUNIOR_SULCA.WebApp.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly AlumnoLogica _alumnoLogica;

        public AlumnoController()
        {
            _alumnoLogica = new AlumnoLogica();
        }

        public ActionResult Index()
        {
            List<Alumno> lista = _alumnoLogica.Listar(null);
            return View(lista);
        }

        public ActionResult Nuevo() => View(new Alumno() { Estado = Entidades.Constantes.EstadoAlumno.ACTIVO });
        
        [HttpPost]
        public ActionResult Nuevo(AlumnoModel.Nuevo model)
        {
            try
            {
                Validar(model);
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView("_Error");
                }

                Alumno _ = model.ToAlumno();

                _alumnoLogica.Guardar(_);

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

        public ActionResult Editar(int id)
        {
            Alumno _ = _alumnoLogica.BuscarPorId(id);   
            return View(_);
        }

        [HttpPost]
        public ActionResult Editar(AlumnoModel.Editar model)
        {
            try
            {
                Validar(model);
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView("_Error");
                }

                Alumno _ = model.ToAlumno();

                _alumnoLogica.Actualizar(_);

                return Json(new
                {
                    mensaje = "Se actualizó correctamente"
                });
            }
            catch (System.Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ViewBag.Message = ex.Message;
                return PartialView("_Error");
            }
        }


        #region Metodos

        [NonAction]
        private void Validar(AlumnoModel.Nuevo entidad)
        {
            ModelState.Clear();
            if (string.IsNullOrEmpty(entidad.Nombre)) ModelState.AddModelError("Nombre", "Es necesario ingresar el nombre.");
            if (string.IsNullOrEmpty(entidad.Apellido)) ModelState.AddModelError("Apellido", "Es necesario ingresar el apellido.");
            if (!entidad.Estado.HasValue) ModelState.AddModelError("Estado", "Es necesario seleccionar un estado.");
        }

        [NonAction]
        private void Validar(AlumnoModel.Editar entidad)
        {
            ModelState.Clear();
            if (!entidad.Id.HasValue) ModelState.AddModelError("Id", "Es necesario ingresar el identificador.");
            if (string.IsNullOrEmpty(entidad.Nombre)) ModelState.AddModelError("Nombre", "Es necesario ingresar el nombre.");
            if (string.IsNullOrEmpty(entidad.Apellido)) ModelState.AddModelError("Apellido", "Es necesario ingresar el apellido.");
            if (!entidad.Estado.HasValue) ModelState.AddModelError("Estado", "Es necesario seleccionar un estado.");
        }

        #endregion
    }
}