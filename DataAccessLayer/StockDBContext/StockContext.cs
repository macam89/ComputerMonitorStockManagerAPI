using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;

namespace DataAccessLayer.StockDBContext
{
    public class StockContext : DbContext
    {

        private readonly string _connectionString = "Server=DESKTOP-HRI1QQQ;Database=StockManagerDB;Trusted_Connection=True;MultipleActiveResultSets=true";

        public StockContext()
        {
            Database.SetCommandTimeout(1000);
        }


        public DbSet<Manufacturers> Manufacturers { get; set; }
        public DbSet<Monitors> Monitors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturers>().ToTable("ManufacturersDB");
            modelBuilder.Entity<Monitors>().ToTable("MonitorsDB");
        }


    }
}
