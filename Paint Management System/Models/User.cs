using System;

namespace Paint_Management_System.Models;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    private string Street { get; set; }

    public User(int userId, string userName, string streetName)
    {
        UserId = userId;
        UserName = userName;
        Street = streetName;
    }

    public void ChangeAddress(string streetName)
    {
        if (string.IsNullOrEmpty(streetName)) //  = (streetName == null || streetName == "")
        {
            throw new Exception("Wrong Street Name!");
        }

        Street = streetName;
    }

    public void DisplayUserInfo()
    {
        Console.WriteLine($"User ID: {UserId}User Name: {UserName}");
    }

    public void UpdateUserInfo(List<User> allUsers, int id, string name)
    {
        foreach (User user in allUsers)
        {
            if (id == user.UserId)
            {
                UserName = name;
            }
        }
    }

    public List<Order> orderHistory;
    public List<Payment> paymentHistory;
}
