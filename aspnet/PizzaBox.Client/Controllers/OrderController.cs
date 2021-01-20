using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
  public class OrderController : Controller
  {
    private readonly PizzaBoxRepository _ctx;

    public OrderController(PizzaBoxRepository context)
    {
      _ctx = context;
    }

    [Route("Order/{storeName}")]
    [HttpGet] // GET /Order/PizzaHut
    public IActionResult StartOrder(string storeName)
    {
      OrderViewModel model = new OrderViewModel();
      var menu = _ctx.GetMenuItems(storeName);
      model.StoreItems = menu.Select(x => x.ToString()).ToList();
      model.StoreItems.Add("Custom Pizza");
      model.Store = storeName;
      model.Crusts = _ctx.GetCrusts().Select(x => x.ToString()).ToList();
      model.Sizes = _ctx.GetSizes().Select(x => x.ToString()).ToList();
      model.ToppingsShown = _ctx.GetToppings().Select(x => x.ToString()).ToList();
      model.ToppingsPicked = new List<string>();
      TempData["pizzas"] = null;
      return View("Order", model);
    }

    [Route("Order/{storeName}")]
    [HttpPost] // POST /Order/PizzaHut
    public IActionResult NewOrder(string storeName, OrderViewModel model)
    {
      var menu = _ctx.GetMenuItems(storeName);
      model.StoreItems = menu.Select(x => x.ToString()).ToList();
      model.StoreItems.Add("Custom Pizza");
      model.Store = storeName;

      decimal sizePrice = _ctx.GetSizes().FirstOrDefault(s => s.Name == model.Size).Pricing;
      decimal crustPrice = 0;
      decimal toppingPrice = 0;

      if (model.ToppingsPicked == null)
      {
        model.ToppingsPicked = new List<string>();
      }

      if (model.Pizza == "Custom Pizza")
      {
        crustPrice = _ctx.GetCrusts().FirstOrDefault(c => c.Name == model.Crust).Pricing;
        foreach (var topping in model.ToppingsPicked)
        {
          toppingPrice += _ctx.GetToppings().FirstOrDefault(t => t.Name == topping).Pricing;
        }
      }
      else if (model.Pizza == "MeatEaters Pizza")
      {
        model.Crust = "Regular";
        model.ToppingsPicked.Add("Pepperoni");
        model.ToppingsPicked.Add("Italian Sausage");
        model.ToppingsPicked.Add("Meatball");

      }
      else if (model.Pizza == "Vegan Pizza")
      {
        model.Crust = "Regular";
        model.ToppingsPicked.Add("Mushroom");
        model.ToppingsPicked.Add("Red Onions");
        model.ToppingsPicked.Add("Black Olives");
        model.ToppingsPicked.Add("Green Bell Peppers");
      }
      else if (model.Pizza == "Supreme Pizza")
      {
        model.Crust = "Regular";
        model.ToppingsPicked.Add("Pepperoni");
        model.ToppingsPicked.Add("Mushroom");
        model.ToppingsPicked.Add("Red Onions");
        model.ToppingsPicked.Add("Green Bell Peppers");
      }

      model.Crusts = _ctx.GetCrusts().Select(x => x.ToString()).ToList();
      model.Sizes = _ctx.GetSizes().Select(x => x.ToString()).ToList();
      model.ToppingsShown = _ctx.GetToppings().Select(x => x.ToString()).ToList();

      var pizza = new OrderPizzaModel
      {
        Name = model.Pizza,
        Crust = model.Crust,
        Size = model.Size,
        ToppingList = model.ToppingsPicked,
        Cost = crustPrice + sizePrice + toppingPrice
      };

      if (TempData["pizzas"] == null)
      {
        model.Pizzas = new List<OrderPizzaModel>();
      }
      else
      {
        model.Pizzas = JsonSerializer.Deserialize<List<OrderPizzaModel>>((string)TempData["pizzas"]);
      }
      model.Pizzas.Add(pizza);
      TempData["pizzas"] = JsonSerializer.Serialize(model.Pizzas);
      return View("Order", model);
    }
  }
}
