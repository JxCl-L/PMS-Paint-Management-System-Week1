using System;

namespace PaintStore.Models.Models;

public class PaintProduct
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedDate { get; set; }

    public decimal Price { get; set; }

    public PaintProduct(string name, decimal price)
    {
        Name = name;
        Price = price;
        CreatedDate = DateTime.Now;
    }

}
