using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesDB.Models;

namespace MoviesDB.Controllers
{
    [Route("api/MoviesDB/")]
    [ApiController]
    public class movieDetailsController : ControllerBase
    {
        private readonly MoviesDBContext _context;

        public movieDetailsController(MoviesDBContext context)
        {
            _context = context;
        }

        // GET: api/movieDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<movieDetails>>> GetMoviesDB()
        {
            return await _context.MoviesDB.ToListAsync();
        }

        // GET: api/movieDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<movieDetails>> GetmovieDetails(int id)
        {
            var movieDetails = await _context.MoviesDB.FindAsync(id);

            if (movieDetails == null)
            {
                return NotFound();
            }

            return movieDetails;
        }

        // PUT: api/movieDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutmovieDetails(int id, movieDetails movieDetails)
        {
            if (id != movieDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!movieDetailsExists(id))
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

        // POST: api/movieDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<movieDetails>> PostmovieDetails(movieDetails movieDetails)
        {
            _context.MoviesDB.Add(movieDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetmovieDetails", new { id = movieDetails.Id }, movieDetails);
        }

        // DELETE: api/movieDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletemovieDetails(int id)
        {
            var movieDetails = await _context.MoviesDB.FindAsync(id);
            if (movieDetails == null)
            {
                return NotFound();
            }

            _context.MoviesDB.Remove(movieDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool movieDetailsExists(int id)
        {
            return _context.MoviesDB.Any(e => e.Id == id);
        }
    }
}
