using AbilitySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;
public class GetUserWithWishlistDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public float Price { get; set; }


    public string? ImgURL { get; set; }
}