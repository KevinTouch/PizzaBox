using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class User : AEntity
  {
    public List<Order> Orders { get; set; }
    public Store SelectedStore { get; set; }

    public User()
    {
      Orders = new List<Order>();
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      foreach (var p in Orders.Last().Pizzas)
      {
        sb.AppendLine(" -" + p.ToString());
      }

      return $"I have selected this store {SelectedStore} and ordered these pizzas: \n{sb.ToString()}";
    }
  }
}
