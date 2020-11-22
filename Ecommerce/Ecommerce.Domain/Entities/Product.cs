using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Entities
{
  public class Product
  {
    public Product(Guid id, string description, double price, int quantity)
    {
      Id = id;
      Description = description;
      Price = price;
      Quantity = quantity;
    }

    public Guid Id { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
  }
}
