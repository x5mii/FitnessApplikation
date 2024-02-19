using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessApplikation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApplikation
{
    [Route("api/[controller]")]
    [ApiController]
    public class UebungenController : ControllerBase
    {
        private readonly FitnessDbContext _context;

        public UebungenController(FitnessDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uebungen>>> GetUebungen()
        {
            return await _context.Uebungen.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Uebungen>> GetUebung(int id)
        {
            var uebung = await _context.Uebungen.FindAsync(id);

            if (uebung == null)
            {
                return NotFound();
            }

            return uebung;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUebung(int id, Uebungen uebung)
        {
            if (id != uebung.UebungID)
            {
                return BadRequest();
            }

            _context.Entry(uebung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UebungExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Uebungen>> PostUebung(Uebungen uebung)
        {
            _context.Uebungen.Add(uebung);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUebung", new { id = uebung.UebungID }, uebung);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUebung(int id)
        {
            var uebung = await _context.Uebungen.FindAsync(id);
            if (uebung == null)
            {
                return NotFound();
            }

            _context.Uebungen.Remove(uebung);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UebungExists(int id)
        {
            return _context.Uebungen.Any(e => e.UebungID == id);
        }
    }
}
