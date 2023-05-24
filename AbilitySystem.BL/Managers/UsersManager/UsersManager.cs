using AbilitySystem.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting.Internal;
using System.Diagnostics.Metrics;


namespace AbilitySystem.BL;

public class UsersManager : IUsersManager
{
    private readonly IUsersRepo _usersRepo;
    //private readonly IHostingEnvironment _hostingEnvironment;
    private readonly IWebHostEnvironment _webHostEnvironment;


    public UsersManager(IUsersRepo usersRepo, IWebHostEnvironment webHostEnvironment)
    {
        _usersRepo = usersRepo;
        _webHostEnvironment = webHostEnvironment;
    }

    public List<GetUserDto> GetAll()
    {
        List<User> usersFromDb = _usersRepo.GetAll();

        return usersFromDb
            .Select(u => new GetUserDto
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
    public GetUserDto Get(string id)
    {
        User? userFromDb = _usersRepo.Get(id);

        if (userFromDb != null)
        {

            return new GetUserDto
            {
                Id = userFromDb.Id,
                UserName = userFromDb.UserName,
                Email = userFromDb.Email,
                PhoneNumber = userFromDb.PhoneNumber,
                Address = userFromDb.Address,
                Gender = userFromDb.Gender,
                ImgURL = userFromDb.ImgURL,

            };
        }
        return null;
    }
    public void Update(UpdateUserDto user, string id)
    {
        User? userToUpdate = _usersRepo.Get(id);

        if (userToUpdate is null)
        {
            return;
        }
        userToUpdate.UserName = user.UserName==null? userToUpdate.UserName : user.UserName;
        userToUpdate.Email = user.Email == null ? userToUpdate.Email: user.Email;
        userToUpdate.PhoneNumber = user.PhoneNumber == null ? userToUpdate.PhoneNumber : user.PhoneNumber;
        userToUpdate.Address = user.Address == null ? userToUpdate.Address: user.Address;
        userToUpdate.Gender = user.Gender == null ? userToUpdate.Gender: user.Gender;
        userToUpdate.ImgURL = user.ImgURL == null ? userToUpdate.ImgURL: user.ImgURL;


        _usersRepo.Update(userToUpdate);
        _usersRepo.SaveChanges();
    }
    public void Delete(string id)
    {
        User? userToDelete = _usersRepo.Get(id);
        if (userToDelete != null)
        {
            _usersRepo.Delete(userToDelete);
            _usersRepo.SaveChanges();
        }
    }

   
    public void UpdateImage(IFormFile? image, string id )
    {
        var sentExtension = Path.GetExtension(image!.FileName).ToLower();

        string imageName = Guid.NewGuid() + sentExtension;
        // string newName = $"{Guid.NewGuid()}{sentExtension}";
        //Inject a service called IWebHostEnvironment => to get the wwwroot path in runtime (_environment.WebRootPath)
        // string fullPath = @$"C:\Users\Jamal\OneDrive\Documents\GitHub\Course.MVC\Day6\wwwroot\Images\{imageName}";
        //var imagesFolderPath = _hostingEnvironment.MapPath("~/Images");
        // var imagesFolderPath = Path.Combine(_hostingEnvironment.ContentRootPath, "Images");
        var imagesFolderPath = "/Images";

        string imgURL = @$"{imagesFolderPath}/{imageName}";

        //string fullPath = @$"E:\iTi\Projects\Graduation Project\Backend\Graduation-Project-master\Graduation-Project-master\AbilitySystem.API\Images\{imageName}";
        string fullPath = @$"D:\Final Project\BackEnd\New Git\Graduation-Project\AbilitySystem.API\Images\{imageName}";
        using (var stream = System.IO.File.Create(fullPath))
        {
           image.CopyTo(stream);
        }

        User? userToUpdate = _usersRepo.Get(id);

        if (userToUpdate is null)
        {
            return;
        }
        userToUpdate.ImgURL = imgURL;
        _usersRepo.Update(userToUpdate);
        _usersRepo.SaveChanges();
    }

    public List<GetUserWithWishlistDto>? GetUserWithWishlist(string id)
    {
        var wishlistItems = _usersRepo.GetUserWithWishlist(id);
        return wishlistItems?.Select(p => new GetUserWithWishlistDto
        {
            ProductId = p.ProductId,
            ProductName = p.Name,
            Price = p.Price,
            ImgURL = p.ImgURL
        }).ToList();
    }

    public void AddToWishlist(AddToWishlistDto wishlist)
    {
        
        _usersRepo.AddToWishlist(wishlist.userId, wishlist.productId);
        _usersRepo.SaveChanges();
    }

    public void DeleteFromWishlist(AddToWishlistDto wishlist)
    {
        _usersRepo.DeleteFromWishlist(wishlist.userId, wishlist.productId);
        _usersRepo.SaveChanges();
    }
}

