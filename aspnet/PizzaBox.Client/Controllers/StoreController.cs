using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
  public class StoreController : Controller
  {
    private readonly PizzaBoxRepository _ctx;
    public StoreController(PizzaBoxRepository context)
    {
      _ctx = context;
    }

    [Route("Store/Client")]
    [HttpGet]
    public IActionResult Client()
    {
      StoreViewModel stores = new StoreViewModel();
      ViewData["Stores"] = _ctx.GetStores();
      return View("Store", stores);
    }

    [Route("Store/Admin")]
    [HttpGet]
    public IActionResult Admin()
    {
      StoreViewModel stores = new StoreViewModel();
      ViewData["Stores"] = _ctx.GetStores();
      return View("StoreAdmin", stores);
    }


    [Route("Store/Admin/OrderHistory/{storeName}")]
    [HttpGet]
    public IActionResult ShowOrderHistory(string storeName)
    {
      StoreViewModel model = new StoreViewModel();
      Store store = _ctx.ReadStores().FirstOrDefault(s => s.Name == storeName);
      model.StoreName = storeName;
      model.Users = _ctx.GetUsers(storeName);
      model.Store = store;

      return View("OrderHistory", model);
    }

    [Route("Store/Admin/OrderSale/{storeName}")]
    [HttpGet]
    public IActionResult ShowStoreOrderSale(string storeName)
    {
      StoreViewModel model = new StoreViewModel();
      model.StoreName = storeName;
      return View("OrderSale", model);
    }

  }
}
