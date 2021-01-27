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

    public void AddUser(User user)
    {
      _ctx.Add(user);
    }

    public void Save()
    {
      _ctx.SaveChanges();
    }

    public IEnumerable<User> GetUsers(string storeName)
    {
      return _ctx.Users.Include(x => x.Orders).Where(u => u.SelectedStore.Name == storeName);
    }

    public IEnumerable<Store> ReadStores()
    {
      return _ctx.Stores;
    }

    public IEnumerable<Size> ReadSizes()
    {
      return _ctx.Sizes;
    }

    public IEnumerable<Crust> ReadCrusts()
    {
      return _ctx.Crusts;
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
