namespace BakeryInventorySystem.Domain.Order;

public class OrderItem
{
   public int Id { get; set; }
   public int OrderedAmount { get; set; }
   public int ItemId { get; set; }
}