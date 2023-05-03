using SOL_JUNIOR_SULCA.Entidades.Constantes;

namespace SOL_JUNIOR_SULCA.Entidades.Filtros
{
    public class MatriculaFiltro
    {
        public int? AlumnoId { get; set; }
        public int? SeccionId { get; set; }
        public EstadoMatricula? Estado { get; set; }
    }
}
