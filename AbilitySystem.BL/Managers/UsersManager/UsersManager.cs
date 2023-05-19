using AbilitySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;

public class UsersManager : IUsersManager
{
    private readonly IUsersRepo _userRepo;

    public UsersManager(IUsersRepo userRepo)
    {
        _userRepo = userRepo;
    }
}
