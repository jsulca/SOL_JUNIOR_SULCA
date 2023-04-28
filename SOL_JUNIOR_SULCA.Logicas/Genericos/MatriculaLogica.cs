using SOL_JUNIOR_SULCA.Contextos;
using SOL_JUNIOR_SULCA.Entidades.Constantes;
using SOL_JUNIOR_SULCA.Entidades.Filtros;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SOL_JUNIOR_SULCA.Logicas.Genericos
{
    public class MatriculaLogica
    {
        private DataBaseContexto _contexto;
        private MatriculaRepositorio _matriculaRepositorio;
        private SeccionRepositorio _seccionRepositorio;
        private MatriculaSeccionRepositorio _matriculaSeccionRepositorio;

        private const int MAXIMO_CREDITOS = 5;

        public List<Matricula> Listar(MatriculaFiltro filtro = null, bool conDetalles = false)
        {
            using (_contexto = new DataBaseContexto())
            {
                _matriculaRepositorio = new MatriculaRepositorio(_contexto);
                _matriculaSeccionRepositorio = new MatriculaSeccionRepositorio(_contexto);
                List<Matricula> lista = _matriculaRepositorio.Listar(filtro);

                if (lista.Count > 0 && conDetalles)
                {
                    int[] matriculaIds = lista.Select(x => x.Id).ToArray();
                    List<MatriculaSeccion> secciones = _matriculaSeccionRepositorio.Listar(new MatriculaSeccionFiltro { MatriculaIds = matriculaIds });

                    foreach (Matricula item in lista)
                        item.Secciones = secciones.Where(x => x.MatriculaId == item.Id).ToList();
                }

                return lista;
            }
        }

        public bool SePuedeAnular(int id)
        { 
            using (_contexto = new DataBaseContexto())
            {
                _matriculaRepositorio = new MatriculaRepositorio(_contexto);
                return _matriculaRepositorio.CountBy(x => x.Id == id && x.Estado == EstadoMatricula.ACTIVO) > 0;
            }
        }

        public void Guardar(Matricula entidad)
        {
            using (_contexto = new DataBaseContexto())
            {
                _matriculaRepositorio = new MatriculaRepositorio(_contexto);
                _matriculaSeccionRepositorio = new MatriculaSeccionRepositorio(_contexto);
                _seccionRepositorio = new SeccionRepositorio(_contexto);

                int[] seccionIds = entidad.Secciones.Select(x => x.SeccionId).ToArray();
                List<Seccion> secciones = _seccionRepositorio.Listar(new SeccionFiltro { Ids = seccionIds });

                #region Validacion de Creditos

                int creditos = secciones.Sum(x => x.Curso.Credito);
                if (creditos > MAXIMO_CREDITOS) throw new Exception("El alumno sobrepasa los 5 creditos.");

                #endregion

                #region Validacion de Vacantes

                List<string> seccionSinVacante = new List<string>();
                foreach (Seccion item in secciones)
                {
                    if (item.VacanteUsada >= item.Vacante) seccionSinVacante.Add(item.Descripcion);
                }

                if (seccionSinVacante.Count > 0) throw new Exception($"El alumno no puede matricularse es la siguientes secciones: {string.Join(",", seccionSinVacante)}.");

                #endregion

                #region Actualizar Vacantes de secciones

                foreach (Seccion item in secciones)
                    item.VacanteUsada++;

                _seccionRepositorio.Update(secciones);

                #endregion

                #region Guardar Matricula

                entidad.Estado = EstadoMatricula.ACTIVO;
                entidad.Registro = DateTime.Now;

                _matriculaRepositorio.Save(entidad);

                _matriculaSeccionRepositorio.Save(entidad.Secciones);

                #endregion

                _contexto.SaveChanges();
            }
        }

        public void Anular(Matricula entidad)
        {
            using (_contexto = new DataBaseContexto())
            {
                _matriculaRepositorio = new MatriculaRepositorio(_contexto);
                _matriculaSeccionRepositorio = new MatriculaSeccionRepositorio(_contexto);
                _seccionRepositorio = new SeccionRepositorio(_contexto);

                Matricula _ = _matriculaRepositorio.GetOne(x => x.Id == entidad.Id && x.Estado == EstadoMatricula.ACTIVO);
                if (_ != null)
                {
                    #region Anular Matricula

                    _.Anulacion = DateTime.Now;
                    _.Estado = EstadoMatricula.BAJA;
                    _matriculaRepositorio.Update(_);

                    #endregion

                    List<MatriculaSeccion> matriculaSecciones = _matriculaSeccionRepositorio.GetAllBy(x => x.MatriculaId == entidad.Id);
                    int[] seccionIds = matriculaSecciones.Select(x => x.SeccionId).ToArray();

                    List<Seccion> secciones = _seccionRepositorio.Listar(new SeccionFiltro { Ids = seccionIds });

                    #region Actualizar Vacantes de secciones

                    foreach (Seccion item in secciones)
                        item.VacanteUsada--;

                    _seccionRepositorio.Update(secciones);

                    #endregion

                    _contexto.SaveChanges();
                }
            }

        }
    }
}
