using AudioAdmin.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AudioAdmin.API.Data
{
    public class AudioDbContext : DbContext
    {
        public AudioDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<ProductImage> ProductImages { get; set; }
    }
}