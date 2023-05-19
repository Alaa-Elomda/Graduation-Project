using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;

public class User : IdentityUser
{
    public Gender Gender { get; set; }

    public string? Address { get; set; }

    public string? ImgURL { get; set; }

  //  public ICollection<Wishlist> Wishlists { get; set; } = new HashSet<Wishlist>();

    public ICollection<Product> Products { get; set; } = new HashSet<Product>();//each user may wish many products

    public ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();
    public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

}


