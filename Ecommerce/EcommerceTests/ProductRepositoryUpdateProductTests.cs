using Ecommerce.Domain.Entities;
using Ecommerce.Infrasctructure;
using Ecommerce.Infrasctructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EcommerceTests
{
  public class ProductRepositoryUpdateProductTests
  {

    [Fact]
    public async void Should_Return_Changed_Product_Quantity_When_Valid_Product()
    {
      //arrange
      Guid id = Guid.Parse("dcd79ed9-be66-4042-ad18-d4f6b02370e7");
      var product = new Product(id, "Phone", 100.00, 1);

      var options = new DbContextOptionsBuilder<DbProjectContext>()
        .UseInMemoryDatabase("DbProjectContext")
        .Options;
      var context = new DbProjectContext(options);
      context.Products.Add(product);
      context.SaveChanges();

      var repository = new ProductRepository(context);
      var productChanged = new Product(id, "Phone", 100.00, 5);

      //act
      var productReturned = await repository.UpdateProductAsync(productChanged);

      //assert
      Assert.Equal(5, productReturned.Quantity);
    }
  }
}
