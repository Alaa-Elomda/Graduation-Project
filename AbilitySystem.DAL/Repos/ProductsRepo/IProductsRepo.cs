using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;
public interface IProductsRepo: IGenericRepo<Product>
{
    //List<Product> GetOnSale();
    //List<Product> GetByPriceRange(int min,int max);
    //List<Product> GetByCategory();

    List<Product> GetAllWithCategory();
    Product? GetByIdWithCategory(int id);
}
