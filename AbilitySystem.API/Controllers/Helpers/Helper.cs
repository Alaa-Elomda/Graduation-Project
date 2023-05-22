using AbilitySystem.API.Controllers.Registeration;
using AbilitySystem.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AbilitySystem.API.Controllers.Helpers
{
    public class Helper : IHelper
    {

        private readonly IConfiguration _configuration;


        public Helper(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        //public Helper()
        //{
        //}

        #region Helpers

        public string GenerateToken(IList<Claim> claimsList, DateTime exp)
        {
            var secretKeyString = _configuration.GetValue<string>("SecretKey") ?? string.Empty;
            var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
            var securityKey = new SymmetricSecurityKey(secretKeyInBytes);

            var signingCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature);


            var jwt = new JwtSecurityToken(
                claims: claimsList,
                expires: exp,
                signingCredentials: signingCredentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwt);

            return tokenString;
        }

        public string ImageValidation(IFormFile? image)
        {

            if (image is null)
            {
                return "Image is not found";
            }

            if (image.Length > 1000_000)
            {
                return "Image size exceeded the limit";
            }

            var allowedExtensions = new string[] { ".jpg", ".svg", ".png", ".jpeg" };

            var sentExtension = Path.GetExtension(image.FileName).ToLower();

            if (!allowedExtensions.Contains(sentExtension))
            {
                return "Image extension is not valid";
            }

            return "ok";
        }

        #endregion
    }
}
