using SOL_JUNIOR_SULCA.Entidades.Constantes;
using System.Collections.Generic;

namespace SOL_JUNIOR_SULCA.Entidades.Genericos
{
    public partial class Seccion
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public string Descripcion { get; set; }
        public int Vacante { get; set; }
        public int Matriculado { get; set; }
        public EstadoSeccion Estado { get; set; }

        public Curso Curso { get; set; }

        public List<Matricula> Matriculas { get; set; }
    }
}
