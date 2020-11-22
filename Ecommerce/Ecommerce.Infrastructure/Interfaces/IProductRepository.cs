using Ecommerce.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Interfaces
{
  public interface IProductRepository
  {
    Task<Product> GetProductAsync(Guid id);
    Task<Product> CreateProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task<Product> DeleteProductAsync(Product product);
  }
}
