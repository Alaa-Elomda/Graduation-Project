using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;

public interface IAdminsManager
{
    List<GetAdminDto> GetAll();
    GetAdminDto Get(string id);

    void Update(UpdateAdminDto admin, string id);

   // void UpdateImage(IFormFile? image, string id);
    void Delete(string id);
}
