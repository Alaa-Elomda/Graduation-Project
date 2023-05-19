using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;

public class UsersRepo : GenericRepo<User>, IUsersRepo
{
    public readonly AbilityContext _context;
    public UsersRepo(AbilityContext context) : base(context)
    {
        _context = context;
    }
}
