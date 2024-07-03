using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiOrders.ForView;
using RestApiOrders.Helpers;
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

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitOfMeasurementForView>>> GetUnitOfMeasurements()
        {
          if (_context.UnitOfMeasurements == null)
          {
              return NotFound();
          }
            return (await _context.UnitOfMeasurement.ToListAsync())
                .Select(cli => (UnitOfMeasurementForView)cli)
                .ToList();
        }
    }
}
