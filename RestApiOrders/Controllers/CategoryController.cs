using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiOrders.ForView;
using RestApiOrders.Model.Context;

namespace RestApiOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CompanyContext _context;

        public CategoryController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryForView>>> GetCategories()
        {
          if (_context.Categories == null)
          {
              return NotFound();
          }
            return (await _context.Categories.ToListAsync())
                .Select(cli => (CategoryForView)cli)
                .ToList();
        }

		// POST: api/Category
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<CategoryForView>> PostClient(CategoryForView category)
		{
			if (_context.Categories == null)
			{
				return Problem("Entity set 'CompanyContext.Categories' is null.");
			}
			_context.Categories.Add(category);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				throw;
			}

			return Ok(category);
		}
	}
}
