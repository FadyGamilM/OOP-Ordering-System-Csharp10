namespace BakeryInventorySystem;
using BakeryInventorySystem.types;

public class Ingredient
{
    // primary key 
    private int Id;

    // name is must, and its by default is an empty string
    private string name = string.Empty;

    // description is an optional attribute 
    
    private string? Description;

    // the max amount of items that can be stored in the stock from this ingredient 
    private int MaxInStock = 0;

    // indicator if this ingredient reached the low threshold level in stock or not yet
    private bool IsLowInStock = false;

    // how we are going to store the ingredient 
    private StoringType StoringUnit;
}