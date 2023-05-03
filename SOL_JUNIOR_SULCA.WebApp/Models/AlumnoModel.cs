using SOL_JUNIOR_SULCA.Entidades.Constantes;
using SOL_JUNIOR_SULCA.Entidades.Genericos;

namespace SOL_JUNIOR_SULCA.WebApp.Models
{
    public struct AlumnoModel
    {
        public class Nuevo
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public EstadoAlumno? Estado { get; set; }

            public Alumno ToAlumno() => new Alumno
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Estado = Estado.Value
            };
        }

        public class Editar
        {
            public int? Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public EstadoAlumno? Estado { get; set; }

            public Alumno ToAlumno() => new Alumno
            {
                Id = Id.Value,
                Nombre = Nombre,
                Apellido = Apellido,
                Estado = Estado.Value
            };
        }
    }
}