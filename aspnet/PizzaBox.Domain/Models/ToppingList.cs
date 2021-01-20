using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class ToppingList : AEntity
  {
    public Topping Topping1 { get; set; }
    public Topping Topping2 { get; set; }
    public Topping Topping3 { get; set; }
    public Topping Topping4 { get; set; }
    public Topping Topping5 { get; set; }
  }
}
