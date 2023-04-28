using SOL_JUNIOR_SULCA.Entidades.Genericos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SOL_JUNIOR_SULCA.Contextos.Configuraciones
{
    public class CursoConfiguracion
    {
        public static void Configure(EntityTypeConfiguration<Curso> entityType)
        {
            entityType.ToTable("CURSO").HasKey(x => x.Id);

            entityType.Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            entityType.Property(x => x.Descripcion).HasColumnName("DESCRIPCION");
            entityType.Property(x => x.Credito).HasColumnName("CREDITO");
        }
    }
}
