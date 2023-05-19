using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;
public class ProductsRepo : GenericRepo<Category>, IProductsRepo
{
    private readonly AbilityContext _context;

    public ProductsRepo(AbilityContext context) : base(context)
    {
        _context = context;
    }

    public void Add(Product entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Product entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Product entity)
    {
        throw new NotImplementedException();
    }

    List<Product> IGenericRepo<Product>.GetAll()
    {
        throw new NotImplementedException();
    }

    Product? IGenericRepo<Product>.GetById(int id)
    {
        throw new NotImplementedException();
    }
}
