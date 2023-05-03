using SOL_JUNIOR_SULCA.Entidades.Constantes;
using SOL_JUNIOR_SULCA.Entidades.Genericos;

namespace SOL_JUNIOR_SULCA.WebApp.Models
{
    public struct MatriculaModel
    {
        public class Nuevo
        {
            public int? AlumnoId { get; set; }
            public int? SeccionId { get; set; }
            public TipoMatricula? Tipo { get; set; }

            public Matricula Get() => new Matricula
            {
                AlumnoId = AlumnoId.Value,
                SeccionId = SeccionId.Value,
                Tipo = Tipo.Value,
            };
        }
    }
}