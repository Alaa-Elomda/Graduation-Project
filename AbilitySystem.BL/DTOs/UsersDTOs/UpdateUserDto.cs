using AbilitySystem.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;

public class UpdateUserDto
{
    public string? UserName { get; set; }

   // [Remote(action: "ValidateMail", controller: "User")]
    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public Gender Gender { get; set; }

    public string? ImgURL { get; set; }
}
