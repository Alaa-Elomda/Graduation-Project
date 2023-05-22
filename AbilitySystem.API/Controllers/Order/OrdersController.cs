using AbilitySystem.BL;
using AbilitySystem.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AbilitySystem.API.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersManager _ordersManager;

        public OrdersController(IOrdersManager ordersManager)
        {
            _ordersManager = ordersManager;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult<List<OrderReadDto>> GetAll()
        {
            return _ordersManager.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        //[Authorize(Roles = "Admin")]
        public ActionResult<OrderWithProductsReadDto> GetByIdWithProducts(int id)
        {
            var orderDto = _ordersManager.GetByIdWithProducts(id);
            if (orderDto is null)
            {
                return NotFound(new { Message = "No Order Found!!" });
            }
            return orderDto;
        }

        [HttpGet]
        [Route("user/{userId}")]
        //[Authorize(Roles = "User")]
        public ActionResult<List<OrderByUserReadDto>> GetByUserWithProducts(string userId)
        {
            var orderDto = _ordersManager.GetByUserWithProducts(userId);
            if (orderDto is null)
            {
                return NotFound(new { Message = "No Order Found!!" });
            }
            return orderDto;
        }


        [HttpPost]
        //[Authorize(Roles = "User")]
        public ActionResult Add(OrderAddDto orderDto)
        {
            _ordersManager.Add(orderDto);
            return CreatedAtAction(
                actionName: nameof(GetAll),
                value: "Added Successfully");
        }


        [HttpPatch]
        [Route("{id}")]
        //[Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, OrderEditDto orderDto)
        {
            if (orderDto.OrderId != id) return NotFound(new { Message = "No Order Found!!" });

            _ordersManager.Edit(id, orderDto);
            return CreatedAtAction(
                actionName: nameof(GetByIdWithProducts),
                routeValues: new { id = orderDto.OrderId },
                value: "Updated Successfully");
        }


        [HttpDelete]
        [Route("{id}")]
        //[Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {

            bool isDeleted = _ordersManager.Delete(id);
            if (isDeleted)
            {
                return CreatedAtAction(
                    actionName: nameof(GetAll),
                    value: "Deleted Successfully");
            }
            else
            {
                return NotFound("Entity not found");
            }

            //var orderToDelete = _ordersManager.GetById(id);
            //if (orderToDelete is null)
            //{
            //    return NotFound();
            //}
            //_ordersManager.Delete(orderToDelete);
            //return NoContent();

        }
    }
}
