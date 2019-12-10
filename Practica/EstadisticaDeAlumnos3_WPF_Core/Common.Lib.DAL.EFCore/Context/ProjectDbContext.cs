using Common.Lib.Models;
using Common.Lib.Models.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Lib.DAL.EFCore.Context
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Test.db"); 
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
