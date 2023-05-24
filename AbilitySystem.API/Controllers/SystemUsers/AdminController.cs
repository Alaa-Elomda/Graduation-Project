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
    public class AdminController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IHelper _helper;
        private readonly UserManager<IdentityUser> _adminManager;
        private readonly IAdminsManager _adminsManager;


        public AdminController(IConfiguration configuration,IHelper helper,
            UserManager<IdentityUser> adminManager, IAdminsManager adminsManager)
        {
            _configuration = configuration;
            _adminManager = adminManager;
            _helper = helper;
            _adminsManager = adminsManager;
        }

        #region register
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<TokenDto>> Register(RegisterDto registerDto)
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
        [Route("Login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto credentials)
        {
            Admin? admin =(Admin) await _adminManager.FindByEmailAsync(credentials.Email);

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


        #region GetAll
        [HttpGet]
        public ActionResult<List<GetAdminDto>> GetAll()
        {
            return _adminsManager.GetAll();
        }
        #endregion 

        #region GetById
        [HttpGet]
        [Route("{id}")]
        public ActionResult<GetAdminDto> Get(string id)
        {
            return _adminsManager.Get(id);
        }
        #endregion


        #region Update
        [HttpPatch]
        public ActionResult Update(UpdateAdminDto updateAdminDto, string id)
        {

            _adminsManager.Update(updateAdminDto, id);
            return Ok("Admin Updated");
        }

#endregion


        #region Delete
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            _adminsManager.Delete(id);
            return Ok("Admin Deleted");
        }
        #endregion

    }
}
