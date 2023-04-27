using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymnasioEticBack.Models;

namespace GymnasioEticBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerramientumsController : ControllerBase
    {
        private readonly NewGymEtitcContext _context;

        public HerramientumsController(NewGymEtitcContext context)
        {
            _context = context;
        }

        // GET: api/Herramientums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Herramientum>>> GetHerramienta()
        {
            return await _context.Herramienta.ToListAsync();
        }

        // GET: api/Herramientums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Herramientum>> GetHerramientum(int id)
        {
            var herramientum = await _context.Herramienta.FindAsync(id);

            if (herramientum == null)
            {
                return NotFound();
            }

            return herramientum;
        }

        // PUT: api/Herramientums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHerramientum(int id, Herramientum herramientum)
        {
            if (id != herramientum.Id)
            {
                return BadRequest();
            }

            _context.Entry(herramientum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HerramientumExists(id))
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

        // POST: api/Herramientums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Herramientum>> PostHerramientum(Herramientum herramientum)
        {
            _context.Herramienta.Add(herramientum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHerramientum", new { id = herramientum.Id }, herramientum);
        }

        // DELETE: api/Herramientums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHerramientum(int id)
        {
            var herramientum = await _context.Herramienta.FindAsync(id);
            if (herramientum == null)
            {
                return NotFound();
            }

            _context.Herramienta.Remove(herramientum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HerramientumExists(int id)
        {
            return _context.Herramienta.Any(e => e.Id == id);
        }
    }
}
