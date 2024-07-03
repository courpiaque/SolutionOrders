using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiOrders.ForView;
using RestApiOrders.Model.Context;

namespace RestApiOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfMeasurementController : ControllerBase
    {
        private readonly CompanyContext _context;

        public UnitOfMeasurementController(CompanyContext context)
        {
            _context = context;
        }

		// GET: api/UnitOfMeasurement
		[HttpGet]
        public async Task<ActionResult<IEnumerable<UnitOfMeasurementForView>>> GetUnitOfMeasurements()
        {
          if (_context.UnitOfMeasurements == null)
          {
              return NotFound();
          }
            return (await _context.UnitOfMeasurements.ToListAsync())
                .Select(cli => (UnitOfMeasurementForView)cli)
                .ToList();
        }

		// POST: api/UnitOfMeasurement
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<UnitOfMeasurementForView>> PostClient(UnitOfMeasurementForView unit)
		{
			if (_context.UnitOfMeasurements == null)
			{
				return Problem("Entity set 'CompanyContext.UnitOfMeasurements'  is null.");
			}
			_context.UnitOfMeasurements.Add(unit);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				throw;
			}

			return Ok(unit);
		}
	}
}
