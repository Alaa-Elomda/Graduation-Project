using AbilitySystem.DAL;
using Microsoft.AspNetCore.Http;

namespace AbilitySystem.BL;

public interface IUsersManager
{
    List<GetUserDto> GetAll();
    GetUserDto Get(string id);

    void Update(UpdateUserDto user, string id);

   // void UpdateImage(ImageDto imageDto);
    void UpdateImage(IFormFile? image,string id);
   
    void Delete(string id);
    public List<GetUserWithWishlistDto>? GetUserWithWishlist(string id);
    public void AddToWishlist(AddToWishlistDto wishlist);
    void DeleteFromWishlist(AddToWishlistDto wishlist);
}
