using System;
using Paint_Management_System.Enumerations;
using Paint_Management_System.Interfaces;

namespace Paint_Management_System.Models;

public class PaintProduct:IBuyable
{
    public float TaxRate { get; init; } = 0.1f;
    const float DefaultDiscount = 0.95f;
    public string Name { get; private set; }
    public PaintTypes Type { get; set; }
    public PaintSpecification Specification { get; set; }
    public decimal Price { get; set; }

    public PaintProduct(string name, PaintTypes type, PaintSpecification specification, decimal price)
    {
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
    }

}
