using System;
using System.Dynamic;
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

    public static List<PaintProduct> GetSpecificPaintProduct(List<PaintProduct> allProducts)
    {
        if (allProducts == null)
        {
            throw new Exception("There is no any product!");
        }

        return allProducts.Where(p => p.Price > 100.00m && p.Price < 150.00m).ToList();
    }

    public static void GetTotalPriceByPaintType(List<PaintProduct> allProducts)
    {
        if (allProducts == null)
        {
            throw new Exception("There is no any product!");
        }
        decimal totalPriceByType1 = 0m;
        decimal totalPriceByType2 = 0m;
        decimal totalPriceByType3 = 0m;
        foreach (PaintProduct product in allProducts)
        {
            switch (product.Type)
            {
                case PaintTypes.BaseCoat:
                    totalPriceByType1 += product.Price;
                    break;

                case PaintTypes.Glossy:
                    totalPriceByType2 += product.Price;
                    break;

                case PaintTypes.Matte:
                    totalPriceByType3 += product.Price;
                    break;

                default:
                    break;
            }
        }
    }

}
