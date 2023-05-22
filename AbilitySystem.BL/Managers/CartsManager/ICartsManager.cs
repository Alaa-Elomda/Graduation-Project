
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;

public interface ICartsManager
{
    void AddToCart(CartDto cartdto);
    void RemoveFromCart(removeCartDto removedCart);
    void Edit(CartToBeEdited cart, editCartDto editCartdto);
    List<CartWithProductDto> GetCartByUserId(string userId);
   
}
