using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{
  public class PizzaBoxContext : DbContext
  {
    public DbSet<Store> Stores { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Menu> MenuItems { get; set; }
    public DbSet<APizzaModel> Pizzas { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Crust> Crusts { get; set; }
    public DbSet<ToppingList> ToppingLists { get; set; }
    public DbSet<Topping> Toppings { get; set; }

    // PizzaDBContext needs config. The web client provides that configuration, thus we need
    // to reference that project to create the migrations. Migrations will call the constructor
    // for your db context, however our only one constructor takes in a configuration; which
    // comes in the web client.
    //  dotnet ef migrations add InitialCreate -s ../PizzaBox.Client/PizzaBox.Client.csproj
    public PizzaBoxContext(DbContextOptions<PizzaBoxContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Store>().HasKey(s => s.EntityId);
      builder.Entity<User>().HasKey(u => u.EntityId);
      builder.Entity<Order>().HasKey(o => o.EntityId);
      builder.Entity<Menu>().HasKey(m => m.EntityId);
      builder.Entity<Size>().HasKey(s => s.EntityId);
      builder.Entity<Crust>().HasKey(c => c.EntityId);
      builder.Entity<Topping>().HasKey(t => t.EntityId);
      builder.Entity<ToppingList>().HasKey(t => t.EntityId);
      builder.Entity<APizzaModel>().HasKey(p => p.EntityId);


      seedDB(builder);
    }

    private static void seedDB(ModelBuilder builder)
    {
      // Declare and Define Objects
      Store s1 = new Store { EntityId = 1L, Name = "PizzaHut" };
      Store s2 = new Store { EntityId = 2L, Name = "Dominos" };

      Menu m1 = new Menu { EntityId = 1L, Item = "MeatEaters Pizza" };
      Menu m2 = new Menu { EntityId = 2L, Item = "Vegan Pizza" };
      Menu m3 = new Menu { EntityId = 3L, Item = "Supreme Pizza" };

      Crust c1 = new Crust { EntityId = 1L, Name = "Thin", Pricing = 1.00m };
      Crust c2 = new Crust { EntityId = 2L, Name = "Regular", Pricing = 1.50m };
      Crust c3 = new Crust { EntityId = 3L, Name = "Thick", Pricing = 2.00m };

      Size si1 = new Size { EntityId = 1L, Name = "Small", Pricing = 3.00m };
      Size si2 = new Size { EntityId = 2L, Name = "Medium", Pricing = 3.50m };
      Size si3 = new Size { EntityId = 3L, Name = "Large", Pricing = 4.00m };

      Topping t1 = new Topping { EntityId = 1L, Name = "Pepperoni", Pricing = 2.00m };
      Topping t2 = new Topping { EntityId = 2L, Name = "Italian Sausage", Pricing = 2.00m };
      Topping t3 = new Topping { EntityId = 3L, Name = "Meatball", Pricing = 2.00m };
      Topping t4 = new Topping { EntityId = 4L, Name = "Mushroom", Pricing = 1.50m };
      Topping t5 = new Topping { EntityId = 5L, Name = "Red Onions", Pricing = 1.50m };
      Topping t6 = new Topping { EntityId = 6L, Name = "Black Olives", Pricing = 1.50m };
      Topping t7 = new Topping { EntityId = 7L, Name = "Green Bell Peppers", Pricing = 1.50m };

      // Anonymous object to insert into associative table
      var a1 = new { MenusEntityId = 1L, MenusMenu = "MeatEaters Pizza", StoresEntityId = 1L };
      var a2 = new { MenusEntityId = 2L, MenusMenu = "Vegan Pizza", StoresEntityId = 1L };
      var a3 = new { MenusEntityId = 3L, MenusMenu = "Supreme Pizza", StoresEntityId = 2L };

      // Insert the seed data to MS SQL database
      builder.Entity<Store>().HasData(s1);
      builder.Entity<Store>().HasData(s2);

      builder.Entity<Menu>().HasData(m1);
      builder.Entity<Menu>().HasData(m2);
      builder.Entity<Menu>().HasData(m3);

      builder.Entity<Crust>().HasData(c1);
      builder.Entity<Crust>().HasData(c2);
      builder.Entity<Crust>().HasData(c3);

      builder.Entity<Size>().HasData(si1);
      builder.Entity<Size>().HasData(si2);
      builder.Entity<Size>().HasData(si3);

      builder.Entity<Topping>().HasData(t1);
      builder.Entity<Topping>().HasData(t2);
      builder.Entity<Topping>().HasData(t3);
      builder.Entity<Topping>().HasData(t4);
      builder.Entity<Topping>().HasData(t5);
      builder.Entity<Topping>().HasData(t6);
      builder.Entity<Topping>().HasData(t7);

      builder
      .Entity<Store>()
      .HasMany(s => s.Menus)
      .WithMany(s => s.Stores)
      .UsingEntity(j => j.HasData(a1, a2, a3));
    }
  }
}
