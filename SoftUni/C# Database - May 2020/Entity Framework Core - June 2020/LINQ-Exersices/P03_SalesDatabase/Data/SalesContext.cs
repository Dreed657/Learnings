using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        private string conString = @"Server=.;Database=SalesDb;Integrated Security=true;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this.conString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.Property(t => t.Description)
                    .HasDefaultValue("No description");
            });

            modelBuilder.Entity<Sale>(e =>
            {
                e.Property(t => t.Date)
                    .HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
