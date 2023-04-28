using SOL_JUNIOR_SULCA.Entidades.Constantes;

namespace SOL_JUNIOR_SULCA.Entidades.Filtros
{
    public class MatriculaFiltro
    {
        public string Codigo { get; set; }
        public string NroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public EstadoMatricula? Estado { get; set; }
    }
}
