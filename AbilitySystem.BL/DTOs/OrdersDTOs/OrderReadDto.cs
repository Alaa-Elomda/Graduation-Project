using AbilitySystem.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;

public record OrderReadDto(int OrderId,
                            OrderStatus OrderStatus, 
                            DateTime OrderDate,
                            string UserId, 
                            float TotalPrice);