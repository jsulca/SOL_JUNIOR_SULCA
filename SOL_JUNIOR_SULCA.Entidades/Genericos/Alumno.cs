using SOL_JUNIOR_SULCA.Entidades.Constantes;
using System.Collections.Generic;

namespace SOL_JUNIOR_SULCA.Entidades.Genericos
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public EstadoAlumno Estado { get; set; }

        public List<Matricula> Matriculas { get; set; }
    }
}
