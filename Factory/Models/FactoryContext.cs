using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
  public class FactoryContext : DbContext
  {
    public DbSet<Object> Objects {get; set;}

    public FactoryContext(DbContextOptions options) : base(options) { }
  }
}