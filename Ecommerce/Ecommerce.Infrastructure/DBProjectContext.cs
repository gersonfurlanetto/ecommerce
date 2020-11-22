using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Infrastructure
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

    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Product> Products { get; set; }
  }
}
