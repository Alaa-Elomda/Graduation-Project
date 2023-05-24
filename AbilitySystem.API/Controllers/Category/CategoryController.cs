using AbilitySystem.BL;
using AbilitySystem.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace AbilitySystem.API;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoriesManager _categoriesManager;

    public CategoryController(ICategoriesManager categoriesManager)
    {
        _categoriesManager = categoriesManager;
    }

    [HttpGet]
    public ActionResult<List<CategoryDto>> GetAll()
    {
        return _categoriesManager.GetAll();
    }

    [HttpPost]
    public ActionResult Add(CategoryAddDto category)
    {
        _categoriesManager.Add(category);
        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Category> GetById(int id)
    {
        var category = _categoriesManager.Get(id);
        if (category is null)
        {
            return NotFound();
        }
        return category;
    }
    [HttpGet]
    [Route("products/{id}")]
    public ActionResult<CategoryWithProductDto> GetByIdWithProducts(int id)
    {
        var category = _categoriesManager.GetByIdWithProducts(id);
        if (category is null)
        {
            return NotFound();
        }
        return category;
    }

    [HttpPatch]
    [Route("{id}")]
    public ActionResult<Category> Update(CategoryDto category, int id)
    {
        if (id != category.CategoryId)
        {
            return BadRequest();
        }
        _categoriesManager.Update(category);
        return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new { id = category.CategoryId},
            value: "");
    }
    [HttpDelete]
    [Route("{id}")]
    public ActionResult<Category> Delete(int id)
    {
        var categoryToDelete = _categoriesManager.Get(id);
        if (categoryToDelete is null)
        {
            return NotFound();
        }
        _categoriesManager.Delete(categoryToDelete);
        return NoContent();
    }


}