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
    [Route("api/TvShows")]
    [ApiController]
    public class TVShowsController : ControllerBase
    {
        private readonly MoviesDBContext _context;

        public TVShowsController(MoviesDBContext context)
        {
            _context = context;
        }

        // GET: api/TVShows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TVShows>>> GetTVShowsDB()
        {
            return await _context.TVShowsDB.ToListAsync();
        }

        // GET: api/TVShows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TVShows>> GetTVShows(string id)
        {
            var tVShows = await _context.TVShowsDB.FindAsync(id);

            if (tVShows == null)
            {
                return NotFound();
            }

            return tVShows;
        }

        // PUT: api/TVShows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTVShows(string id, TVShows tVShows)
        {
            if (id != tVShows.Id)
            {
                return BadRequest();
            }

            _context.Entry(tVShows).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TVShowsExists(id))
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

        // POST: api/TVShows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TVShows>> PostTVShows(TVShows tVShows)
        {
            _context.TVShowsDB.Add(tVShows);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TVShowsExists(tVShows.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTVShows", new { id = tVShows.Id }, tVShows);
        }

        // DELETE: api/TVShows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTVShows(string id)
        {
            var tVShows = await _context.TVShowsDB.FindAsync(id);
            if (tVShows == null)
            {
                return NotFound();
            }

            _context.TVShowsDB.Remove(tVShows);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TVShowsExists(string id)
        {
            return _context.TVShowsDB.Any(e => e.Id == id);
        }
    }
}
