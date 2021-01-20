using System.Collections.Generic;

namespace PizzaBox.Domain.Abstracts
{
  public class OrderPizzaModel
  {
    public string Name { get; set; }
    public string Size { get; set; }
    public string Crust { get; set; }
    public List<string> ToppingList { get; set; }
    public decimal Cost { get; set; }
  }
}
