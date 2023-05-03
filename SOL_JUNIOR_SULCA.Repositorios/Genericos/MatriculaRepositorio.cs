using SOL_JUNIOR_SULCA.Contextos;
using SOL_JUNIOR_SULCA.Entidades.Filtros;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Repositorios.Base;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace SOL_JUNIOR_SULCA.Repositorios
{
    public class MatriculaRepositorio : BaseRepositorio<Matricula>
    {
        public MatriculaRepositorio(DataBaseContexto contexto) : base(contexto) { }

        public List<Matricula> Listar(MatriculaFiltro filtro) => QueryListar(filtro).OrderByDescending(x => x.Id).ToList();

        #region Metodos

        private IQueryable<Matricula> QueryListar(MatriculaFiltro filtro)
        {
            IQueryable<Matricula> source = _contexto.Matricula
                                                    .Include(x => x.Alumno)
                                                    .Include(x => x.Seccion)
                                                    .Include(x => x.Seccion.Curso)
                                                    .AsQueryable();
            
            if (filtro != null)
            {
                if (filtro.Estado.HasValue) source = source.Where(x => x.Estado == filtro.Estado);
                if (filtro.AlumnoId.HasValue) source = source.Where(x => x.AlumnoId == filtro.AlumnoId);
                if (filtro.SeccionId.HasValue) source = source.Where(x => x.SeccionId == filtro.SeccionId);
            }

            return source;
        }

        #endregion
    }
}
