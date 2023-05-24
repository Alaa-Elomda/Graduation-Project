using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;
public record ProductReadDto(int ProductId, string Name, float Price, int Sale, string? Description, int Quantity, string? ImgURL, string CategoryName);

