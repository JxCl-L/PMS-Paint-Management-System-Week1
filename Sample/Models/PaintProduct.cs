using System;
using Sample.Enums;
using Sample.Interfaces;

namespace Sample.Models;

public class PaintProduct:IBuyable
{
    public readonly decimal TaxRate; // readonly可任何时候最多一次值 无getter/setter
    public const decimal DefaultDiscount = 0.05m; // const声明时就要赋值 无getter/setter

    public string Name { get; set; }
    public PaintType Type { get; set; }
    public PaintSpecification Specification { get; set; }
    public decimal Price { get; set; }
    public PaintProduct(string name, PaintType paintType, PaintSpecification paintSpecification, decimal price)
    {
        Name = name;
        Type = paintType;
        Specification = paintSpecification;
        Price = price;
        TaxRate = 0.1m;
    }
    
    public decimal GetFinalPrice()
    {
        return Price * (1 - DefaultDiscount) * (1 + TaxRate); // 先算折后价，再含税
    }

    public void DisplayInfo()
    {
        System.Console.WriteLine($"Product Name: {Name}");
        System.Console.WriteLine($"Type: {Type}"); // auto print enum type not enum num
        // System.Console.WriteLine($"Specification: {Specification}"); // {Specification} 会直接调用对象的 ToString()，默认输出类名 Sample.Models.PaintSpecification，不是规格内容
        System.Console.Write($"Specification: "); // instead use DisplaySpecification()
        Specification.DisplaySpecification(); // this already printing no need to print returned string
        System.Console.WriteLine($"Price: {Price}\n");
    }

    public decimal GetMaxDiscount(int rate, bool isOverridable)
    {
        // 不太确定这个方法在做什么 是不是这个逻辑
        if (isOverridable)
        {
            return (decimal)rate/100; // 记得rate需要除以100！！！
        }
        return DefaultDiscount;
    }



}
