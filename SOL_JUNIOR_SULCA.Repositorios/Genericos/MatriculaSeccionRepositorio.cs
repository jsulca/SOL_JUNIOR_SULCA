using SOL_JUNIOR_SULCA.Contextos;
using SOL_JUNIOR_SULCA.Entidades.Filtros;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Repositorios.Base;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace SOL_JUNIOR_SULCA.Repositorios
{
    public class MatriculaSeccionRepositorio : BaseRepositorio<MatriculaSeccion>
    {
        public MatriculaSeccionRepositorio(DataBaseContexto contexto) : base(contexto) { }

        public List<MatriculaSeccion> Listar(MatriculaSeccionFiltro filtro) => QueryListar(filtro).ToList();

        #region Metodos

        private IQueryable<MatriculaSeccion> QueryListar(MatriculaSeccionFiltro filtro)
        {
            IQueryable<MatriculaSeccion> source = _contexto.MatriculaSeccion.Include(x => x.Seccion).Include(x => x.Seccion.Curso).AsQueryable();

            if (filtro != null)
            {
                if (filtro.MatriculaIds != null && filtro.MatriculaIds.Length > 0) source = source.Where(x => filtro.MatriculaIds.Contains(x.MatriculaId));
                if (filtro.SeccionIds != null && filtro.SeccionIds.Length > 0) source = source.Where(x => filtro.SeccionIds.Contains(x.SeccionId));
            }

            return source;
        }

        #endregion

    }
}
