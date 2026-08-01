using System;

namespace PaintStore.Models.Models;

public class Order
{
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public List<PaintProduct> PaintProducts { get; set; }

    public int UserId { get; set; }

    // public decimal TotalPrice { get; set; } // issue: when PaintProducts change, TotalPrice not update itself => go stale
    public decimal TotalPrice => PaintProducts.Sum(p => p.Price); // computed property: auto update

    public Order(List<PaintProduct> paintProducts, int userId)
    {
        PaintProducts = paintProducts;
        CreatedDate = DateTime.Now;
        UserId = userId;
        // TotalPrice = CalculateTotalPrice(); // remove this because TotalPrice change to computed property auto update
    }

    // public decimal CalculateTotalPrice()
    // {
    //     return PaintProducts.Sum(p => p.Price);
    // } // remove this because TotalPrice change to computed property auto update


}
