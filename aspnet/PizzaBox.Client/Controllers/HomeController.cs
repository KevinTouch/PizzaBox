using Microsoft.AspNetCore.Mvc;

namespace PizzaBox.Client.Controllers
{
  [Route("/")]
  [Route("[controller]")]
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
