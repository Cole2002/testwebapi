namespace WebApplicationFinal.Controllers
{
    using global::WebApplicationFinal.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace WebApplicationFinal.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class BreakfastFoodsController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public BreakfastFoodsController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: api/BreakfastFoods
            [HttpGet]
            public async Task<ActionResult<IEnumerable<BreakfastFood>>> GetBreakfastFoods(int? id)
            {
                if (id == null || id == 0)
                {
                    return await _context.BreakfastFoods.Take(5).ToListAsync();
                }

                var breakfastFood = await _context.BreakfastFoods.FindAsync(id);

                if (breakfastFood == null)
                {
                    return NotFound();
                }

                return new List<BreakfastFood> { breakfastFood };
            }

            // Other actions for POST, PUT, DELETE...
        }
    }

}
