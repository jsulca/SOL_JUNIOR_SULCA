using SOL_JUNIOR_SULCA.Entidades.Genericos;
using System.Data.Entity.ModelConfiguration;

namespace SOL_JUNIOR_SULCA.Contextos.Configuraciones
{
    public class MatriculaSeccionConfiguracion
    {
        public static void Configure(EntityTypeConfiguration<MatriculaSeccion> entityType)
        {
            entityType.ToTable("MATRICULASECCION").HasKey(x => new { x.MatriculaId, x.SeccionId });

            entityType.Property(x => x.MatriculaId).HasColumnName("MATRICULAID");
            entityType.Property(x => x.SeccionId).HasColumnName("SECCIONID");

            entityType.HasRequired(x => x.Matricula).WithMany(x => x.Secciones);
            entityType.HasRequired(x => x.Seccion).WithMany(x => x.Matriculas);
        }
    }
}
