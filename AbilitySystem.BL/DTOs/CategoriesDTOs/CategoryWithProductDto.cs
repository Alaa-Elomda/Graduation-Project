using AbilitySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;

public class CategoryWithProductDto
{
    public int CategoryId { get; set; } 
    public string? CategoryName { get; set; }

    public List<ProductDto> Products { get; set; }= new List<ProductDto>();
}
