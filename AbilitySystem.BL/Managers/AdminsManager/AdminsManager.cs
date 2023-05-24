using AbilitySystem.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;

public class AdminsManager : IAdminsManager
{
    private readonly IAdminsRepo _adminsRepo;

    private readonly IWebHostEnvironment _webHostEnvironment;

    public AdminsManager(IAdminsRepo adminsRepo, IWebHostEnvironment webHostEnvironment)
    {
        _adminsRepo = adminsRepo;
        _webHostEnvironment = webHostEnvironment;
    }
    public List<GetAdminDto> GetAll()
    {
        List<Admin> adminsFromDb = _adminsRepo.GetAll();

        return adminsFromDb
            .Select(u => new GetAdminDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Address = u.Address,
                Gender = u.Gender,
                ImgURL = u.ImgURL,

            })
            .ToList();
    }
    public GetAdminDto Get(string id)
    {
        Admin? adminFromDb = _adminsRepo.Get(id);

        if (adminFromDb != null)
        {

            return new GetAdminDto
            {
                Id = adminFromDb.Id,
                UserName = adminFromDb.UserName,
                Email = adminFromDb.Email,
                PhoneNumber = adminFromDb.PhoneNumber,
                Address = adminFromDb.Address,
                Gender = adminFromDb.Gender,
                ImgURL = adminFromDb.ImgURL,

            };
        }
        return null;
    }
    public void Update(UpdateAdminDto admin, string id)
    {
        Admin? adminToUpdate = _adminsRepo.Get(id);

        if (adminToUpdate is null)
        {
            return;
        }
        adminToUpdate.UserName = admin.UserName == null ? adminToUpdate.UserName : admin.UserName;
        adminToUpdate.Email =admin.Email == null ? adminToUpdate.Email : admin.Email;
        adminToUpdate.PhoneNumber = admin.PhoneNumber == null ? adminToUpdate.PhoneNumber : admin.PhoneNumber;
        adminToUpdate.Address = admin.Address == null ? adminToUpdate.Address :  admin.Address;
        adminToUpdate.Gender = admin.Gender == null ? adminToUpdate.Gender : admin.Gender;
        adminToUpdate.ImgURL = admin.ImgURL == null ? adminToUpdate.ImgURL : admin.ImgURL;


        _adminsRepo.Update(adminToUpdate);
        _adminsRepo.SaveChanges();
    }

    public void Delete(string id)
    {
        Admin? adminToDelete = _adminsRepo.Get(id);
        if (adminToDelete != null)
        {
            _adminsRepo.Delete(adminToDelete);
            _adminsRepo.SaveChanges();
        }
    }

}
