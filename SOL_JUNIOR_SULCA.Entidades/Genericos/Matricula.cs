using SOL_JUNIOR_SULCA.Entidades.Constantes;
using System;
using System.Collections.Generic;

namespace SOL_JUNIOR_SULCA.Entidades.Genericos
{
    public class Matricula
    {
        public int Id { get; set; }

        public string Codigo { get; set; }
        public string NroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public EstadoMatricula Estado { get; set; }
        public TipoMatricula Tipo { get; set; }
        public DateTime Registro { get; set; }
        public DateTime? Anulacion { get; set; }

        public List<MatriculaSeccion> Secciones { get; set; }
    }
}
