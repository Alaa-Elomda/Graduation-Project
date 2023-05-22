using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AbilitySystem.API.Controllers.Helpers
{
    public interface IHelper
    {
        public string GenerateToken(IList<Claim> claimsList, DateTime exp);

        public string ImageValidation(IFormFile? image);
    }
}
