using AbilitySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;

public record OrderByUserReadDto
{
    public int OrderId { get; init; }
    public required List<OrderProductNameReadDto> Products { get; init; } = new();
    public DateTime OrderDate { get; init; }
    public float TotalPrice { get; init; }
    public OrderStatus OrderStatus { get; init; }
}
