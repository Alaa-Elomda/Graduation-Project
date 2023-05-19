using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;

[PrimaryKey(nameof(OrderId), nameof(ProductId))]
public  class OrderProduct
{
       
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int ProductQuantity { get; set; }

        public Order? Order { get; set; }

        public Product? Product { get; set; }

}

