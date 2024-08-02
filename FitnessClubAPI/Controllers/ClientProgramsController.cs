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
    public class ClientProgramsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientProgramsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ClientPrograms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientProgram>>> GetClientPrograms()
        {
            return await _context.ClientPrograms.ToListAsync();
        }

        // GET: api/ClientPrograms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientProgram>> GetClientProgram(int id)
        {
            var clientProgram = await _context.ClientPrograms.FindAsync(id);

            if (clientProgram == null)
            {
                return NotFound();
            }

            return clientProgram;
        }

        // PUT: api/ClientPrograms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientProgram(int id, ClientProgram clientProgram)
        {
            if (id != clientProgram.IdClientProgram)
            {
                return BadRequest();
            }

            _context.Entry(clientProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientProgramExists(id))
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

        // POST: api/ClientPrograms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientProgram>> PostClientProgram(ClientProgram clientProgram)
        {
            _context.ClientPrograms.Add(clientProgram);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClientProgram), new { id = clientProgram.IdClientProgram }, clientProgram);
        }

        // DELETE: api/ClientPrograms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientProgram(int id)
        {
            var clientProgram = await _context.ClientPrograms.FindAsync(id);
            if (clientProgram == null)
            {
                return NotFound();
            }

            _context.ClientPrograms.Remove(clientProgram);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientProgramExists(int id)
        {
            return _context.ClientPrograms.Any(e => e.IdClientProgram == id);
        }
    }
}
