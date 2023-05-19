using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;

public class Admin: IdentityUser
{
    public Gender Gender { get; set; }

    public string? Address { get; set; }

    public string? ImgURL { get; set; }
}
