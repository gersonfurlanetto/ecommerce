using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EcommerceTests
{
  public class ProductControllerPartialUpdateProductTests
  {
    private readonly Mock<IProductService> _mock;
    public ProductControllerPartialUpdateProductTests()
    {
      _mock = new Mock<IProductService>();
    }
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
      _mock.Setup(r => r.UpdateProductAsync(It.IsAny<Product>())).Throws(new Exception(expectedErrorCode));

      var controller = new ProductController(_mock.Object);
      var model = new Product(poolId, It.IsAny<string>(), It.IsAny<double>(), It.IsAny<int>());

      //act
      var result = await controller.PartialUpdateProductAsync(model);

      //assert
      Assert.IsType<StatusCodeResult>(result);
      var statusCodeResult = (result as StatusCodeResult).StatusCode;
      Assert.Equal(400, statusCodeResult);
    }

    [Theory]
    [InlineData(-2)]
    public async void Should_Return_Exception_When_Invalid_Quantity(int quantity)
    {
      //arrange
      _mock.Setup(r => r.UpdateProductAsync(It.IsAny<Product>())).Throws(new Exception("Quantity of product invalid"));

      var controller = new ProductController(_mock.Object);
      var model = new Product(Guid.NewGuid(), It.IsAny<string>(), It.IsAny<double>(), quantity);

      //act
      var result = await controller.PartialUpdateProductAsync(model);

      //assert
      Assert.IsType<StatusCodeResult>(result);
      var statusCodeResult = (result as StatusCodeResult).StatusCode;
      Assert.Equal(404, statusCodeResult);
    }


    [Fact]
    public async void Should_Update_Quantity_When_Valid_Product_And_Valid_Value()
    {
      //arrange
      Product product = new Product(Guid.Parse("dcd79ed9-be66-4042-ad18-d4f6b02370e7"), "Phone", 100.00, 1);
      _mock.Setup(r => r.UpdateProductAsync(It.IsAny<Product>())).Returns(Task.FromResult(product));

      var controller = new ProductController(_mock.Object);
      var model = new Product(Guid.NewGuid(), It.IsAny<string>(), It.IsAny<double>(), 10);

      //act
      var result = await controller.PartialUpdateProductAsync(model);

      //assert
      Assert.IsType<OkResult>(result);
      var statusCodeResult = (result as OkResult).StatusCode;
      Assert.Equal(200, statusCodeResult);
    }


    [Fact]
    public async void Should_Update_Quantity_With_Parameter_Value()
    {
      //arrange
      Guid id = Guid.Parse("dcd79ed9-be66-4042-ad18-d4f6b02370e7");
      Product product = new Product(id, "Phone", 100.00, 10);

      _mock.Setup(r => r.UpdateProductAsync(It.IsAny<Product>())).Returns(Task.FromResult(product));

      var controller = new ProductController(_mock.Object);

      //act
      var result = await controller.PartialUpdateProductAsync(product);

      var okObjectResult = result as OkObjectResult;
      var value = okObjectResult.Value as Product;

      //assert
      Assert.Equal(10, value.Quantity);
    }


  }
}
