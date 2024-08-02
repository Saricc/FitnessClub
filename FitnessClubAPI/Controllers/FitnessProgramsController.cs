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
    public class FitnessProgramsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FitnessProgramsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FitnessPrograms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FitnessProgram>>> GetFitnessPrograms()
        {
            return await _context.FitnessPrograms.ToListAsync();
        }

        // GET: api/FitnessPrograms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FitnessProgram>> GetFitnessProgram(int id)
        {
            var fitnessProgram = await _context.FitnessPrograms.FindAsync(id);

            if (fitnessProgram == null)
            {
                return NotFound();
            }

            return fitnessProgram;
        }

        // PUT: api/FitnessPrograms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFitnessProgram(int id, FitnessProgram fitnessProgram)
        {
            if (id != fitnessProgram.IdFitnessProgram)
            {
                return BadRequest();
            }

            _context.Entry(fitnessProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FitnessProgramExists(id))
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

        // POST: api/FitnessPrograms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FitnessProgram>> PostFitnessProgram(FitnessProgram fitnessProgram)
        {
            _context.FitnessPrograms.Add(fitnessProgram);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFitnessProgram), new { id = fitnessProgram.IdFitnessProgram }, fitnessProgram);
        }

        // DELETE: api/FitnessPrograms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFitnessProgram(int id)
        {
            var fitnessProgram = await _context.FitnessPrograms.FindAsync(id);
            if (fitnessProgram == null)
            {
                return NotFound();
            }

            _context.FitnessPrograms.Remove(fitnessProgram);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FitnessProgramExists(int id)
        {
            return _context.FitnessPrograms.Any(e => e.IdFitnessProgram == id);
        }
    }
}
