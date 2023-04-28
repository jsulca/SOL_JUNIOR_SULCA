using System.Collections.Generic;

namespace SOL_JUNIOR_SULCA.Entidades.Genericos
{
    public class Curso
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Credito { get; set; }

        public List<Seccion> Secciones { get; set; }
    }
}
