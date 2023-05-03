using SOL_JUNIOR_SULCA.Entidades.Genericos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SOL_JUNIOR_SULCA.Contextos.Configuraciones
{
    public class MatriculaConfiguracion
    {
        public static void Configure(EntityTypeConfiguration<Matricula> entityType)
        {
            entityType.ToTable("MATRICULA").HasKey(x => x.Id);

            entityType.Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            entityType.Property(x => x.AlumnoId).HasColumnName("ALUMNOID");
            entityType.Property(x => x.SeccionId).HasColumnName("SECCIONID");

            entityType.Property(x => x.Registro).HasColumnName("REGISTRO");
            entityType.Property(x => x.Anulacion).HasColumnName("ANULACION");
            entityType.Property(x => x.Estado).HasColumnName("ESTADO");
            entityType.Property(x => x.Tipo).HasColumnName("TIPO");

            entityType.HasRequired(x => x.Alumno).WithMany(x => x.Matriculas);
            entityType.HasRequired(x => x.Seccion).WithMany(x => x.Matriculas);
        }
    }
}
