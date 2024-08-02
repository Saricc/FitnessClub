using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessClubAPI.Data;
using FitnessClubAPI.Models;

namespace FitnessClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessClubsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FitnessClubsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FitnessClubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FitnessClub>>> GetFitnessClub()
        {
            return await _context.FitnessClub.ToListAsync();
        }

        // GET: api/FitnessClubs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FitnessClub>> GetFitnessClub(int id)
        {
            var fitnessClub = await _context.FitnessClub.FindAsync(id);

            if (fitnessClub == null)
            {
                return NotFound();
            }

            return fitnessClub;
        }

        // PUT: api/FitnessClubs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFitnessClub(int id, FitnessClub fitnessClub)
        {
            if (id != fitnessClub.IdFitnessClub)
            {
                return BadRequest();
            }

            _context.Entry(fitnessClub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FitnessClubExists(id))
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

        // POST: api/FitnessClubs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FitnessClub>> PostFitnessClub(FitnessClub fitnessClub)
        {
            _context.FitnessClub.Add(fitnessClub);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFitnessClub), new { id = fitnessClub.IdFitnessClub }, fitnessClub);
        }

        // DELETE: api/FitnessClubs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFitnessClub(int id)
        {
            var fitnessClub = await _context.FitnessClub.FindAsync(id);
            if (fitnessClub == null)
            {
                return NotFound();
            }

            _context.FitnessClub.Remove(fitnessClub);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FitnessClubExists(int id)
        {
            return _context.FitnessClub.Any(e => e.IdFitnessClub == id);
        }
    }
}
