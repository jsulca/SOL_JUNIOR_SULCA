using SOL_JUNIOR_SULCA.Contextos;
using SOL_JUNIOR_SULCA.Entidades.Filtros;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Repositorios.Base;
using System.Collections.Generic;
using System.Linq;

namespace SOL_JUNIOR_SULCA.Repositorios
{
    public class MatriculaRepositorio : BaseRepositorio<Matricula>
    {
        public MatriculaRepositorio(DataBaseContexto contexto) : base(contexto) { }

        public List<Matricula> Listar(MatriculaFiltro filtro) => QueryListar(filtro).ToList();

        #region Metodos

        private IQueryable<Matricula> QueryListar(MatriculaFiltro filtro)
        {
            IQueryable<Matricula> source = _contexto.Matricula.AsQueryable();

            if (filtro != null)
            {
                if (filtro.Estado.HasValue) source = source.Where(x => x.Estado == filtro.Estado);
                if (!string.IsNullOrEmpty(filtro.Codigo)) source = source.Where(x => x.Codigo.Contains(filtro.Codigo));
                if (!string.IsNullOrEmpty(filtro.Nombre)) source = source.Where(x => x.Nombre.Contains(filtro.Nombre));
                if (!string.IsNullOrEmpty(filtro.Apellido)) source = source.Where(x => x.Apellido.Contains(filtro.Apellido));
                if (!string.IsNullOrEmpty(filtro.NroDocumento)) source = source.Where(x => x.NroDocumento.Contains(filtro.NroDocumento));
            }

            return source;
        }

        #endregion
    }
}
