using SOL_JUNIOR_SULCA.Contextos;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using SOL_JUNIOR_SULCA.Repositorios.Base;

namespace SOL_JUNIOR_SULCA.Repositorios
{
    public class CursoRepositorio : BaseRepositorio<Curso>
    {
        public CursoRepositorio(DataBaseContexto contexto) : base(contexto) { }
    }
}
