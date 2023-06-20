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
    public class EventoesController : ControllerBase
    {
        private readonly BaseArreglaaContext _context;

        public EventoesController(BaseArreglaaContext context)
        {
            _context = context;
        }

        // GET: api/Eventoes
        [HttpGet]

        public object getInnerJoint()
        {

            var query = _context.Eventos.Join(_context.Personas, evento => evento.PersonaId, per => per.Id, (respEven, respPer) => new
            EventoMV
            {
                IdEventos = respEven.IdEventos,
                Nombre = respEven.Nombre,
                Fecha = respEven.Fecha,
                HoraInicio = respEven.HoraInicio,
                HoraSalida = respEven.HoraSalida,
                PersonaId = respPer.Nombre

            }).ToList();

            return Ok(query);
        }

        // GET: api/Eventoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
          if (_context.Eventos == null)
          {
              return NotFound();
          }
            var evento = await _context.Eventos.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        // PUT: api/Eventoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento evento)
        {
            if (id != evento.IdEventos)
            {
                return BadRequest();
            }

            _context.Entry(evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
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

        // POST: api/Eventoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(Evento evento)
        {
          if (_context.Eventos == null)
          {
              return Problem("Entity set 'BaseArreglaaContext.Eventos'  is null.");
          }
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvento", new { id = evento.IdEventos }, evento);
        }

        // DELETE: api/Eventoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            if (_context.Eventos == null)
            {
                return NotFound();
            }
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoExists(int id)
        {
            return (_context.Eventos?.Any(e => e.IdEventos == id)).GetValueOrDefault();
        }
    }
}
