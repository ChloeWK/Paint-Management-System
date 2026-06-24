using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaintStore.Models.Models;

public class Order
{
    public readonly DateTime CreateAt; // -----> "readonly"状态下只能定义成 字段(field)，而不是属性
    public PaintProduct Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    public User User { get; set; } //即使我们不声明User属性，仍然会建立1：N关系
    
    [ForeignKey]
    public int UserId { get; set; }//即使我们不声明Foreign Key(FK-UserId), ORM仍然会创建FK - UserId（框架会自动给你生成）// Where(o=>o.UserId == userId)

    public Order(PaintProduct product, int quantity)
    {
        if (quantity <= 0)
        {
            throw new Exception("Wrong Order");
        }

        CreateAt = DateTime.Now;
        Product = product;
        Quantity = quantity;
        TotalPrice = Product.GetFinalPrice(Product.Price) * (decimal)quantity;
    }

    public void DisplayOrder()
    {
        Product.DisplayInfo();
        Console.WriteLine($"Quantity: {Quantity}");
        Console.WriteLine($"Date: {CreateAt}");
    }

    public void GetTotalPrice()
    {
        Console.WriteLine($"Total Price: {TotalPrice}");
    }


}
