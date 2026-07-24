using System;


namespace Sample.Models;

public class Order
{
    public DateTime CreatedAt {get;} // mind the type
    // readonly prop: not strictly readonly field => no readonly prefix
    // readonly => have getter, no setter

    public PaintProduct Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    public Order(PaintProduct paintProduct, int quantity)
    {
        CreatedAt = DateTime.Now; // save current time
        Product = paintProduct;
        Quantity = quantity;
        TotalPrice = paintProduct.Price * quantity;
    }

    public string DisplayOrder()
    {
        System.Console.WriteLine($"Order info: Product {Product.Name}, Quantity: {Quantity}, Total Price: {TotalPrice}");
        return $"Order info: Product {Product.Name}, Quantity: {Quantity}, Total Price: {TotalPrice}";
    }

    public decimal GetTotalPrice()
    {
        return TotalPrice;
    }

}
