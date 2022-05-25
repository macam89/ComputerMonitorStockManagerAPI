using ComputerMonitorStockManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerMonitorStockManager.Data
{
    public class StockContext : DbContext
    {
        public DbSet<Manufacturers> Manufacturers { get; set; }
        public DbSet<Monitors> Monitors { get; set; }


        public StockContext(DbContextOptions<StockContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturers>().ToTable("ManufacturersDB");
            modelBuilder.Entity<Monitors>().ToTable("MonitorsDB");
        }


    }
}
