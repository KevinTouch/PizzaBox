using Microsoft.Extensions.Configuration;

namespace PizzaBox.Client.Models
{
  public class UserViewModel
  {
    public string Name { get; set; }
    public OrderViewModel Order { get; set; }

    public UserViewModel(IConfiguration configuration)
    {
      Name = "fred";
      Order = new OrderViewModel(configuration);
    }
  }
}
