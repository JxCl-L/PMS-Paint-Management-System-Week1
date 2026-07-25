using System;
using Sample.Enums;
using Sample.Interfaces;

namespace Sample.Models;

public class Paint:IProduct
{
    public Paint()
    {
        PaintType = PaintType.Unknown;
    }
    public Paint(PaintType paintType)
    {
        // PaintType = PaintType.Basic; // hard code too basic
        PaintType = paintType;
    }

    public int ProductId { get; set; }


    public decimal Price { get; private set; } 
    public void SetPrice(int value)
    {
        if(value <= 0)
        {
            throw new Exception("Value is invalid");
        }
        Price = value;
    }

    public decimal CalculatePrice()
    {
        return Price;
    }

    public PaintType PaintType { get; set; }


}
