using SOL_JUNIOR_SULCA.Entidades.Constantes;

namespace SOL_JUNIOR_SULCA.Entidades.Filtros
{
    public class SeccionFiltro
    {
        public int? Id { get; set; }
        public int[] Ids { get; set; }
        public bool ConVacantes { get; set; }
    }
}
