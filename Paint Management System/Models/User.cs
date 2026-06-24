using System;

namespace Paint_Management_System.Models;

public class User
{
    public string UserName { get; set; }
    public int UserAge { get; set; }
    private string Street { get; set; }

    public User(string userNmae, int userAge, string streetName)
    {
        UserName = UserName;
        UserAge = userAge;
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
        Console.WriteLine($"User Name: {UserName}, User Age: {UserAge}");
    }

    public void UpdateUserInfo(string name, int age)
    {
        UserName = name;
        UserAge = age;
    }
    
    public List<Order> orderHistory;
    public List<Payment> paymentHistory;
}
