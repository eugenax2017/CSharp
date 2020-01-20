using DemoSuperGuay.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoSuperGuay.Lib.Context
{
    public class DemoSuperGuayDbContext : DbContext
    {
        #region DbSets

        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Lend> Lends { get; set; }
        #endregion

        public DemoSuperGuayDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=DemoSuperGuay.db");
        }
    }
}
