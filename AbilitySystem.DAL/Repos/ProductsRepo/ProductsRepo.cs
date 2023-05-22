using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;
public class ProductsRepo : GenericRepo<Product>, IProductsRepo
{
    private readonly AbilityContext _context;

    public ProductsRepo(AbilityContext context) : base(context)
    {
        _context = context;
    }

    public List<Product> GetAllWithCategory()
    {
        return _context.Products
            .Include(p => p.Category).ToList();
           
    }
    public Product? GetByIdWithCategory(int id)
    {
        return _context.Products
            .Include(p => p.Category)
            .FirstOrDefault(p => p.ProductId == id);
    }
}
