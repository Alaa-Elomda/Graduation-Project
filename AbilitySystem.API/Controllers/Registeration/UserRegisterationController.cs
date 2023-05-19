//using APIs.Security.Data.Models;
//using APIs.Security.DTOs;
using AbilitySystem.API.Controllers.Helpers;
using AbilitySystem.API.Controllers.Registeration;
using AbilitySystem.BL;
using AbilitySystem.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AbilitySystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserRegisterationController : ControllerBase
{

    private readonly IConfiguration _configuration;
    private readonly IHelper _helper;
    private readonly UserManager<IdentityUser> _userManager;
    //private readonly UserManager<Admin> _adminManager;

    public UserRegisterationController(IConfiguration configuration,IHelper helper,
        UserManager<IdentityUser> userManager
     )
    {
        _configuration = configuration;
        _helper = helper;
        _userManager = userManager;
    }


    #region RegisterUser

    [HttpPost]
    [Route("RegisterUser")]
    public async Task<ActionResult> RegisterUser(RegisterDto registerDto)
    {
        var user = new User
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email,
            Gender = (DAL.Gender)registerDto.Gender,
            //Age = GetRandomInt(18,60),
            //Job= "User"
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

        return NoContent();
    }

    #endregion

    #region Login

    [HttpPost]
    [Route("LoginUser")]
    public async Task<ActionResult<TokenDto>> LoginUser(LoginDto credentials)
    {
        User? user = (User)  await _userManager.FindByNameAsync(credentials.UserName);
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


   
}
   
