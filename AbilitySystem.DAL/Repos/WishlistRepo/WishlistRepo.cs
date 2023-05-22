using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL
{
    //public class WishlistRepo
    //{

    //    private readonly IGenericRepo<Wishlist> _GenericRepo;
    //    private readonly AbilityContext _DbContext;

    //    public WishlistRepo(IGenericRepo<Wishlist> GenericRepo, AbilityContext DbContext)
    //    {
    //        _GenericRepo = GenericRepo;
    //        _DbContext= DbContext; 
    //    }
    //    #region Get
    //    List<Wishlist> getWishlist(int UserID)
    //    {
    //        try
    //        {
    //          var myWishlist=_DbContext.Wishlist.Where(W=>W.UserId==UserID).ToList();
    //            return myWishlist;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw;
    //        };
    //    }
    //    #endregion
    //    #region Add
    //    void addToWishlist(Wishlist obj)
    //    {
    //        try
    //        {
    //            _GenericRepo.Add(obj);
    //            _GenericRepo.SaveChanges();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw;
    //        };
    //    }
    //    #endregion
    //    #region Delete
    //    void deleteFromWishlist(Wishlist obj)
    //    {
    //        try {
    //            _GenericRepo.Delete(obj);
    //            _GenericRepo.SaveChanges();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw;
    //        };
    //    }
    //    #endregion
    //}
}
