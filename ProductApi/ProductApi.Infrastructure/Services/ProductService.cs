using Microsoft.EntityFrameworkCore;
using ProductApi.ProductApi.Domain.Entities;
using ProductApi.ProductApi.Domain.Interfaces;
using ProductApi.ProductApi.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly AppDbContext _dbContext;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)  
        {
            return await _productRepository.GetByIdAsync(id);
            
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var existingProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (existingProduct == null)
            {
                return null; // Ürün bulunamadıysa null döneriz
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            await _dbContext.SaveChangesAsync();

            return existingProduct; // Güncellenmiş ürünü döndürür
        }



        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }

       

        public async Task<Product> CreateProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            // Veritabanına yeni ürünü ekle
            await _productRepository.AddAsync(product);

            // Eklenen ürünü geri döndür
            return product;
        }


    }
}
