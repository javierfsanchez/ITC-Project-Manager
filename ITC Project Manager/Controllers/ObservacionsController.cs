using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITC_Project_Manager.Models;

namespace ITC_Project_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacionsController : ControllerBase
    {
        private readonly ItcpmContext _context;

        public ObservacionsController(ItcpmContext context)
        {
            _context = context;
        }

        // GET: api/Observacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Observacion>>> GetObservacións()
        {
          if (_context.Observacións == null)
          {
              return NotFound();
          }
            return await _context.Observacións.ToListAsync();
        }

        // GET: api/Observacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Observacion>> GetObservacion(int id)
        {
          if (_context.Observacións == null)
          {
              return NotFound();
          }
            var observacion = await _context.Observacións.FindAsync(id);

            if (observacion == null)
            {
                return NotFound();
            }

            return observacion;
        }

        // PUT: api/Observacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObservacion(int id, Observacion observacion)
        {
            if (id != observacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(observacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObservacionExists(id))
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

        // POST: api/Observacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Observacion>> PostObservacion(Observacion observacion)
        {
          if (_context.Observacións == null)
          {
              return Problem("Entity set 'ItcpmContext.Observacións'  is null.");
          }
            _context.Observacións.Add(observacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObservacion", new { id = observacion.Id }, observacion);
        }

        // DELETE: api/Observacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObservacion(int id)
        {
            if (_context.Observacións == null)
            {
                return NotFound();
            }
            var observacion = await _context.Observacións.FindAsync(id);
            if (observacion == null)
            {
                return NotFound();
            }

            _context.Observacións.Remove(observacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObservacionExists(int id)
        {
            return (_context.Observacións?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
