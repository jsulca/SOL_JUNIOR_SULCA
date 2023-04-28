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
            entityType.Property(x => x.Codigo).HasColumnName("CODIGO");
            entityType.Property(x => x.NroDocumento).HasColumnName("NRODOCUMENTO");
            entityType.Property(x => x.Nombre).HasColumnName("NOMBRE");
            entityType.Property(x => x.Apellido).HasColumnName("APELLIDO");
            entityType.Property(x => x.Estado).HasColumnName("ESTADO");
            entityType.Property(x => x.Tipo).HasColumnName("TIPO");
            entityType.Property(x => x.Registro).HasColumnName("REGISTRO");
            entityType.Property(x => x.Anulacion).HasColumnName("ANULACION");
        }
    }
}
