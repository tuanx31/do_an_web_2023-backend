using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using web_api.Data;
using web_api.Models;
using web_api.Reponsitory.Abastract;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _context;

        private IFileService _fileService;

        public ProductsController(MyDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }


        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Getproducts()
        {
          if (_context.products == null)
          {
              return NotFound();
          }   
            return await _context.products.Include(h => h.categories).Include(h=>h.trademarks).ToListAsync();
        }
        [HttpGet("newproduct")]
        public async Task<ActionResult<IEnumerable<Product>>> GetNewproducts()
        {
            if (_context.products == null)
            {
                return NotFound();
            }
            var product = await _context.products.Include(h => h.categories).Include(h => h.trademarks).OrderByDescending(p =>p.createAt).ToListAsync();
            var productLimit = product.Take(4);// limit
            //var pagedProductQuery = productQuery.Skip(25 * page).Take(25) // paging
            return Ok(productLimit);
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
          if (_context.products == null)
          {
              return NotFound();
          }
            var product = await _context.products.Include(h => h.categories).Include(h => h.trademarks).Where(p => p.id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }
            
            return product;
        }

        [HttpGet("search/{keywork}")]
        public async Task<ActionResult<Product>> SearchProduct(string keywork)
        {
            if (_context.products == null)
            {
                return NotFound();
            }
            var result = await _context.products.Include(p => p.categories).Include(p => p.trademarks).Where(p => p.name.Contains(keywork)).ToListAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpGet("productbycategory/{id}")]
        public async Task<ActionResult<Product>> GetProductbyCategory(int id)
        {
            if (_context.products == null)
            {
                return NotFound();
            }
            var result = await _context.products.Include(p=>p.categories).Include(p=>p.trademarks).Where(p => p.id_category == id).ToListAsync();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("hotproduct")]
        public async Task<ActionResult<Product>> GetHotProduct()
        {
            if (_context.products == null)
            {
                return NotFound();
            }
            var result = await _context.products.Include(p => p.categories).Include(p => p.trademarks).Where(p => p.hot == true).ToListAsync();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromForm]int id, ProductModel model)
        {
            var product = new Product
            {
                id= id,
                name = model.name,
                hot = model.hot,
                id_category = model.id_category,
                description = model.description,
                price = model.price,
                sale_of = model.sale_of,
                color = model.color,
                consistent = model.consistent,
                design = model.design,
                id_trademark = model.id_trademark,
                listImage = "",
                Material = model.Material,
                quantity = model.quantity,
                size = model.size,
                createAt = DateTime.Now,
            };

            
            if (model.ImageFile != null)
            {
                var fileResult = _fileService.SaveImage(model.ImageFile);
                if (fileResult.Item1 == 1)
                {
                    product.img = fileResult.Item2;
                }
            }

            if (model.listImageFile != null)
            {
                var fileResult = _fileService.SaveMultiImage(model.listImageFile);
                if (fileResult.Item1 == 1)
                {
                    foreach (var item in fileResult.Item2)
                    {
                        product.listImage += item + "|";
                    }

                }
            }
            if (id != product.id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductModel>> PostProduct([FromForm]ProductModel model)
        {

          if (_context.products == null)
          {
              return Problem("Entity set 'MyDbContext.products'  is null.");
          }

            var product = new Product
            {
                name = model.name,
                hot = model.hot,
                id_category = model.id_category,
                description = model.description,
                price = model.price,
                sale_of = model.sale_of,
                color = model.color,
                consistent = model.consistent,
                design = model.design,
                id_trademark = model.id_trademark,
                listImage = "",
                Material = model.Material,
                quantity = model.quantity,
                size = model.size,
                createAt = DateTime.Now,
            };

            if (model.ImageFile != null)
            {
                var fileResult = _fileService.SaveImage(model.ImageFile);
                if (fileResult.Item1 == 1)
                {
                    product.img = fileResult.Item2;
                }
            }

            if (model.listImageFile != null)
            {
                var fileResult = _fileService.SaveMultiImage(model.listImageFile);
                if (fileResult.Item1 == 1)
                {
                    foreach (var item in fileResult.Item2)
                    {
                        product.listImage += item + "|";
                    }
                    
                }
            }

            _context.products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.products == null)
            {
                return NotFound();
            }
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            string[] stringArray = product.listImage.Split('|');

            stringArray = new ArraySegment<string>(stringArray, 0, stringArray.Length - 1).ToArray();

            // stringArray bây giờ chứa mảng các chuỗi
            foreach (var item in stringArray)
            {

                _fileService.DeleteImage(item);
            }

            _fileService.DeleteImage(product.img);

            _context.products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.products?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
