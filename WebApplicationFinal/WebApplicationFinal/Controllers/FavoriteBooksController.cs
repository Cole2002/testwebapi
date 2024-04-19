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
        public class FavoriteBooksController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public FavoriteBooksController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: api/FavoriteBooks
            [HttpGet]
            public async Task<ActionResult<IEnumerable<FavoriteBook>>> GetFavoriteBooks(int? id)
            {
                if (id == null || id == 0)
                {
                    return await _context.FavoriteBooks.Take(5).ToListAsync();
                }

                var favoriteBook = await _context.FavoriteBooks.FindAsync(id);

                if (favoriteBook == null)
                {
                    return NotFound();
                }

                return new List<FavoriteBook> { favoriteBook };
            }

            // POST: api/FavoriteBooks
            [HttpPost]
            public async Task<ActionResult<FavoriteBook>> PostFavoriteBook(FavoriteBook favoriteBook)
            {
                _context.FavoriteBooks.Add(favoriteBook);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFavoriteBooks", new { id = favoriteBook.Id }, favoriteBook);
            }

            // PUT: api/FavoriteBooks/{id}
            [HttpPut("{id}")]
            public async Task<IActionResult> PutFavoriteBook(int id, FavoriteBook favoriteBook)
            {
                if (id != favoriteBook.Id)
                {
                    return BadRequest();
                }

                _context.Entry(favoriteBook).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoriteBookExists(id))
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

            // DELETE: api/FavoriteBooks/{id}
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteFavoriteBook(int id)
            {
                var favoriteBook = await _context.FavoriteBooks.FindAsync(id);
                if (favoriteBook == null)
                {
                    return NotFound();
                }

                _context.FavoriteBooks.Remove(favoriteBook);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool FavoriteBookExists(int id)
            {
                return _context.FavoriteBooks.Any(e => e.Id == id);
            }
        }
    }

}
