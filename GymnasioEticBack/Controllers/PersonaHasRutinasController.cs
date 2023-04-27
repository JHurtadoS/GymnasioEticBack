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
    public class PersonaHasRutinasController : ControllerBase
    {
        private readonly NewGymEtitcContext _context;

        public PersonaHasRutinasController(NewGymEtitcContext context)
        {
            _context = context;
        }

        // GET: api/PersonaHasRutinas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaHasRutina>>> GetPersonaHasRutinas()
        {
            return await _context.PersonaHasRutinas.ToListAsync();
        }

        // GET: api/PersonaHasRutinas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaHasRutina>> GetPersonaHasRutina(int id)
        {
            var personaHasRutina = await _context.PersonaHasRutinas.FindAsync(id);

            if (personaHasRutina == null)
            {
                return NotFound();
            }

            return personaHasRutina;
        }

        // PUT: api/PersonaHasRutinas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonaHasRutina(int id, PersonaHasRutina personaHasRutina)
        {
            if (id != personaHasRutina.RutinasPersona)
            {
                return BadRequest();
            }

            _context.Entry(personaHasRutina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaHasRutinaExists(id))
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

        // POST: api/PersonaHasRutinas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonaHasRutina>> PostPersonaHasRutina(PersonaHasRutina personaHasRutina)
        {
            _context.PersonaHasRutinas.Add(personaHasRutina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonaHasRutina", new { id = personaHasRutina.RutinasPersona }, personaHasRutina);
        }

        // DELETE: api/PersonaHasRutinas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonaHasRutina(int id)
        {
            var personaHasRutina = await _context.PersonaHasRutinas.FindAsync(id);
            if (personaHasRutina == null)
            {
                return NotFound();
            }

            _context.PersonaHasRutinas.Remove(personaHasRutina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaHasRutinaExists(int id)
        {
            return _context.PersonaHasRutinas.Any(e => e.RutinasPersona == id);
        }
    }
}
