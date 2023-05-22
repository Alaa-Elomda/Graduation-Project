using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;
public class ProductCartDto
{
public int ProductId { get; set; }
public string Name { get; set; }
public float Price { get; set; } = 0;
public int Sale { get; set; }
public string? Description { get; set; }
public int Quantity { get; set; }
public string? ImgURL { get; set; }
public int CategoryId { get; set; }

}