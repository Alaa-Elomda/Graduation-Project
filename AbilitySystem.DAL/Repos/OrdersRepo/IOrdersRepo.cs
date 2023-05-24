using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;

public interface IOrdersRepo: IGenericRepo<Order>
{
    Order? GetByIdWithProducts(int id);
    //Order? GetByUserWithProducts(string userId);
    List<Order>? GetByUserWithProducts(string userId);
}
