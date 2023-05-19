using AbilitySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;
public interface IProductsManager
{
    List<Product> GetAll();
    Product? Get(int id);
    void Add(ProductAddDto product);
    void Delete(Product product);
    void Update(ProductDto product);
}

