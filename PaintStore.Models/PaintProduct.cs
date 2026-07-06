using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaintStore.Models;

public class PaintProduct
{
    [Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PaintId { get; set; }

    [Required]
    public string PaintName { get; set; }

    public DateTime CreatedDate { get; set; }
    
    [Required]
    public decimal Price { get; set; }

    public PaintProduct(int paintId, string paintName, decimal price)
    {
        PaintId = paintId;
        CreatedDate = DateTime.Now;
        PaintName = paintName;
        Price = price;
    }
}
