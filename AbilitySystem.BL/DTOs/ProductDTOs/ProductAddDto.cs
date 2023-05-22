using AbilitySystem.DAL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;
//public record ProductAddDto(string Name, float Price, int Sale, string? Description, int Quantity, string? ImgURL, int CategoryId);


public record ProductAddDto(string Name, float Price, int Sale, string? Description, int Quantity, int CategoryId, IFormFile? Image);

//public record ProductAddDto(IFormFile? Image);