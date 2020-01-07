using Common.Lib.Models;
using Common.Lib.Models.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstadisticaDeAlumnos3_WPF_Core.Context
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext()
        {

        }
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Examen> Examens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // 1 variant
        {
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\formacio\\Desktop\\Evgenii\\CSharp\\Practica\\EstadisticaDeAlumnos3_WPF_Core\\EstadisticaDeAlumnos3_WPF_Core\\bin\\Debug\\netcoreapp3.0\\Test2.db");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Entity>()
                .Ignore(x => x.CurrentValidation);

            builder.Entity<Examen>()
                .Property(e => e.Date)
                .HasColumnType("date");

            //builder.Entity<Examen>()
            //    .HasKey(e => new { e.Id, e.Date, e.StudentID, e.SubjectID });
            builder.Entity<Examen>()
                .HasOne(e => e.Student)
                .WithMany(e => e.Examens)
                .HasForeignKey(e => e.StudentID);
            builder.Entity<Examen>()
                .HasOne(e => e.Subject)
                .WithMany(e => e.Examens)
                .HasForeignKey(e => e.SubjectID);
        }
    }
}
