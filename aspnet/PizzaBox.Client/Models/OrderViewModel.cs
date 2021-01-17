using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaBox.Storing;

namespace PizzaBox.Client.Models
{
  public class OrderViewModel
  {
    public List<string> StoreItems { get; set; }

    [Required]
    public string Store { get; set; }
  }
}
