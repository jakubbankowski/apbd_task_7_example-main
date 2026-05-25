using APBD_TASK_7.Data;
using APBD_TASK_7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD_TASK_7.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    /*
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var products = await _context.Products.ToListAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(CreateProductRequest request)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock,
            Stock2 = 12,
            Stock3 = 24,
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }
    */
}

public class CreateProductRequest
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
