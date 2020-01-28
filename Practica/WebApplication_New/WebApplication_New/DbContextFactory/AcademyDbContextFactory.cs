using Academy.Lib.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_New.DbContextFactory
{
    public class AcademyDbContextFactory : IDesignTimeDbContextFactory<AcademyDbContext>
    {
        public AcademyDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            var dbConnection = configuration.GetConnectionString("AcademyDbConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AcademyDbContext>();
            optionsBuilder.UseSqlite(dbConnection, x => x.MigrationsAssembly("WebApplication_New"));

            return new AcademyDbContext(optionsBuilder.Options);
        }
    }
}
