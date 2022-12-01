using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class WebApiContext:DbContext
    {
        public DbSet<CurrentWeather> Weathers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public WebApiContext(DbContextOptions options):base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { BirthDate = new DateTime(2003, 11, 25), Email = "vladklunduk8@gmail.com", Name = "Vlad",Id=1 },
                new Customer { BirthDate = new DateTime(2002, 5, 10), Email = "some@gmail.com", Name = "Vova" ,Id=2}
                );
        }
    }
}