using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class CustomerController : Controller
  {
    private readonly IConfiguration _configuration;

    public CustomerController(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    [HttpGet]
    public IActionResult Home()
    {
      return View("home", new UserViewModel(_configuration));
    }
  }
}
