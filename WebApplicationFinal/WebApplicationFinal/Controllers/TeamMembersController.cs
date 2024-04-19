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
        public class TeamMembersController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public TeamMembersController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: api/TeamMembers
            [HttpGet]
            public async Task<ActionResult<IEnumerable<TeamMember>>> GetTeamMembers(int? id)
            {
                if (id == null || id == 0)
                {
                    return await _context.TeamMembers.Take(5).ToListAsync();
                }

                var teamMember = await _context.TeamMembers.FindAsync(id);

                if (teamMember == null)
                {
                    return NotFound();
                }

                return new List<TeamMember> { teamMember };
            }

            // Other actions for POST, PUT, DELETE...
        }
    }


}
