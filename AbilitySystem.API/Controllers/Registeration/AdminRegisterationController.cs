using AbilitySystem.API.Controllers.Helpers;
using AbilitySystem.BL;
using AbilitySystem.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AbilitySystem.API.Controllers.Registeration
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminRegisterationController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IHelper _helper;
        private readonly UserManager<IdentityUser> _adminManager;


        public AdminRegisterationController(IConfiguration configuration,IHelper helper,
            UserManager<IdentityUser> adminManager)
        {
            _configuration = configuration;
            _adminManager = adminManager;
            _helper = helper;
        }

        #region register
        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<ActionResult<TokenDto>> RegisterAdmin(RegisterDto registerDto)
        {
            var admin = new Admin
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Gender = (DAL.Gender)registerDto.Gender,
            };

            var userCreationResult = await _adminManager.CreateAsync(admin, registerDto.Password);
            if (!userCreationResult.Succeeded)
            {
                return BadRequest(userCreationResult.Errors);
            }

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, admin.Id),
        new Claim(ClaimTypes.Role, "Admin"),
    };

            await _adminManager.AddClaimsAsync(admin, claims);

            // var claims = await _adminManager.GetClaimsAsync(admin);
            DateTime exp = DateTime.Now.AddDays(3);

            var tokenString = _helper.GenerateToken(claims, exp);
            return new TokenDto(tokenString);

            // return NoContent();
        }
        #endregion


        #region Login
       
        [HttpPost]
        [Route("LoginAdmin")]
        public async Task<ActionResult<TokenDto>> LoginAdmin(LoginDto credentials)
        {
            Admin? admin =(Admin) await _adminManager.FindByNameAsync(credentials.UserName);
            if (admin is null)
            {
                return BadRequest(new { Message = "This account isn't an admin!!!" });
            }

            var isPasswordCorrect = await _adminManager.CheckPasswordAsync(admin, credentials.Password);
            if (!isPasswordCorrect)
            {
                return Unauthorized();
            }

            var claims = await _adminManager.GetClaimsAsync(admin);
            DateTime exp = DateTime.Now.AddDays(3);

            var tokenString = _helper.GenerateToken(claims, exp);
            return new TokenDto(tokenString);
        }

        #endregion


    }
}
