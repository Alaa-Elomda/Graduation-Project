using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;

[PrimaryKey(nameof(UserId), nameof(ProductId))]
public class Cart
{
   
    
    [ForeignKey("User")]
    public string? UserId { get; set; }
    public User? User { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int ProductQuantity { get; set; }
}
