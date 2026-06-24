using System;
using Paint_Management_System.Enumerations;
using Paint_Management_System.Interfaces;

namespace Paint_Management_System.Models;

public class PaintProduct : IBuyable
{
    public const float TaxRate = 0.1f;  // ------> 我将该field设置为"Constant"常量，就不需要{get; set;}了。 常量一般用于定义一个固定不变的值
    const float DefaultDiscount = 0.95f;
    public int ProductId { get; private set; }
    public string Name { get; private set; }
    public PaintTypes Type { get; set; }
    public PaintSpecification Specification { get; set; }
    public decimal Price { get; set; }

    public PaintProduct(int productId, string name, PaintTypes type, PaintSpecification specification, decimal price)
    {
        ProductId = productId;
        Name = name;
        Type = type;
        Specification = specification;
        Price = price;
    }

    public decimal GetFinalPrice(decimal originalPrice)
    {
        if (originalPrice <= 0)
        {
            throw new Exception("The wrong order");
        }

        decimal totalPrice = originalPrice * (decimal)DefaultDiscount * (1 + (decimal)TaxRate);

        return totalPrice;
        
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Product Name: {Name}");
        Console.WriteLine($"Paint Type: {Type}");
        Specification.DisplaySpecification();
        Console.WriteLine($"Product Price: {Price}");
        Console.WriteLine($"Discount: {DefaultDiscount}");
    }

    

}
