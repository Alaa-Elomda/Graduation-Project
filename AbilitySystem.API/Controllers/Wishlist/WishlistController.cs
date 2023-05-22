//using APIs.Security.Data.Models;
//using APIs.Security.DTOs;
using AbilitySystem.API.Controllers.Registeration;
using AbilitySystem.BL;
using AbilitySystem.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;


namespace AbilitySystem.API.Controllers;

/*[Route("api/[controller]")]
[ApiController]
public class WishlistController : ControllerBase
{
    private readonly IWishlistBL _wishlistBL;
    public WishlistController(IWishlistBL wishlistBL)
    {
        _wishlistBL = wishlistBL;
    }

    #region Wishlist

    [HttpPost]
    [Route("getWishlist")]
    public ActionResult<List<Wishlist>> getWishlist(int UserID)
    {
       var myWishlist= _wishlistBL.getWishlist(UserID);
        return myWishlist;
    }

    [HttpPost]
    [Route("addToWishlist")]
    public void addToWishlist(Wishlist obj)
    {

         _wishlistBL.addToWishlist(obj);
    }

    [HttpPost]
    [Route("deleteFromWishlist")]
    public void deleteFromWishlist(Wishlist obj)
    {
        _wishlistBL.deleteFromWishlist(obj);
    }
    #endregion



}*/

