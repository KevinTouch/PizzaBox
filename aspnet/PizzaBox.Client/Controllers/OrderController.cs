using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
  [Route("[controller]")]
  public class OrderController : Controller
  {
    private readonly PizzaBoxContext _ctx;
    public OrderController(PizzaBoxContext context)
    {
      _ctx = context;
    }

    [HttpGet("{store}")] // GET /Store
    public IActionResult ReadOrder(string store)
    {
      OrderViewModel model = new OrderViewModel();
      model.StoreItems = new List<String>() { "MeatEater", "Vegan", "Custom" };
      if (store == "PizzaHat")
      {
        ViewData["Store"] = "PizzaHut";
      }
      else if (store == "Cominos")
      {
        ViewData["Store"] = "Cominos";
      }
      else
      {
        ViewData["Store"] = "nothing";
      }
      return View("Order", model);
    }

    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public IActionResult Post(OrderViewModel model)
    // {
    //   if (ModelState.IsValid)
    //   {
    //     var order = new Order()
    //     {
    //       DateModified = DateTime.Now,
    //       Store = _ctx.Stores.FirstOrDefault(s => s.Name == model.Store)
    //     };

    //     _ctx.Orders.Add(order);
    //     _ctx.SaveChanges();

    //     return View("OrderPlaced");
    //   }

    //   return View("home", model);
    // }
  }
}
