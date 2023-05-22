using AbilitySystem.API.Controllers.Helpers;
using AbilitySystem.BL;
using AbilitySystem.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AbilitySystem.API;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductsManager _productsManager;
    private readonly IHelper _helper;

    public ProductController(IProductsManager productsManager, IHelper helper)
    {
        _productsManager = productsManager;
        _helper = helper;
    }

    [HttpGet]
    public ActionResult<List<ProductReadDto>> GetAll()
    {
        return _productsManager.GetAll();
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<ProductReadDto> GetByIdWithCategory(int id)
    {
        var product = _productsManager.GetByIdWithCategory(id);
        if (product is null)
        {
            return NotFound();
        }
        return product;
    }

    //[HttpPost]
    //public ActionResult Add(ProductAddDto product)
    //{
    //    _productsManager.Add(product);
    //    return NoContent();
    ////[HttpGet]
    ////[Route("{id}")]
    ////public ActionResult<Product> GetById(int id)
    ////{
    ////    var category = _productsManager.Get(id);
    ////    if (category is null)
    ////    {
    ////        return NotFound();
    ////    }
    ////    return category;
    ////}
    //}

    [HttpPost]
    public ActionResult Add([FromForm]ProductAddDto product)
    {
        string message = _helper.ImageValidation(product.Image);

        if (message == "ok")
        {
            _productsManager.Add(product);
            return Ok(message);
        }
        return BadRequest(message);
    }
      

[HttpPatch]
    [Route("{id}")]
    public ActionResult<Product> Update(ProductDto product, int id)
    {
        if (id != product.ProductId)
        {
            return BadRequest();
        }
        _productsManager.Update(product);
        return CreatedAtAction(
            actionName: nameof(GetByIdWithCategory),
            routeValues: new { id = product.ProductId },
            value: "");
    }

    [HttpPatch]
    [Route("image/{id}")]
    public ActionResult UpdateImage(IFormFile? image, int id)

    {
        string message = _helper.ImageValidation(image);

        if (message == "ok")
        {
            _productsManager.UpdateImage(image, id);
            return Ok(message);
        }

        return BadRequest(message);
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult<Product> Delete(int id)
    {
        var productToDelete = _productsManager.Get(id);
        if (productToDelete is null)
        {
            return NotFound();
        }
        _productsManager.Delete(productToDelete);
        return NoContent();
    }
}
