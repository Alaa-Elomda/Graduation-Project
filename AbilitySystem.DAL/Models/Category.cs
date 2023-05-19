using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;

public class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
}
