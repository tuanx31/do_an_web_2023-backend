using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Models;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrademarksController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TrademarksController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Trademarks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trademark>>> GetTrademark()
        {
          if (_context.Trademark == null)
          {
              return NotFound();
          }
            return await _context.Trademark.ToListAsync();
        }

        // GET: api/Trademarks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trademark>> GetTrademark(int id)
        {
          if (_context.Trademark == null)
          {
              return NotFound();
          }
            var trademark = await _context.Trademark.FindAsync(id);

            if (trademark == null)
            {
                return NotFound();
            }

            return trademark;
        }

        // PUT: api/Trademarks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrademark(int id, TrademarkModel model)
        {
            var trademark = new Trademark
            {
                Id = id,
                Name = model.Name,
                Description = model.Description,
            };

            if (id != trademark.Id)
            {
                return BadRequest();
            }

            _context.Entry(trademark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrademarkExists(id))
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

        // POST: api/Trademarks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrademarkModel>> PostTrademark(TrademarkModel model)
        {
            var trademark = new Trademark
            {
                Name = model.Name,
                Description = model.Description,
            };

          if (_context.Trademark == null)
          {
              return Problem("Entity set 'MyDbContext.Trademark'  is null.");
          }
            _context.Trademark.Add(trademark);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrademark", new { id = trademark.Id }, trademark);
        }

        // DELETE: api/Trademarks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrademark(int id)
        {
            if (_context.Trademark == null)
            {
                return NotFound();
            }
            var trademark = await _context.Trademark.FindAsync(id);
            if (trademark == null)
            {
                return NotFound();
            }

            _context.Trademark.Remove(trademark);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrademarkExists(int id)
        {
            return (_context.Trademark?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
