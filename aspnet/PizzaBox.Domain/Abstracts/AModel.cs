using System.Text.Json.Serialization;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class AEntity
  {
    [JsonIgnore]
    public long EntityId { set; get; }
    protected AEntity()
    {
    }
  }
}
