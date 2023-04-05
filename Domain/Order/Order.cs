namespace BakeryInventorySystem.Domain.Order;

public class Order
{
   public int Id { get; set; }
   public List<OrderItem> OrderedItems { get; set; } = new List<OrderItem> { };
   public DateOnly OrderedAt { get; set; }
   public bool IsFullfilled = false;

}