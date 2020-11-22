using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application
{
  public class ProductService : IProductService
  {
    public async Task<Product> CreateProductAsync(Product product)
    {
      throw new NotImplementedException();
    }

    public async Task<Product> DeleteProductAsync(Product product)
    {
      throw new NotImplementedException();
    }

    public async Task<Product> GetProductAsync(Guid id)
    {
      throw new NotImplementedException();
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
      if (product.Id == Guid.Empty)
      {
        throw new Exception("Id of product is mandatory");
      }

      var newProduct = new Product(product.Id, product.Description, product.Price, product.Quantity);

      return await Task.FromResult(newProduct);
    }
  }
}
