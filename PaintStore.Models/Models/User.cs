using System;

namespace PaintStore.Models.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public User(string name, string email)
    {
        Name = name;
        Email = email;
        Orders = new List<Order>(); // -----> 用来避免 "Order.XXX" 出现 "null.XXXX" 的情况
    }

    public List<Order> Orders { get; set; } // ---> 通过这种方法来建立User和Order这两个类的1：N关系
}
