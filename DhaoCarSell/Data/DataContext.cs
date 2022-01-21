using CarSellApp.Models;
using DhaoCarSell.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DhaoCarSell.Data
{
    public class DataContext : DbContext
    {
        //Configure DataContext through adding connection string to the DbContextOptionsBuilder
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DbConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Contact)
                .WithOne(c => c.Car)
                .HasForeignKey<Contact>(c => c.CarRef);   
                
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Contact> Contact { get; set; }

    }    
}
