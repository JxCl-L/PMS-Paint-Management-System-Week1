using System;

namespace Sample.Models;

public class PaintSpecification
{
    public string Color { get; set; }

    public int SizeInLiters { get; set; }

    public PaintSpecification(string color, int sizeInLiters)
    {
        if (color == null || sizeInLiters < 0)
        {
            throw new Exception("Invalid paint input");
        }
        Color = color;
        SizeInLiters = sizeInLiters;
    }
    public string DisplaySpecification()
    {
        System.Console.WriteLine($"Color {Color}, size in liters {SizeInLiters}");
        return $"Color {Color}, size in liters {SizeInLiters}";
    }

}
