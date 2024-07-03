using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiOrders.ForView;
using RestApiOrders.Helpers;
using RestApiOrders.Model.Context;

namespace RestApiOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly CompanyContext _context;

        public ClientController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientForView>>> GetClients()
        {
          if (_context.Clients == null)
          {
              return NotFound();
          }
            return (await _context.Clients.ToListAsync())
                .Select(cli => (ClientForView)cli)
                .ToList();
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientForView>> GetClient(int id)
        {
          if (_context.Clients == null)
          {
              return NotFound();
          }
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return (ClientForView)client;
        }

        // PUT: api/Client/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, ClientForView client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }
            var cliDb = _context.Clients
                    .FirstOrDefault(cli => client.Id == cli.IdClient)
                    .CopyProperties(client);
            _context.Entry(cliDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Client
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientForView>> PostClient(ClientForView client)
        {
          if (_context.Clients == null)
          {
              return Problem("Entity set 'CompanyContext.Clients'  is null.");
          }
            _context.Clients.Add(client);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClientExists(client.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(client);
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ClientExists(int id)
        {
            return (_context.Clients?.Any(e => e.IdClient == id)).GetValueOrDefault();
        }
    }
}
