using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;
public class CategoriesRepo : GenericRepo<Category>, ICategoriesRepo
{
    private readonly AbilityContext _context;

    public CategoriesRepo(AbilityContext context) : base(context)
    {
        _context = context;
    }
   
}
