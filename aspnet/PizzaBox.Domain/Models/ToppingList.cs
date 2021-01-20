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

    public void ConvertList(List<string> list)
    {
      // int count = list.Count;
      // if (count == 2)
      // {
      // 	Topping1.Name = list[0];
      // 	Topping2.Name = list[0];
      // 	Topping2.Name = list[0];

      // }
      // else if (count == 3)
      // {

      // }
      // else if (count == 4)
      // {

      // }
      // else if (count == 5)
      // {

      // }
    }
  }
}
