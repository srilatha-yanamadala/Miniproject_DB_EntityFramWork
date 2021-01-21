using Microsoft.EntityFrameworkCore;
using project.Domain;
using System;


namespace Miniproject.Data
{
    public class projContext : DbContext 
    { 
  
       // public DbSet<Asset> assets{ get; set; }
        public DbSet<Computer> computers { get; set; }
        public DbSet<ExchangeRate> exchangeRates { get; set; }
        public DbSet<Office> offices { get; set; }
        public DbSet<Phone> phones{ get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = MiniProject.Data");
        }
    }

}
