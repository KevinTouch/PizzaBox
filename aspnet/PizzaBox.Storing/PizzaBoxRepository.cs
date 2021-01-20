using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{
  public class PizzaBoxRepository
  {
    private readonly PizzaBoxContext _ctx;
    public PizzaBoxRepository(PizzaBoxContext context)
    {
      _ctx = context;
    }

    public List<string> GetStores()
    {
      return _ctx.Stores.Select(s => s.Name).ToList();
    }

    public IEnumerable<Menu> GetMenuItems(string storeName)
    {
      return _ctx.Stores
        .Include(x => x.Menus)
        .FirstOrDefault(s => s.Name == storeName)
        .Menus;
    }

    public IEnumerable<Size> GetSizes()
    {
      return _ctx.Sizes;
    }

    public IEnumerable<Crust> GetCrusts()
    {
      return _ctx.Crusts;
    }

    public IEnumerable<Topping> GetToppings()
    {
      return _ctx.Toppings;
    }
  }
}
