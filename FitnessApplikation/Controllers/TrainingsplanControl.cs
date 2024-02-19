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
    public class TrainingsplanController : ControllerBase
    {
        private readonly FitnessDbContext _context;

        public TrainingsplanController(FitnessDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainingsplan>>> GetTrainingsplaene()
        {
            return await _context.Trainingsplaene.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trainingsplan>> GetTrainingsplan(int id)
        {
            var trainingsplan = await _context.Trainingsplaene.FindAsync(id);

            if (trainingsplan == null)
            {
                return NotFound();
            }

            return trainingsplan;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingsplan(int id, Trainingsplan trainingsplan)
        {
            if (id != trainingsplan.TrainingsplanID)
            {
                return BadRequest();
            }

            _context.Entry(trainingsplan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingsplanExists(id))
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

        // POST: api/Trainingsplan
        [HttpPost]
        public async Task<ActionResult<Trainingsplan>> PostTrainingsplan(Trainingsplan trainingsplan)
        {
            _context.Trainingsplaene.Add(trainingsplan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainingsplan", new { id = trainingsplan.TrainingsplanID }, trainingsplan);
        }

        // DELETE: api/Trainingsplan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingsplan(int id)
        {
            var trainingsplan = await _context.Trainingsplaene.FindAsync(id);
            if (trainingsplan == null)
            {
                return NotFound();
            }

            _context.Trainingsplaene.Remove(trainingsplan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingsplanExists(int id)
        {
            return _context.Trainingsplaene.Any(e => e.TrainingsplanID == id);
        }
    }
}
