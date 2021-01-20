using Microsoft.Extensions.Configuration;
using PizzaBox.Storing;

namespace PizzaBox.Client.Models
{
  public class UserViewModel
  {
    public string Name { get; set; }
    public OrderViewModel Order { get; set; }
    public UserViewModel()
    {
    }
  }
}
