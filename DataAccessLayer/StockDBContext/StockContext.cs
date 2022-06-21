using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.StockDBContext
{
    public class StockContext : DbContext
    {

        public static string _connectionString; 


        public StockContext()
        {
            Database.SetCommandTimeout(1000);
        }


        public DbSet<Manufacturers> Manufacturers { get; set; }
        public DbSet<Monitors> Monitors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(_connectionString)) 
            {
                ReadConnectionString();
            }

            optionsBuilder.UseSqlServer(_connectionString);
        }


        private static void ReadConnectionString() 
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = configuration.GetConnectionString("StockManagerDBConnectionString");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturers>().ToTable("ManufacturersDB");
            modelBuilder.Entity<Monitors>().ToTable("MonitorsDB");
        }


    }
}
