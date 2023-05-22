namespace AbilitySystem.DAL;

public interface IUsersRepo : IGenericRepo<User>
{
    User? Get(string id);
    List<Product>? GetUserWithWishlist(string id);

    void AddToWishlist(string userId,int productId);

    void DeleteFromWishlist(string userId, int productId);
}
