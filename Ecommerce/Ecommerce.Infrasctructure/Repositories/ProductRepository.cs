using Ecommerce.Domain.Entities;
using Ecommerce.Infrasctructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrasctructure.Repositories
{
  public class ProductRepository : IProductRepository
  {
    DbProjectContext _ctx;

    public ProductRepository(DbProjectContext contexto)
    {
      _ctx = contexto;
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
      _ctx.Products.Add(product);
      _ctx.SaveChanges();
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
      _ctx.Products.Update(product);
      _ctx.SaveChanges();
      throw new NotImplementedException();
    }
  }
}
