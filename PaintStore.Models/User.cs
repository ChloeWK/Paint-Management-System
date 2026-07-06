using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design.Serialization;

namespace PaintStore.Models;

public class User
{
    [Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    public DateTime CreatedDate { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Phone { get; set; }

    public User(int userId, string userName, string email, string phone)
    {
        UserId = userId;
        CreatedDate = DateTime.Now;
        UserName = userName;
        Email = email;
        Phone = phone;
    }
}
