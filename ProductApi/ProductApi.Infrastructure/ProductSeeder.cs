using ProductApi.ProductApi.Domain.Entities;
using ProductApi.ProductApi.Infrastructure.Data;

namespace ProductApi.ProductApi.Infrastructure
{
    public class ProductSeeder
    {
        private readonly AppDbContext _context;

        public ProductSeeder(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // Eğer veritabanında ürünler yoksa, ekleme işlemi yapalım
            if (!_context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product { Name = "Ürün 1", Price = 1000 },
                    new Product { Name = "Ürün 2", Price = 1500 },
                    new Product { Name = "Ürün 3", Price = 2000 }
                };

                _context.Products.AddRange(products);
                await _context.SaveChangesAsync();
            }
        }
    }
}
