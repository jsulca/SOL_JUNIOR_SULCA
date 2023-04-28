using SOL_JUNIOR_SULCA.Contextos.Configuraciones;
using SOL_JUNIOR_SULCA.Entidades.Genericos;
using System;
using System.Data.Entity;

namespace SOL_JUNIOR_SULCA.Contextos
{
    public class DataBaseContexto : DbContext
    {
        public DbSet<Matricula> Matricula { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Seccion> Seccion { get; set; }
        public DbSet<MatriculaSeccion> MatriculaSeccion { get; set; }

        public DataBaseContexto(): base("name=OracleConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SYSTEM");

            CursoConfiguracion.Configure(modelBuilder.Entity<Curso>());
            MatriculaConfiguracion.Configure(modelBuilder.Entity<Matricula>());
            SeccionConfiguracion.Configure(modelBuilder.Entity<Seccion>());
            MatriculaSeccionConfiguracion.Configure(modelBuilder.Entity<MatriculaSeccion>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
