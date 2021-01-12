using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
  public class StoreViewModel
  {
    public List<string> Stores { get; set; }

    public StoreViewModel()
    {
      Stores = new List<string>
        {
          "PizzaHat",
          "Cominos"
        };

    }
  }
}
