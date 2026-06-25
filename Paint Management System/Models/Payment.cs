using System;
using Paint_Management_System.Enumerations;

namespace Paint_Management_System.Models;

public class Payment
{
    // public List<Payment> Payments = new List<Payment>();
    // public List<Order> Orders = new List<Order>();

    public int PaymentId { get; init; }
    public DateTime CreateAt { get; init; }
    public decimal PaymentAmount { get; set; }
    public Order Order { get; set; }
    public List<Order> Orders { get; set; }
    public PaymentStates PaymentState { get; set; }
    public PaymentMethods PaymentMethod { get; set; }

    public Payment(int paymentId, Order order, PaymentMethods paymentMethod)
    {
        PaymentId = paymentId;
        CreateAt = DateTime.Now;
        Order = order;
        PaymentState = PaymentStates.Pending;
        PaymentMethod = paymentMethod;
    }

    public static void GetLowestPayment(List<Payment> allPayment)
    {
        if (allPayment == null)
        {
            throw new Exception("There is no any payment!");
        }

        decimal lowestPaymentPrice = allPayment.Min(p => p.Order.TotalPrice);
        Console.Write($"The lowest payment price is: {lowestPaymentPrice}");
    }
    
    public static Payment GetLatestPayment(List<Payment> allPayment)
    {
        if (allPayment == null)
        {
            throw new Exception("There is no any payment!");
        }

        Payment latestPayment = allPayment.MaxBy(p => p.CreateAt);
        return latestPayment;
    }
}
