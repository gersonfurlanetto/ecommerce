using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ecommerce.WebApp.Controllers
{
  [ApiController]
  public class ProductController : ControllerBase
  {
    IProductService _productService;

    public ProductController(IProductService productService)
    {
      _productService = productService;
    }


    [HttpPatch]
    public async Task<IActionResult> PartialUpdateProductAsync(Product product)
    {
      try
      {
        var response = await _productService.UpdateProductAsync(product);
        return StatusCode(200, new JsonResult(response));

      }
      catch (Exception e)
      {
        if (e.Message == "Id of product is mandatory")
        {
          return StatusCode(400);
        }
        else if (e.Message == "Quantity of product invalid")
        {
          return StatusCode(404);
        }
        else
        {
          return StatusCode(500);
        }
      }
    }
  }
}
