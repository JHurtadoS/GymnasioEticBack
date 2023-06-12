using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymnasioEticBack.Models;
using GymnasioEticBack.ModelsViews;
using Microsoft.AspNetCore.JsonPatch;


namespace GymnasioEticBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly BaseArreglaaContext _context;

        public PersonasController(BaseArreglaaContext context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonasMV>>> GetPersonas()
        {
            var query = _context.Personas
                .Join(_context.Usuarios,
                    personas => personas.PersonaIdUsuario,
                    user => user.IdUsuario,
                    (respPer, respUser) => new PersonasMV
                    {
                        Id = (int)respPer.Id,
                        Documento = respPer.Documento,
                        Nombre = respPer.Nombre,
                        correoUsuario = respUser.Correo,
                        Apellidos = respPer.Apellidos,
                        Celular = respPer.Celular,
                        Genero = respPer.Genero,
                        Rh = respPer.Rh,
                        Rol = respPer.Rol,
                        Desahabilitado = respPer.Desahabilitado
                    });

            return await query.ToListAsync();
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
          if (_context.Personas == null)
          {
              return NotFound();
          }
            var persona = await _context.Personas.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // PUT: api/Personas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona persona)
        {
            if (id != persona.Id)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        // POST: api/Personas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
          if (_context.Personas == null)
          {
              return Problem("Entity set 'BaseArreglaaContext.Personas'  is null.");
          }
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.Id }, persona);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            if (_context.Personas == null)
            {
                return NotFound();
            }
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaExists(int id)
        {
            return (_context.Personas?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchPersona(int id, [FromBody] PersonaPatch persona)
        {
            if (persona == null)
            {
                return BadRequest();
            }

            var personaFromDb = await _context.Personas.FindAsync(id);

            if (personaFromDb == null)
            {
                return NotFound();
            }

            personaFromDb.Documento = persona.Documento ?? personaFromDb.Documento;

            personaFromDb.Nombre = persona.Nombre ?? personaFromDb.Nombre;
            personaFromDb.Apellidos = persona.Apellidos ?? personaFromDb.Apellidos;
            personaFromDb.Celular = persona.Celular ?? personaFromDb.Celular;
            personaFromDb.Genero = persona.Genero ?? personaFromDb.Genero;
            personaFromDb.Rh = persona.Rh ?? personaFromDb.Rh;
            personaFromDb.Rol = persona.Rol ?? personaFromDb.Rol;
            personaFromDb.Desahabilitado = persona.Desahabilitado ?? personaFromDb.Desahabilitado;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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


    }
}
