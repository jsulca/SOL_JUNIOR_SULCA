using SOL_JUNIOR_SULCA.Entidades.Genericos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SOL_JUNIOR_SULCA.Contextos.Configuraciones
{
    public class SeccionConfiguracion
    {
        public static void Configure(EntityTypeConfiguration<Seccion> entityType)
        {
            entityType.ToTable("SECCION").HasKey(x => x.Id);

            entityType.Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            entityType.Property(x => x.CursoId).HasColumnName("CURSOID");
            
            entityType.Property(x => x.Descripcion).HasColumnName("DESCRIPCION");
            entityType.Property(x => x.Vacante).HasColumnName("VACANTE");
            entityType.Property(x => x.Matriculado).HasColumnName("MATRICULADO");
            entityType.Property(x => x.Estado).HasColumnName("ESTADO");

            entityType.HasRequired(x => x.Curso).WithMany(x => x.Secciones);
        }
    }
}
