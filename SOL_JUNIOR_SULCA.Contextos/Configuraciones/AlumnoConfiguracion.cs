using SOL_JUNIOR_SULCA.Entidades.Genericos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SOL_JUNIOR_SULCA.Contextos.Configuraciones
{
    public class AlumnoConfiguracion
    {
        public static void Configure(EntityTypeConfiguration<Alumno> entityType)
        {
            entityType.ToTable("ALUMNO").HasKey(x => x.Id);

            entityType.Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            entityType.Property(x => x.Codigo).HasColumnName("CODIGO");
            entityType.Property(x => x.Nombre).HasColumnName("NOMBRE");
            entityType.Property(x => x.Apellido).HasColumnName("APELLIDO");
            entityType.Property(x => x.Estado).HasColumnName("ESTADO");
        }
    }
}
