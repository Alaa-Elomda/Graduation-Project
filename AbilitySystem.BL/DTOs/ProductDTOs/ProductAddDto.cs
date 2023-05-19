using AbilitySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;
public record ProductAddDto(string Name, float Price, int Sale, string? Description, int Quantity, string? ImgURL, int CategoryId);
