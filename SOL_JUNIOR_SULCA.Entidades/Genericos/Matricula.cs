using SOL_JUNIOR_SULCA.Entidades.Constantes;
using System;

namespace SOL_JUNIOR_SULCA.Entidades.Genericos
{
    public class Matricula
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public int SeccionId { get; set; }

        public DateTime Registro { get; set; }
        public DateTime? Anulacion { get; set; }

        public EstadoMatricula Estado { get; set; }
        public TipoMatricula Tipo { get; set; }

        public Alumno Alumno { get; set; }
        public Seccion Seccion { get; set; }
    }
}
