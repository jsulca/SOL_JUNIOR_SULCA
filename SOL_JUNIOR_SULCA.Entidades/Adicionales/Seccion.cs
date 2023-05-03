namespace SOL_JUNIOR_SULCA.Entidades.Genericos
{
    public partial class Seccion
    {
        public int Disponible { get => Vacante - Matriculado; }
    }
}
