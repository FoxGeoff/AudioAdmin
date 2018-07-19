using AudioAdmin.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AudioAdmin.API.Data
{
    public class AudioDbContext : DbContext
    {
        public AudioDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //customer
            modelBuilder.Entity<Customer>()
               .Property(t => t.CreatedAt)
               .HasDefaultValueSql("CURRENT_TIMESTAMP()");

            modelBuilder.Entity<Customer>()
               .Property(t => t.UpdatedAt)
               .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP()");

            modelBuilder.Entity<Customer>()
               .Property(t => t.AssociatedEmployeeId)
               .HasDefaultValueSql(null);

            modelBuilder.Entity<Customer>()
                .Property(t => t.AssociatedLocation)
                .HasDefaultValueSql("1");

            modelBuilder.Entity<Customer>()
                .Property(t => t.AssociatedCustomerId)
                .HasDefaultValueSql(null);

            modelBuilder.Entity<Customer>()
                .Property(t => t.BillAddressDifferent)
                .HasDefaultValueSql("0");

            modelBuilder.Entity<Customer>()
                .Property(t => t.IsNotExportedContact)
                .HasDefaultValueSql("0");

            modelBuilder.Entity<Customer>()
               .Property(t => t.IsRegisteredToC4)
               .HasDefaultValueSql("0");

            modelBuilder.Entity<Customer>()
               .Property(t => t.DateAdded)
               .HasDefaultValueSql(null);
        }
    }
}