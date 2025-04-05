using Microsoft.EntityFrameworkCore;
using ProductApi.ProductApi.Domain.Entities;

namespace ProductApi.ProductApi.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }

}
