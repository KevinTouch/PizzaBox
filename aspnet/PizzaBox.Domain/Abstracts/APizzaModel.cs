using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  public class APizzaModel : AEntity
  {
    public Size Size { get; set; }
    public Crust Crust { get; set; }
    public ToppingList AToppingList { get; set; }
  }
}
