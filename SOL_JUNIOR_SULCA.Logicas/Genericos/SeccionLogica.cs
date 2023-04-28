using SOL_JUNIOR_SULCA.Contextos;
using SOL_JUNIOR_SULCA.Entidades.Filtros;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Repositorios;
using System.Collections.Generic;

namespace SOL_JUNIOR_SULCA.Logicas.Genericos
{
    public class SeccionLogica
    {
        private DataBaseContexto _contexto;
        private SeccionRepositorio _seccionRepositorio;

        public List<Seccion> Listar(SeccionFiltro filtro = null)
        {
            using (_contexto = new DataBaseContexto())
            {
                _seccionRepositorio = new SeccionRepositorio(_contexto);
                return _seccionRepositorio.Listar(filtro);
            }
        }
    }
}
