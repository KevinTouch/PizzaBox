using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Size : AEntity
  {
    public string Name { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Pricing { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}
