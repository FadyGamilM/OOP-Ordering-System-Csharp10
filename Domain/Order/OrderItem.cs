namespace BakeryInventorySystem.Domain.Order;

public class OrderItem
{
   public int Id { get; set; }
   public int OrderedAmount { get; set; }
   public int ItemId { get; set; }

   public override string ToString()
   {
      return $"The Ordered Item Has Id = {this.Id}, and the ordered amount from this item is = {this.OrderedAmount}";
   }
}