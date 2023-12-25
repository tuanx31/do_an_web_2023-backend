﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Models;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public OrderDetailsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderDetails
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetail()
        {
          if (_context.OrderDetail == null)
          {
              return NotFound();
          }
            return await _context.OrderDetail.ToListAsync();
        }

        // GET: api/OrderDetails/5

        [HttpGet("SearchByIdOrder/{id_order}")]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetailByIdOrder(int id_order)
        {
            if (_context.OrderDetail == null)
            {
                return NotFound();
            }
            var result = await _context.OrderDetail.Include(o=>o.Product).Where(o=>o.id_order == id_order).ToListAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetail(int id)
        {
          if (_context.OrderDetail == null)
          {
              return NotFound();
          }
            var orderDetail = await _context.OrderDetail.FindAsync(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return orderDetail;
        }

        // PUT: api/OrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetail(int id, OrderDetail orderDetail)
        {
            if (id != orderDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(id))
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

        // POST: api/OrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderDetailModel>> PostOrderDetail(OrderDetailModel model)
        {
          if (_context.OrderDetail == null)
          {
              return Problem("Entity set 'MyDbContext.OrderDetail'  is null.");
          }
          var orderDetail = new OrderDetail() { 
              amount = model.amount,
              color = model.color,
              id_order = model.id_order,
              id_product = model.id_product,
              price = model.price,
              size = model.size,
          };
            _context.OrderDetail.Add(orderDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderDetail", new { id = orderDetail.Id }, orderDetail);
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            if (_context.OrderDetail == null)
            {
                return NotFound();
            }
            var orderDetail = await _context.OrderDetail.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            _context.OrderDetail.Remove(orderDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderDetailExists(int id)
        {
            return (_context.OrderDetail?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
