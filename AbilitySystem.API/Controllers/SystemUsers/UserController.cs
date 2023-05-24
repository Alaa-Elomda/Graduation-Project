//using APIs.Security.Data.Models;
//using APIs.Security.DTOs;
using AbilitySystem.API.Controllers.Helpers;
using AbilitySystem.BL;
using AbilitySystem.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;


namespace AbilitySystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly IConfiguration _configuration;
    private readonly IHelper _helper;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUsersManager _usersManager;

    //private readonly UserManager<Admin> _adminManager;

    public UserController(IConfiguration configuration, IHelper helper,
        UserManager<IdentityUser> userManager, IUsersManager usersManager
     )
    {
        _configuration = configuration;
        _helper = helper;
        _userManager = userManager;
        _usersManager = usersManager;
    }


    #region RegisterUser

    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult<TokenDto>> Register(RegisterDto registerDto)
    {
        var user = new User
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email,
            Gender = (DAL.Gender)registerDto.Gender,
        };

        var userCreationResult = await _userManager.CreateAsync(user, registerDto.Password);
        if (!userCreationResult.Succeeded)
        {
            return BadRequest(userCreationResult.Errors);
        }

        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Role, "User"),
    };

        await _userManager.AddClaimsAsync(user, claims);

        DateTime exp = DateTime.Now.AddDays(3);

        var tokenString = _helper.GenerateToken(claims, exp);
        return new TokenDto(tokenString);
    }

    #endregion

    #region Login

    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult<TokenDto>> Login(LoginDto credentials)
    {
        User? user = (User)await _userManager.FindByEmailAsync(credentials.Email);
        if (user is null)
        {
            return BadRequest(new { Message = "User Not Found" });
        }

        var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, credentials.Password);
        if (!isPasswordCorrect)
        {
            return Unauthorized();
        }

        var claims = await _userManager.GetClaimsAsync(user);
        DateTime exp = DateTime.Now.AddDays(3);

        var tokenString = _helper.GenerateToken(claims, exp);
        return new TokenDto(tokenString);
    }

    #endregion

    #region GetAll
    [HttpGet]
    public ActionResult<List<GetUserDto>> GetAll()
    {
        return _usersManager.GetAll();
    }
    #endregion


    #region GetById
    [HttpGet]
    [Route("{id}")]
    public ActionResult<GetUserDto> Get(string id)
    {
        return _usersManager.Get(id);
    }
    #endregion


    #region Update
    [HttpPatch]
    public ActionResult Update(UpdateUserDto updateUserDto, string id)
    {

        _usersManager.Update(updateUserDto, id);
        return Ok("User Updated");
    }

   
    [HttpPatch]
    [Route("image/{id}")]
    public ActionResult UpdateImage(IFormFile? image,string id)

    {
        string message =_helper.ImageValidation(image);

        if (message == "ok")
        {
            _usersManager.UpdateImage(image, id);
            return Ok(message);
        }

        return BadRequest(message);
    }
    #endregion


    #region Delete
    [HttpDelete]
    public ActionResult Delete(string id)
    {
        _usersManager.Delete(id);
        return Ok("User Deleted");
    }
    #endregion


    [HttpGet("wishlist/{userId}")]
    public IActionResult GetUserWithWishlist(string userId)
    {
        var cartItems = _usersManager.GetUserWithWishlist(userId);
        return Ok(cartItems);
    }

    [HttpPost("wishlist")]
    public IActionResult AddToWishlist(AddToWishlistDto wishlist)
    {
        _usersManager.AddToWishlist(wishlist);
        return Ok(new { message = "Product added to wishlist successfully" });
    }

    [HttpDelete("wishlist")]
    public IActionResult DeleteFromWishlist(AddToWishlistDto wishlist)
    {
        _usersManager.DeleteFromWishlist(wishlist);
        return Ok(new { message = "Product Removed from wishlist successfully" });
    }

}

