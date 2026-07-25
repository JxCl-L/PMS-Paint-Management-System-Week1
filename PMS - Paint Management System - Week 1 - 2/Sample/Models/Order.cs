using System;
using Sample.Enums;

namespace Sample.Models;

public class Order
{
    public decimal TotalPrice { get; private set; }

    public List<Paint> Paints { get; set; }
    public DateTime CreatedAt {get;}

    public Order(List<Paint> paints)
    {
        if (CheckPaintsNotEmpty(paints))
        {
            Paints = paints;
        }

        // TotalPrice = Paints.Sum(p => p.Price);
        foreach(var item in Paints)
        {
            TotalPrice += item.Price;
        }

        CreatedAt = DateTime.Now;
    }

    public void UpdateTotalPrice()
    {
        TotalPrice = Paints.Sum(p => p.Price);
    }

    public void AddPaintsToOrder(List<Paint> paints)
    {
        if (CheckPaintsNotEmpty(paints))
        {
            Paints.AddRange(paints);
        }
        // also need to update total price
        UpdateTotalPrice();

    }

    private bool CheckPaintsNotEmpty(List<Paint> paints)
    {
        if (paints.Count == 0)
        {
            throw new Exception("Invalid paints parameter");
        }
        return true;
    }

    public bool CheckTooExpensivePaint(decimal expensivePrice)
    {
        int number = Paints.Where(p => p.Price > expensivePrice).Count();
        if(number > 0)
        {
            return true;
        }
        return false;
    }

    public Paint GetMostExpensivePaintProduct()
    {
        Paint paint1 = Paints.OrderByDescending(p => p.Price).First();
        return paint1;
    }

    public void RemoveProduct(int productId)
    {
        // return Paints.Where(p => p.ProductId == productId).Remove();
        Paints.RemoveAll(p => p.ProductId == productId); // right way to remove 

        // also need to update total price
        UpdateTotalPrice();

    }

    public List<Paint> ProductsPriceBetween(decimal small, decimal large)
    {
        return Paints.Where(p => p.Price > small && p.Price < large).ToList();
    }

    // 获取每种油漆**类型**的油漆总价格
    public Dictionary<PaintType, decimal> GetTotalPricesByPaintType()
    {
        return Paints
            .GroupBy(p => p.PaintType) // return Ienumerable with paint type as key
            .ToDictionary(g => g.Key, g => g.Sum(p => p.Price)); // key - paint type, value - price sum
    } 


}

