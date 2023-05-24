using AbilitySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL; 

public class CartWithProductDto
{
    //public string UserId { get; set; }
    public int ProductId { get; set; }
    public int ProductQuantity { get; set; }
    public ProductDto? Product { get; init; }
}
