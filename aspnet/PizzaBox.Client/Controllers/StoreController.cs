using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controllers
{
  [Route("[controller]")]
  public class StoreController : Controller
  {
    [HttpGet] // GET /Store
    public IActionResult ReadStore()
    {
      StoreViewModel stores = new StoreViewModel();
      ViewData["Stores"] = stores.Stores;
      return View("Store", stores);
    }

    // [HttpPost]
    // public IActionResult CreateStore(StoreViewModel model)
    // {
    //   if (ModelState.IsValid)
    //   {
    //     var store = new Store();
    //     List<string> stores = model.Stores;
    //     store.Name = stores.Last();
    //     return View("Store");
    //   }
    //   return View("home", model);
    // }

    // [HttpPut]
    // public IActionResult UpdateStore()
    // {
    //   return null;
    // }

    // [HttpDelete]
    // public IActionResult DeleteStore()
    // {
    //   return null;
    // }

  }

}
