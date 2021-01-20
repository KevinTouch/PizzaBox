using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class StoreViewModel
  {
    public Store Store { get; set; }
    public IEnumerable<User> Users { get; set; }
    public string StoreName { get; set; }

  }
}
