using AbilitySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;

public interface IOrdersManager
{
    List<OrderReadDto> GetAll();
    //Order? GetById(int id);

    OrderWithProductsReadDto? GetByIdWithProducts(int id);

    List<OrderByUserReadDto>? GetByUserWithProducts(string userId);

    int Add(OrderAddDto orderDto);
    void Edit(int id, OrderEditDto orderDto);
    bool Delete(int id);
    //void Delete(Order order);
}
