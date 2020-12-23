using Microsoft.EntityFrameworkCore;

namespace ProjectName.Models
{
  public class ProjectNameContext : DbContext
  {
    public DbSet<Object> Objects {get; set;}

    public ProjectNameContext(DbContextOptions options) : base(options) { }
  }
}