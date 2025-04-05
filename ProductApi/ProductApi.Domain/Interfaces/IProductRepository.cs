using ProductApi.ProductApi.Domain.Entities;

namespace ProductApi.ProductApi.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);

        Task UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);

        Task AddAsync(Product product);

    }
}
