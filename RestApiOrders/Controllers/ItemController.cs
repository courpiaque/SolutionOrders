using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiOrders.ForView;
using RestApiOrders.Helpers;
using RestApiOrders.Model;
using RestApiOrders.Model.Context;

namespace RestApiOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly CompanyContext _context;

        public ItemController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemForView>>> GetItems()
        {
            if (_context.Items == null)
            {
                return NotFound();
            }
            return (await _context.Items.ToListAsync())
                    .Select(it=>(ItemForView)it)
                    .ToList();
        }

        // GET: api/Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemForView>> GetItem(int id)
        {
            if (_context.Items == null)
            {
                return NotFound();
            }
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return (ItemForView)item;
        }

        // PUT: api/Item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, ItemForView item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            var itdb = _context.Items
                    .FirstOrDefault(cli => item.Id == cli.IdItem)
                    .CopyProperties(item);
            _context.Entry(itdb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemForView>> PostItem(ItemForView item)
        {
            if (_context.Items == null)
            {
                return Problem("Entity set 'CompanyContext.Items'  is null.");
            }
            _context.Items.Add(item);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItemExists(item.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(item);
        }

        // DELETE: api/Item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            if (_context.Items == null)
            {
                return NotFound();
            }
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ItemExists(int id)
        {
            return (_context.Items?.Any(e => e.IdItem == id)).GetValueOrDefault();
        }
    }
}
