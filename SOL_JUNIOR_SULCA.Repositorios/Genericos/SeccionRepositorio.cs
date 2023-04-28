using SOL_JUNIOR_SULCA.Contextos;
using SOL_JUNIOR_SULCA.Entidades.Filtros;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Repositorios.Base;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace SOL_JUNIOR_SULCA.Repositorios
{
    public class SeccionRepositorio : BaseRepositorio<Seccion>
    {
        public SeccionRepositorio(DataBaseContexto contexto) : base(contexto) { }

        public List<Seccion> Listar(SeccionFiltro filtro) => QueryListar(filtro).ToList();

        #region Metodos

        private IQueryable<Seccion> QueryListar(SeccionFiltro filtro)
        {
            IQueryable<Seccion> source = _contexto.Seccion.Include(x => x.Curso).AsQueryable();

            if (filtro != null)
            {
                if (filtro.Ids != null && filtro.Ids.Length > 0) source = source.Where(x => filtro.Ids.Contains(x.Id));
                if (filtro.ConVacantes) source = source.Where(x => x.VacanteUsada < x.Vacante);
            }

            return source;
        }

        #endregion
    }
}
