using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Order : AEntity
  {
    public List<APizzaModel> Pizzas { get; set; }

    public DateTime OrderTime { get; set; }

    public Order()
    {
      Pizzas = new List<APizzaModel>();
      OrderTime = DateTime.Now;
    }
  }
}
