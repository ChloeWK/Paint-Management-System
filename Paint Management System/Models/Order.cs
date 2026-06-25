using System;
using System.Net.Http.Headers;

namespace Paint_Management_System.Models;

public class Order
{
    public readonly DateTime CreateAt; // -----> "readonly"状态下只能定义成 字段(field)，而不是属性
    public PaintProduct Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public int OrderId { get; set; }
    public User User { get; set; }

    public Order(int orderId, PaintProduct product, int quantity, User user)
    {
        if (quantity <= 0)
        {
            throw new Exception("Wrong Order");
        }

        CreateAt = DateTime.Now;
        OrderId = orderId;
        Product = product;
        Quantity = quantity;
        User = user;
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

    public static Order GetMostExpensivePaintProduct(List<Order> allOrders)
    {
        if (allOrders == null || allOrders.Count == 0)
        {
            throw new ArgumentException("There is no existing order", nameof(allOrders));
        }

        Order mostExpensiveOrder = allOrders[0];
        foreach (Order order in allOrders)
        {
            if (order.Product.Price > mostExpensiveOrder.Product.Price)
            {
                mostExpensiveOrder = order;
            }
        }

        Console.WriteLine($"The most expensive paint product is: {mostExpensiveOrder.Product.Name}");
        return mostExpensiveOrder;
    }

    public static void RemovePaintProduct(int orderId, int productId, List<Order> allOrders)
    {
        //Order removeOrder = null;

        int deleteCount = Program.allOrders.RemoveAll(order => order.OrderId == orderId && productId == order.Product.ProductId);
        if (deleteCount > 0)
        {
            Console.WriteLine("Delete Successfully!");
        }
        else { Console.WriteLine("Your Input ID dosen't exist!"); }

    }

    public static Order GetMostExpensiveOrder(List<Order> allOrders)
    {
        Order mostExpensiveOrder = null;
        decimal expensivePrice = 0m;
        foreach (Order order in allOrders)
        {
            if (order.TotalPrice > expensivePrice)
            {
                expensivePrice = order.TotalPrice;
                mostExpensiveOrder = order;
            }
        }
        return mostExpensiveOrder;
    }
    
    public static Order GetLatestOrder(List<Order> allOrders)
    {
        Order latestOrder = null;
        DateTime latestTime = DateTime.MinValue;
        foreach (Order order in allOrders)
        {
            if (order.CreateAt > latestTime)
            {
                latestTime = order.CreateAt;
                latestOrder = order;
            }
        }
        return latestOrder; 
    }

}
