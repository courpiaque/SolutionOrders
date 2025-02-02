﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiOrders.DTOs;
using RestApiOrders.Helpers;
using RestApiOrders.Model.Context;

namespace RestApiOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly CompanyContext _context;

        public OrderController(CompanyContext context)
        {
            _context = context;
        }
        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            return (await _context.Orders
                .Include(x => x.IdWorkerNavigation)
                .Include(x => x.IdClientNavigation)
                .ToListAsync())
                .Select(ord => (OrderDto)ord)
                .ToList();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return (OrderDto)order;
        }

        // GET: api/Orders/Items/5
        [HttpGet("{id}/OrderItem")]
        public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetOrderItems(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            return (await _context.OrderItems
                .Include(x => x.IdItemNavigation)
				.Where(ord => ord.IdOrder == id)
				.ToListAsync())
                .Select(ord => (OrderItemDto)ord)
                .ToList();
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderDto order)
        {
            if (id != order.IdOrder)
            {
                return BadRequest();
            }

            var orderdb = _context.Orders
                    .FirstOrDefault(cli => order.IdOrder == order.IdOrder)
                    .CopyProperties(order);
            _context.Entry(orderdb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderDto>> PostOrder(OrderDto order)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'CompanyContext.Orders'  is null.");
            }
            _context.Orders.Add(order);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(order.IdOrder))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(order);
        }

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}/OrderITem")]
		public async Task<ActionResult<OrderItemDto>> PostOrderItem(int id, OrderItemDto order)
		{
			if (_context.Orders == null)
			{
				return Problem("Entity set 'CompanyContext.Orders'  is null.");
			}

            order.IdOrder = id;
            
			_context.OrderItems.Add(order);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (OrderExists(order.IdOrderItem))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return Ok(order);
		}

		// DELETE: api/Orders/5
		[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.IdOrder == id)).GetValueOrDefault();
        }
		private bool OrderItemExists(int id)
		{
			return (_context.OrderItems?.Any(e => e.IdOrderItem == id)).GetValueOrDefault();
		}

	}
}
