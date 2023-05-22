using AbilitySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;

public record OrderWithProductsReadDto
{
    public DateTime OrderDate { get; init; }
    public string UserId { get; init; } = string.Empty;
    public OrderStatus OrderStatus { get; init; }
    public float TotalPrice { get; init; }
    public required List<OrderProductReadDto> Products { get; init; } = new();
}
