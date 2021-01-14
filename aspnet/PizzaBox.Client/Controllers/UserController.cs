using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class UserController : Controller
  {
    private readonly PizzaBoxRepository _ctx;
    public UserController(PizzaBoxRepository context)
    {
      _ctx = context;
    }

    [HttpGet]
    public IActionResult Home()
    {
      var customer = new UserViewModel();

      customer.Order = new OrderViewModel()
      {
        Stores = _ctx.GetStores()
      };

      return View("home", customer);
    }
  }
}
