using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{
  public class PizzaBoxContext : DbContext
  {
    public DbSet<Store> Stores { get; set; }
    public DbSet<Order> Orders { get; set; }

    public PizzaBoxContext(DbContextOptions<PizzaBoxContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Store>().HasKey(s => s.EntityId);
      builder.Entity<Order>().HasKey(o => o.EntityId);

      builder.Entity<Store>().HasData(
        new Store() { EntityId = 1, Name = "Texas" },
        new Store() { EntityId = 2, Name = "Maryland" },
        new Store() { EntityId = 3, Name = "Florida" }
      );
    }
  }
}
