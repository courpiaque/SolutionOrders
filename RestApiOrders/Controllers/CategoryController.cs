using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiOrders.ForView;
using RestApiOrders.Helpers;
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
    }
}
