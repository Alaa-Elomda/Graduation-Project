using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;

public class AdminsRepo : GenericRepo<Admin>, IAdminsRepo
{
    public readonly AbilityContext _context;
    public AdminsRepo(AbilityContext context) : base(context)
    {
        _context = context;
    }

    public Admin? Get(string id)
    {
        return _context.Set<Admin>().Find(id);
    }
}
