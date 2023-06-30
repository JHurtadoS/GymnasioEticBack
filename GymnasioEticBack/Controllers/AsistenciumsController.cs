using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymnasioEticBack.Models;
using GymnasioEticBack.ModelsViews;

namespace GymnasioEticBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciumsController : ControllerBase
    {
        private readonly BaseArreglaaContext _context;

        public AsistenciumsController(BaseArreglaaContext context)
        {
            _context = context;
        }


        // GET: api/Asistenciums
        [HttpGet]
        public object getInnerJoint()
        {

            var query = _context.Asistencia.Join(_context.Personas, asistencia => asistencia.PersonaId, per => per.Id, (respAsis, respPer) => new
            AsistenciaMV
            {
                IdCita = respAsis.IdCita,
                FechaHora = respAsis.FechaHora,
                PersonaId = respPer.Nombre

            }).ToList();

            return query;
        }

        // GET: api/Asistenciums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asistencium>> GetAsistencium(int id)
        {
          if (_context.Asistencia == null)
          {
              return NotFound();
          }
            var asistencium = await _context.Asistencia.FindAsync(id);

            if (asistencium == null)
            {
                return NotFound();
            }

            return asistencium;
        }

        // PUT: api/Asistenciums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsistencium(int id, Asistencium asistencium)
        {
            if (id != asistencium.IdCita)
            {
                return BadRequest();
            }

            _context.Entry(asistencium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsistenciumExists(id))
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

        // POST: api/Asistenciums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Asistencium>> PostAsistencium(Asistencium asistencium)
        {
          if (_context.Asistencia == null)
          {
              return Problem("Entity set 'BaseArreglaaContext.Asistencia'  is null.");
          }
            _context.Asistencia.Add(asistencium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsistencium", new { id = asistencium.IdCita }, asistencium);
        }

        // DELETE: api/Asistenciums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsistencium(int id)
        {
            if (_context.Asistencia == null)
            {
                return NotFound();
            }
            var asistencium = await _context.Asistencia.FindAsync(id);
            if (asistencium == null)
            {
                return NotFound();
            }

            _context.Asistencia.Remove(asistencium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsistenciumExists(int id)
        {
            return (_context.Asistencia?.Any(e => e.IdCita == id)).GetValueOrDefault();
        }
    }
}
