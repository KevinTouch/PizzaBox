using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Menu : AEntity
  {
    public string Item { get; set; }
    public ICollection<Store> Stores { get; set; }

    public override string ToString()
    {
      return Item;
    }
  }
}
