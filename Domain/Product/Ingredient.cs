using System.Text;
namespace BakeryInventorySystem.Domain.Product;
using BakeryInventorySystem.types;

public class Ingredient
{
   // primary key 
   public int Id { get; private set; }

   // name is must, and its by default is an empty string
   private string name = String.Empty;
   public string Name
   {
      get { return this.name; }
      set
      {
         if (value.Length > 100)
         {
            this.name = value[..50]; // truncate to 50 chars only
         }
         else
         {
            this.name = value;
         }
      }
   }

   // the price of the ingredient
   public Price? Price { get; set; }

   // description is an optional attribute 
   private string? description;
   public string? Description
   {
      get { return this.description; }
      set { this.description = value; }
   }

   // the max amount of items that can be stored in the stock from this ingredient 
   private int MaxInStock = 0;

   // indicator if this ingredient reached the low threshold level in stock or not yet
   private bool IsLowInStock = false;

   // how we are going to store the ingredient 
   private StoringType StoringUnit = new StoringType { };

   // the current ammount of this ingredient 
   private int currentAmountInStock = 0;
   public int CurrentAmountInStock { get { return this.currentAmountInStock; } private set { this.currentAmountInStock = value; } }

   // the lowest threshold in the stock
   private int LowThreshold = 10;

   // simple logger
   private void Log(string msg)
   {
      System.Console.WriteLine(msg);
   }

   // alert if the stock has an amount less than the low-threshold
   private bool Alert_if_Low_In_Stock()
   {
      if (this.CurrentAmountInStock <= this.LowThreshold)
      {
         this.IsLowInStock = true;
         Log($"The {this.name} item is low in the stock, the remaining amount is {this.CurrentAmountInStock} {this.StoringUnit}");
         return true;
      }
      else
      {
         return false;
      }
   }

   // use this ingredient in some product
   public void Use_Ingredient(int numberOfNeededItems)
   {
      if (numberOfNeededItems <= this.CurrentAmountInStock)
      {
         Log($"you don't have enough of the ingredient {this.name} in the stock !");
         return;
      }
      else if (this.CurrentAmountInStock - numberOfNeededItems <= this.LowThreshold)
      {
         Alert_if_Low_In_Stock();
         this.CurrentAmountInStock -= numberOfNeededItems;
         Log($"You have consumed {numberOfNeededItems} {this.StoringUnit} of {this.name}, the remaining in the stock is {this.CurrentAmountInStock}");
      }
   }

   // increase the number of items in the stock
   public void Increase_amount_in_stock(int amount = 1)
   {
      this.CurrentAmountInStock += amount;
   }

   // decrase by specific amount from the stock
   private void Decrease_amount_in_stock(int amount = 1)
   {
      if (this.CurrentAmountInStock >= amount)
      {
         this.CurrentAmountInStock -= amount;
         Alert_if_Low_In_Stock();
      }
   }

   // to display the ingredient details 
   private string Get_ingredient_details()
   {
      StringBuilder sb = new StringBuilder { };
      sb.Append($"Ingredient number : {this.Id}");
      sb.Append($"Ingredient name : {this.name}");
      sb.Append($"Ingredient description : {this.Description}");
      sb.Append($"Amount In Stock : {this.CurrentAmountInStock}");
      if (this.IsLowInStock) sb.Append($"LOW IN THE STOCK !!");

      return sb.ToString();
   }
}