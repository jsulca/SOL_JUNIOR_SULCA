namespace SOL_JUNIOR_SULCA.Entidades.Genericos
{
    public class MatriculaSeccion
    {
        public int MatriculaId { get; set; }
        public int SeccionId { get; set; }

        public Matricula Matricula { get; set; }
        public Seccion Seccion { get; set; }
    }
}
