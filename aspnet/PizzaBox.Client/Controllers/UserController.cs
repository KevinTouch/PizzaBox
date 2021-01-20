using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using System.Text.Json;
using System.Collections.Generic;

namespace PizzaBox.Client.Controllers
{
  public class UserController : Controller
  {
    private readonly PizzaBoxRepository _ctx;
    private static List<Store> _stores;
    private static List<Size> _size;
    private static List<Crust> _crust;
    private static List<Topping> _listOfToppings;
    public UserController(PizzaBoxRepository context)
    {
      _ctx = context;
      _stores = _ctx.ReadStores().ToList();
      _size = _ctx.ReadSizes().ToList();
      _crust = _ctx.ReadCrusts().ToList();
      _listOfToppings = _ctx.GetToppings().ToList();
    }

    [HttpPost]
    [Route("User/{storeName}")]
    public IActionResult CheckoutOrder(string storeName, OrderViewModel model)
    {
      UserViewModel userView = new UserViewModel();
      userView.Order = new OrderViewModel();
      userView.Order.Pizzas = JsonSerializer.Deserialize<List<OrderPizzaModel>>((string)TempData["pizzas"]);

      // User creates an order
      User user = new User();
      user.SelectedStore = _stores.FirstOrDefault(s => s.Name == storeName);
      user.SelectedStore.CreateOrder();
      user.Orders.Add(user.SelectedStore.Orders.Last());


      // Add list of pizzas to the current order of the user
      // Currently have Pizza as a string data -> aPizzaModel
      decimal totalCost = 0;
      foreach (var pizza in userView.Order.Pizzas)
      {
        APizzaModel pizzaModel = new APizzaModel();
        pizzaModel.Size = _size.FirstOrDefault(s => s.Name == pizza.Size);
        pizzaModel.Crust = _crust.FirstOrDefault(c => c.Name == pizza.Crust);
        pizzaModel.AToppingList = new ToppingList();
        for (int i = 0; i < pizza.ToppingList.Count; ++i)
        {
          var topping = _listOfToppings.FirstOrDefault(t => t.Name == pizza.ToppingList[i]);
          if (i == 0)
          {
            pizzaModel.AToppingList.Topping1 = topping;
          }
          else if (i == 1)
          {
            pizzaModel.AToppingList.Topping2 = topping;
          }
          else if (i == 2)
          {
            pizzaModel.AToppingList.Topping3 = topping;
          }
          else if (i == 3)
          {
            pizzaModel.AToppingList.Topping4 = topping;
          }
          else
          {
            pizzaModel.AToppingList.Topping5 = topping;
          }
        }
        totalCost += pizza.Cost;
        user.Orders.Last().Pizzas.Add(pizzaModel);
      }

      userView.Order.TotalCost = totalCost;

      // Saving user/order/pizza info to db
      _ctx.AddUser(user);
      _ctx.Save();

      // Print out order
      return View("User", userView);
    }
  }
}
