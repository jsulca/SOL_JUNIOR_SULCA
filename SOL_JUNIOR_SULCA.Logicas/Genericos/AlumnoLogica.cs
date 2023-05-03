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
    public class AlumnoLogica
    {
        private DataBaseContexto _contexto;
        private AlumnoRepositorio _alumnoRepositorio;

        public List<Alumno> Listar(AlumnoFiltro filtro = null)
        {
            using (_contexto = new DataBaseContexto())
            {
                _alumnoRepositorio = new AlumnoRepositorio(_contexto);
                return _alumnoRepositorio.Listar(filtro);
            }
        }

        public Alumno BuscarPorId(int id)
        {
            using (_contexto = new DataBaseContexto())
            {
                _alumnoRepositorio = new AlumnoRepositorio(_contexto);
                return _alumnoRepositorio.GetOne(x => x.Id == id);
            }
        }

        public void Guardar(Alumno entidad)
        {
            using (_contexto = new DataBaseContexto())
            {
                _alumnoRepositorio = new AlumnoRepositorio(_contexto);

                int cantidad = _alumnoRepositorio.Count() + 1;
                entidad.Codigo = string.Format("ALU-{0:D6}", cantidad);
                _alumnoRepositorio.Save(entidad);

                _contexto.SaveChanges();
            }
        }

        public void Actualizar(Alumno entidad)
        {
            using (_contexto = new DataBaseContexto())
            {
                _alumnoRepositorio = new AlumnoRepositorio(_contexto);
                MatriculaRepositorio matriculaRepositorio = new MatriculaRepositorio(_contexto);
                SeccionRepositorio seccionRepositorio = new SeccionRepositorio(_contexto);

                Alumno _ = _alumnoRepositorio.GetOne(x => x.Id == entidad.Id);
                if (_ != null)
                {
                    bool quitarMatriculas = _.Estado == EstadoAlumno.ACTIVO && entidad.Estado == EstadoAlumno.BAJA;

                    _.Nombre = entidad.Nombre;
                    _.Apellido = entidad.Apellido;
                    _.Estado = entidad.Estado;

                    _alumnoRepositorio.Update(_);

                    if (quitarMatriculas)
                    {
                        List<Matricula> matriculas = matriculaRepositorio.GetAllBy(x => x.AlumnoId == _.Id && x.Estado == EstadoMatricula.ACTIVO);
                        if (matriculas.Count > 0)
                        {
                            DateTime ahora = DateTime.Now;

                            foreach (Matricula item in matriculas)
                            {
                                item.Estado = EstadoMatricula.BAJA;
                                item.Anulacion = ahora;
                            }

                            int[] seccionIds = matriculas.Select(x => x.SeccionId).ToArray();
                            List<Seccion> secciones = seccionRepositorio.GetAllBy(x => seccionIds.Contains(x.Id));
                            foreach (Seccion item in secciones)
                                item.Matriculado--;

                            matriculaRepositorio.Update(matriculas);
                            seccionRepositorio.Update(secciones);
                        }
                    }

                    _contexto.SaveChanges();
                }
            }
        }
    }
}
