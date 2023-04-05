using System.Text;
namespace BakeryInventorySystem.Domain.Order;

public class Order
{
   public int Id { get; set; }
   public List<OrderItem> OrderedItems { get; set; } = new List<OrderItem> { };
   public DateOnly OrderedAt { get; set; }
   public DateOnly FullfillmentDate { get; set; }
   public bool IsFullfilled = false;

   public Order()
   {
      // random id 
      this.Id = new Random().Next(1000_000_000);

      // random fullfillment date 
      this.FullfillmentDate.AddDays(new Random().Next(10));
   }

   public override string ToString()
   {
      var sb = new StringBuilder { };
      sb.Append($"Order Number {this.Id}");
      sb.Append($"Number Of Ordered Items Of This Order {this.OrderedItems.Count}");
      return sb.ToString();
   }

}