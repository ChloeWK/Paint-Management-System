using System;
using Paint_Management_System.Enumerations;

namespace Paint_Management_System.Models;

public class Payment
{
    public List<Payment> Payments = new List<Payment>();
    public List<Order> Orders = new List<Order>();

    public int PaymentId { get; init; }
    public decimal PaymentAmount { get; set; }
    public Order Order { get; set; }
    public User User { get; set; }
    public PaymentStates PaymentState { get; set; }
    public PaymentMethods PaymentMethod { get; set; }

    public Payment(int paymentId, User user, Order order, PaymentMethods paymentMethod)
    {
        PaymentId = paymentId;
        User = user;
        Order = order;
        Orders.Add(order);
        PaymentState = PaymentStates.Pending;
        PaymentMethod = paymentMethod;
    }
}
