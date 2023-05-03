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

        private const int MAXIMO_CREDITOS = 5;

        public List<Matricula> Listar(MatriculaFiltro filtro = null, bool conDetalles = false)
        {
            using (_contexto = new DataBaseContexto())
            {
                _matriculaRepositorio = new MatriculaRepositorio(_contexto);
                List<Matricula> lista = _matriculaRepositorio.Listar(filtro);

                if (lista.Count > 0 && conDetalles)
                {
                    int[] matriculaIds = lista.Select(x => x.Id).ToArray();
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
                _seccionRepositorio = new SeccionRepositorio(_contexto);

                List<Matricula> matriculas = _matriculaRepositorio.Listar(new MatriculaFiltro { AlumnoId = entidad.AlumnoId, Estado = EstadoMatricula.ACTIVO });
                Seccion seccion = _seccionRepositorio.BuscarPorId(entidad.SeccionId);

                #region Validacion de Curso Repetido

                if (matriculas.Where(x => x.Seccion.CursoId == seccion.CursoId).Count() > 0)
                    throw new Exception($"El alumno ya se encuentra matriculado en el curso {seccion.Curso.Descripcion}.");

                #endregion

                #region Validacion de Creditos

                int creditos = matriculas.Sum(x => x.Seccion.Curso.Credito);
                if (creditos >= MAXIMO_CREDITOS) throw new Exception($"El alumno sobrepasa los {MAXIMO_CREDITOS} creditos.");

                #endregion

                #region Validacion de Vacantes

                if (seccion.Disponible == 0)
                    throw new Exception($"El alumno no puede matricularse en la sección: {seccion.Descripcion}, por que no tiene vacantes libres.");

                #endregion

                #region Actualizar Vacantes de la seccion

                seccion.Matriculado++;
                _seccionRepositorio.Update(seccion);

                #endregion

                #region Guardar Matricula

                entidad.Estado = EstadoMatricula.ACTIVO;
                entidad.Registro = DateTime.Now;

                _matriculaRepositorio.Save(entidad);


                #endregion

                _contexto.SaveChanges();
            }
        }

        public void Anular(Matricula entidad)
        {
            using (_contexto = new DataBaseContexto())
            {
                _matriculaRepositorio = new MatriculaRepositorio(_contexto);
                _seccionRepositorio = new SeccionRepositorio(_contexto);

                Matricula _ = _matriculaRepositorio.GetOne(x => x.Id == entidad.Id && x.Estado == EstadoMatricula.ACTIVO);
                if (_ != null)
                {
                    #region Anular Matricula

                    _.Anulacion = DateTime.Now;
                    _.Estado = EstadoMatricula.BAJA;
                    _matriculaRepositorio.Update(_);

                    #endregion

                    #region Actualizar La vacante de la sección

                    Seccion seccion = _seccionRepositorio.GetOne(x => x.Id == _.SeccionId);
                    seccion.Matriculado--;
                    _seccionRepositorio.Update(seccion);

                    #endregion

                    _contexto.SaveChanges();
                }
            }

        }
    }
}
