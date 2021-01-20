using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
  [Route("[controller]")]
  public class StoreController : Controller
  {
    private readonly PizzaBoxRepository _ctx;
    public StoreController(PizzaBoxRepository context)
    {
      _ctx = context;
    }

    [HttpGet] // GET /Store
    public IActionResult ReadStore()
    {
      StoreViewModel stores = new StoreViewModel();
      ViewData["Stores"] = _ctx.GetStores();
      return View("Store", stores);
    }
  }

}
