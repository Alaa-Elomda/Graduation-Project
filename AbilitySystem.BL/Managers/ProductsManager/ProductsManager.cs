using AbilitySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.BL;
public class ProductsManager : IProductsManager
{
    private readonly IProductsRepo _productesRepo;
    public ProductsManager(IProductsRepo productesRepo)
    {
        _productesRepo = productesRepo;
    }
    public void Add(ProductAddDto product)
    {
        var newProduct = new Product
        {
            Name= product.Name,
            Price= product.Price,
            Sale= product.Sale,
            Description= product.Description,
            Quantity= product.Quantity,
            ImgURL= product.ImgURL,
            CategoryId= product.CategoryId
        };

        _productesRepo.Add(newProduct);
        _productesRepo.SaveChanges();
    }

    public void Delete(Product product)
    {
        _productesRepo.Delete(product);
        _productesRepo.SaveChanges();
    }

    public Product? Get(int id)
    {
        var product = _productesRepo.GetById(id);
        if (product == null)
        {
            return null;
        }
        return product;
    }

    public List<Product> GetAll()
    {
        var products = _productesRepo.GetAll();
        return products;
    }

    public void Update(ProductDto product)
    {
        var newProduct = _productesRepo.GetById(product.ProductId);
        newProduct.ProductId= product.ProductId;
        newProduct.Name = product.Name;
        newProduct.Price = product.Price;
        newProduct.Sale = product.Sale;
        newProduct.Description = product.Description;
        newProduct.Quantity = product.Quantity;
        newProduct.ImgURL = product.ImgURL;
        newProduct.CategoryId = product.CategoryId;
        _productesRepo.SaveChanges();
    }
}
