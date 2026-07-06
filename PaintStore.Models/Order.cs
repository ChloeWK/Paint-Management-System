using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaintStore.Models;

public class Order
{
    [Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }

    public DateTime CreatedDate { get; set; }

    [Required]
    public List<PaintProduct> PaintProducts { get; set; }

    //[ForeignKey]
    public int UserId { get; set; }

    public decimal TotalPrice { get; set; }

    public Order(int orderId, List<PaintProduct> paintProducts, int userId)
    {
        OrderId = orderId;
        CreatedDate = DateTime.Now;
        PaintProducts = paintProducts;
        UserId = userId;
        TotalPrice = paintProducts.Sum(p => p.Price);
    }
}
