using SOL_JUNIOR_SULCA.Contextos;
using SOL_JUNIOR_SULCA.Entidades.Filtros;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Repositorios.Base;
using System.Collections.Generic;
using System.Linq;

namespace SOL_JUNIOR_SULCA.Repositorios
{
    public class AlumnoRepositorio : BaseRepositorio<Alumno>
    {
        public AlumnoRepositorio(DataBaseContexto contexto) : base(contexto) { }

        public List<Alumno> Listar(AlumnoFiltro filtro) => QueryListar(filtro).ToList();

        #region Metodos

        public IQueryable<Alumno> QueryListar(AlumnoFiltro filtro)
        {
            IQueryable<Alumno> source = _contexto.Alumno.AsQueryable();

            if (filtro != null)
            {
                if (filtro.Estado.HasValue) source = source.Where(x => x.Estado == filtro.Estado);
            }

            return source;
        }

        #endregion
    }
}
