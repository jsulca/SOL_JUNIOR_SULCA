using SOL_JUNIOR_SULCA.Entidades.Constantes;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using System.Linq;

namespace SOL_JUNIOR_SULCA.WebApp.Models
{
    public struct MatriculaModel
    {
        public class Nuevo
        {
            public string Codigo { get; set; }
            public string NroDocumento { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public TipoMatricula? Tipo { get; set; }

            public int[] Secciones { get; set; }

            public Matricula Get() => new Matricula 
            {
                Codigo = Codigo,
                NroDocumento = NroDocumento,
                Nombre = Nombre,
                Apellido = Apellido,
                Tipo = Tipo.Value,

                Secciones = Secciones.Select(x => new MatriculaSeccion { SeccionId = x }).ToList()
            };
        }
    }
}