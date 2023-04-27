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
    public class EjerciciosHasRutinasController : ControllerBase
    {
        private readonly NewGymEtitcContext _context;

        public EjerciciosHasRutinasController(NewGymEtitcContext context)
        {
            _context = context;
        }

        // GET: api/EjerciciosHasRutinas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EjerciciosHasRutina>>> GetEjerciciosHasRutinas()
        {
            return await _context.EjerciciosHasRutinas.ToListAsync();
        }

        // GET: api/EjerciciosHasRutinas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EjerciciosHasRutina>> GetEjerciciosHasRutina(int id)
        {
            var ejerciciosHasRutina = await _context.EjerciciosHasRutinas.FindAsync(id);

            if (ejerciciosHasRutina == null)
            {
                return NotFound();
            }

            return ejerciciosHasRutina;
        }

        // PUT: api/EjerciciosHasRutinas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEjerciciosHasRutina(int id, EjerciciosHasRutina ejerciciosHasRutina)
        {
            if (id != ejerciciosHasRutina.RutinaEjercicio)
            {
                return BadRequest();
            }

            _context.Entry(ejerciciosHasRutina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EjerciciosHasRutinaExists(id))
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

        // POST: api/EjerciciosHasRutinas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EjerciciosHasRutina>> PostEjerciciosHasRutina(EjerciciosHasRutina ejerciciosHasRutina)
        {
            _context.EjerciciosHasRutinas.Add(ejerciciosHasRutina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEjerciciosHasRutina", new { id = ejerciciosHasRutina.RutinaEjercicio }, ejerciciosHasRutina);
        }

        // DELETE: api/EjerciciosHasRutinas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEjerciciosHasRutina(int id)
        {
            var ejerciciosHasRutina = await _context.EjerciciosHasRutinas.FindAsync(id);
            if (ejerciciosHasRutina == null)
            {
                return NotFound();
            }

            _context.EjerciciosHasRutinas.Remove(ejerciciosHasRutina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EjerciciosHasRutinaExists(int id)
        {
            return _context.EjerciciosHasRutinas.Any(e => e.RutinaEjercicio == id);
        }
    }
}
