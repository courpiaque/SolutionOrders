using Microsoft.AspNetCore.Authorization;
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
    public class WorkerController : ControllerBase
    {
        private readonly CompanyContext _context;

        public WorkerController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Worker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerDto>>> GetWorkers()
        {
            if (_context.Workers == null)
            {
                return NotFound();
            }
            return (await _context.Workers.ToListAsync())
                    .Select(wrk => (WorkerDto)wrk)
                    .ToList();
        }

        // GET: api/Worker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerDto>> GetWorker(int id)
        {
            if (_context.Workers == null)
            {
                return NotFound();
            }
            var worker = await _context.Workers.FindAsync(id);

            if (worker == null)
            {
                return NotFound();
            }

            return (WorkerDto)worker;
        }

        // PUT: api/Worker/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorker(int id, WorkerDto worker)
        {
            if (id != worker.IdWorker)
            {
                return BadRequest();
            }
            if (_context?.Workers == null)
            {
                return NotFound();
            }
            var workdb = _context.Workers
                    .FirstOrDefault(cli => worker.IdWorker == cli.IdWorker)
                    .CopyProperties(worker);
            _context.Entry(workdb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerExists(id))
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

        // POST: api/Worker
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkerDto>> PostWorker(WorkerDto worker)
        {
            if (_context.Workers == null)
            {
                return Problem("Entity set 'CompanyContext.Workers'  is null.");
            }
            _context.Workers.Add(worker);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WorkerExists(worker.IdWorker))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(worker);
        }

        // DELETE: api/Worker/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker(int id)
        {
            if (_context.Workers == null)
            {
                return NotFound();
            }
            var worker = await _context.Workers.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }

            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkerExists(int id)
        {
            return (_context.Workers?.Any(e => e.IdWorker == id)).GetValueOrDefault();
        }
    }
}
