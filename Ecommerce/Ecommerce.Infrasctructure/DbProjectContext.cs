using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Infrasctructure
{
  public class DbProjectContext : DbContext
  {
    public DbProjectContext(DbContextOptions options) : base(options)
    {
    }

    public DbProjectContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Dbtarefas;Trusted_connection=true");

      }
    }

    public DbSet<Product> Products { get; set; }
  }
}
