using EcommerceBackend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using EcommerceBackend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StockController(AppDbContext context)
        {
            _context = context;
        }

        // 🔍 Obtener stock de un producto
        [HttpGet("{productId}")]
        public async Task<ActionResult<int>> GetStock(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                return NotFound("Producto no encontrado.");

            return Ok(product.Stock);
        }

        // 🔼 Incrementar stock
        [Authorize(Roles = "Admin")]
        [HttpPost("increase/{productId}")]
        public async Task<ActionResult> IncreaseStock(int productId, [FromQuery] int amount)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                return NotFound("Producto no encontrado.");

            product.Stock += amount;
            await _context.SaveChangesAsync();
            return Ok($"Stock aumentado. Nuevo stock: {product.Stock}");
        }

        // 🔽 Disminuir stock
        [Authorize(Roles = "Admin")]
        [HttpPost("decrease/{productId}")]
        public async Task<ActionResult> DecreaseStock(int productId, [FromQuery] int amount)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                return NotFound("Producto no encontrado.");

            if (product.Stock < amount)
                return BadRequest("No hay suficiente stock disponible.");

            product.Stock -= amount;
            await _context.SaveChangesAsync();
            return Ok($"Stock disminuido. Nuevo stock: {product.Stock}");
        }
    }
}
