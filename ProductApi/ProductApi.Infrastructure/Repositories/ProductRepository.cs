using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProductApi.ProductApi.Domain.Entities;
using ProductApi.ProductApi.Domain.Interfaces;
using ProductApi.ProductApi.Infrastructure.Data;

namespace ProductApi.ProductApi.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Product>> GetAllAsync()  // Burada metodun ismini GetAllAsync olarak güncelledik
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);
            if (existingProduct == null)
            {
                return null; // Eğer ürün bulunamazsa null döndür
            }

            // Ürünü güncelle
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            // Veritabanında değişiklikleri kaydet
            await _context.SaveChangesAsync();

            return existingProduct;  // Güncellenmiş ürünü döndür
        }


        Task IProductRepository.UpdateAsync(Product product)
        {
            return UpdateAsync(product);
        }
    }
}
