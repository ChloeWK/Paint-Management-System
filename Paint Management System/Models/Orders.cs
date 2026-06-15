using System;
using System.Net.Http.Headers;

namespace Paint_Management_System.Models;

public class Orders
{
    public DateTime CreateAt { get; set; }
    public PaintProduct Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    public Orders(PaintProduct product, int quantity)
    {
        if (quantity <= 0)
        {
            throw new Exception("Wrong Order");
        }

        Product = product;
        Quantity = quantity;
        TotalPrice = Product.GetFinalPrice(Product.Price) * (decimal)quantity;
    }

    public void DisplayOrder()
    {
        Product.DisplayInfo();
        Console.WriteLine($"Quantity: {Quantity}");
    }

    public void GetTotalPrice()
    {
        Console.WriteLine($"Total Price: {TotalPrice}");
    }
}
