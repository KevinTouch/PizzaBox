using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Store : AEntity
  {
    public string Name { get; set; }
    public List<Order> Orders { get; set; }
    public ICollection<Menu> Menus { get; set; }

    public Store()
    {
      Orders = new List<Order>();
    }

    public void CreateOrder()
    {
      Orders.Add(new Order());
    }

    public bool DeleteOrder(Order order)
    {
      try
      {
        Orders.Remove(order);
        return true;
      }
      catch
      {
        return false;
      }
    }

    public override string ToString()
    {
      return Name;
    }
  }
}
