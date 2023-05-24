using AbilitySystem.BL;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AbilitySystem.API.Controllers.Cart
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartsManager _cartManager;

        public CartsController(ICartsManager cartManager)
        {
            _cartManager = cartManager;
        }
       /* [HttpGet]
        public IActionResult GetCartItem(CartDto cart)
        {
            var cartItems = _cartManager.GetCartItem(cart);
            return Ok(cartItems);
        }*/
        [HttpGet("{userId}")]
        public ActionResult GetCartByUserId(string userId)
        {
            var cartItems = _cartManager.GetCartByUserId(userId);
            return Ok(cartItems);
        }
        [HttpPost]
        public ActionResult AddToCart(CartDto cartToAdd)
        {
            _cartManager.AddToCart(cartToAdd);
            return Ok(new { message = "Product added to cart successfully" });
        }
        [HttpDelete]
        public ActionResult RemoveFromCart(removeCartDto cartToremoved)
        {
            _cartManager.RemoveFromCart(cartToremoved);
            return Ok(new { message = "Product removed from cart successfully" });
        }
        [HttpPatch("cart")]
        public ActionResult EditCart([FromBody] EditCartRequest editCartRequest)
        {
            //_cartManager.Edit(editCartRequest.CartToBeEdited, editCartRequest.EditedCart);
            _cartManager.Edit(editCartRequest.cartToBeEdited,editCartRequest.EditedCart);


            return NoContent();
        }



    }
}
/*f149fc7b - 0eca - 4fcc - 9348 - c136207bc6e4*/