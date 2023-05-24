using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;

public interface IAdminsRepo : IGenericRepo<Admin>
{
    Admin? Get(string id);
}
