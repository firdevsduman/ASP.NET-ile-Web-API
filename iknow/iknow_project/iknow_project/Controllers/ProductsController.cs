using iknow_project.Models;
using iknow_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace iknow_project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ShoppingService _shoppingsService;
    private object product;

    public ProductsController(ShoppingService shoppingsService)
    {
        _shoppingsService = shoppingsService;
    }

    [HttpGet]
    public async Task<List<Product>> Get() =>
        await _shoppingsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Product>> Get(string id)
    {
        var product = await _shoppingsService.GetAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Product newProduct)
    {
        await _shoppingsService.CreateAsync(newProduct);

        return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Product updatedProduct)
    {
        var product = await _shoppingsService.GetAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        updatedProduct.Id = product.Id;

        await _shoppingsService.UpdateAsync(id, updatedProduct);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var product = await _shoppingsService.GetAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        await _shoppingsService.RemoveAsync(id);

        return NoContent();
    }

    [HttpDelete]
    public async void DeleteAll()
    {

        await _shoppingsService.RemoveAsync();

    }


}
