using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class StoreController : Controller
  {
    [HttpGet("store")] // GET /store
    public IActionResult ReadStore()
    {
      StoreViewModel stores = new StoreViewModel();
      ViewData["stores"] = stores.Stores;
      return View("Store", new StoreViewModel());
    }

    [HttpPost]
    public IActionResult CreateStore()
    {
      return null;
    }

    [HttpPut]
    public IActionResult UpdateStore()
    {
      return null;
    }

    [HttpDelete]
    public IActionResult DeleteStore()
    {
      return null;
    }

  }

}
