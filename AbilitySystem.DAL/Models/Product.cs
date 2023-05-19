using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Price { get; set; }
    public int Sale { get; set; }
    public string? Description { get; set; }

    public int Quantity { get; set; }

    public string? ImgURL { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }//navigational property

    //public ICollection<Wishlist> Wishlists { get; set; } = new HashSet<Wishlist>();

    public ICollection<User> Users { get; set; } = new HashSet<User>(); //each product is wished by many users

    public ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();

    //public ICollection<Order> Orders { get; set; } = new HashSet<Order>();//simple

    public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();//complex
}
