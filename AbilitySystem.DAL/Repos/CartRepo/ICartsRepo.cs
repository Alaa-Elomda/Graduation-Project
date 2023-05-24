using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL
{
    public interface ICartsRepo : IGenericRepo<Cart>
    {
       
        Cart? GetCartItem(Cart cart);
        List<Cart> GetCartByUserId(string userId);
    }
}
