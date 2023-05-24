

using AbilitySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;

public class CartsManager : ICartsManager
{
    private readonly ICartsRepo _cartsRepo;
   

    public CartsManager(ICartsRepo cartsRepo)
    {
        _cartsRepo = cartsRepo;
        
    }

    public void AddToCart(CartDto cartdto)
    {

        var newCart = new Cart
        {
            UserId = cartdto.UserId,
            ProductId = cartdto.ProductId,
            ProductQuantity = cartdto.ProductQuantity
        };
        _cartsRepo.Add(newCart);
        _cartsRepo.SaveChanges();

    }

    public void RemoveFromCart(removeCartDto removedCart)
    {
        var newCart = new Cart
        {
            UserId = removedCart.UserId,
            ProductId = removedCart.ProductId,
            
        };
        _cartsRepo.Delete(newCart);
        _cartsRepo.SaveChanges();
    }

    public void Edit(CartToBeEdited cart, editCartDto editCartdto)
    {
        var newCart = new Cart
        {
            UserId = cart.UserId,
            ProductId = cart.ProductId,
           
        };
        Cart? cartToEdit = _cartsRepo.GetCartItem(newCart);
        if (cartToEdit == null) { return; }

        cartToEdit.ProductQuantity = editCartdto.Quantity;

        _cartsRepo.Update(cartToEdit);
        _cartsRepo.SaveChanges();

    }
    public List<CartWithProductDto> GetCartByUserId(string userId)
    {
        var cartItems = _cartsRepo.GetCartByUserId(userId);
        return cartItems.Select(c => new CartWithProductDto
        {
            ProductId = c.ProductId,
            ProductQuantity= c.ProductQuantity,
            Product= new ProductDto(
            c.Product!.ProductId,
            c.Product!.Name,
            c.Product!.Price,
            c.Product!.Sale,
            c.Product!.Description,
            c.Product!.Quantity,
            c.Product!.ImgURL,
            c.Product!.CategoryId
             )
        }).ToList();


























































































































































    }

}
