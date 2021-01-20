using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Client.Models
{
  public class OrderViewModel
  {
    public List<string> StoreItems { get; set; }
    public string Store { get; set; }
    public string Pizza { get; set; }
    public string Size { get; set; }
    public string Crust { get; set; }
    public List<string> Sizes { get; set; }
    public List<string> Crusts { get; set; }
    public List<string> ToppingsShown { get; set; }
    public List<string> ToppingsPicked { get; set; }
    public List<OrderPizzaModel> Pizzas { get; set; }
    public decimal TotalCost { get; set; }
  }
}
