using Ecommerce.Application;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrasctructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EcommerceTests
{
  public class ProductServiceUpdateProductTests
  {

    public static IEnumerable<object?[]> PoolIdErrorTestData
    {
      get
      {
        return new List<object?[]>
         {
             new object?[] { Guid.NewGuid(), "Product not registered"},
             new object?[] { Guid.Empty, "Id of product is mandatory"},
             new object?[] { " ", "Id of product is mandatory"},
         };
      }
    }

    [Theory]
    [MemberData(nameof(PoolIdErrorTestData))]
    public async void Should_Return_Exception_When_Invalid_Product_Id(Guid poolId, string expectedErrorCode)
    {
      //arrange
      var service = new ProductService();
      var productChanged = new Product(poolId, "Phone", 100.00, 5);

      //act
      var result = await service.UpdateProductAsync(productChanged);

      //assert
      Assert.Equal(result.Message, expectedErrorCode);
      Assert.IsType<StatusCodeResult>(result);
      var statusCodeResult = (result as StatusCodeResult).StatusCode;
      Assert.Equal(400, statusCodeResult);
    }

    [Fact]
    public async void Should_Return_Changed_Product_Quantity_When_Valid_Product()
    {
      //arrange
      Guid id = Guid.Parse("dcd79ed9-be66-4042-ad18-d4f6b02370e7");
      var product = new Product(id, "Phone", 100.00, 1);

      var mock = new Mock<IProductRepository>();
      mock.Setup(r => r.UpdateProductAsync(It.IsAny<Product>())).Returns(Task.FromResult(product));

      var service = new ProductService();
      var productChanged = new Product(id, "Phone", 100.00, 5);

      //act
      var productReturned = await service.UpdateProductAsync(productChanged);

      //assert
      Assert.Equal(5, productReturned.Quantity);
    }


    [Fact]
    public async void Should_Return_Exception_When_Invalid_Quantity()
    {
      //arrange
      var service = new ProductService();
      var productChanged = new Product(Guid.NewGuid(), "Phone", 100.00, 5);
      var expectedErrorCode = "Negative quantity is invalid";

      //act
      var result = await service.UpdateProductAsync(productChanged);

      //assert
      Assert.Equal(result.Message, expectedErrorCode);
      Assert.IsType<StatusCodeResult>(result);
      var statusCodeResult = (result as StatusCodeResult).StatusCode;
      Assert.Equal(400, statusCodeResult);
    }


  }
}
