using Common.Lib.Core;
using Common.Lib.Models;
using Microsoft.EntityFrameworkCore;


namespace Common.Lib.DAL.EFCore.Context
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // 1 variant
        {
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\formacio\\Desktop\\Evgenii\\CSharp\\Practica\\EstadisticaDeAlumnos3_WPF_Core\\EstadisticaDeAlumnos3_WPF_Core\\bin\\Debug\\netcoreapp3.0\\Test2.db", b => b.MigrationsAssembly("EstadisticaDeAlumnos3_WPF"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Entity>()
                .Ignore(x => x.CurrentValidation);
        }
    }
}
