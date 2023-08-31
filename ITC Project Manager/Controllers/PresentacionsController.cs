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
    public class PresentacionsController : ControllerBase
    {
        private readonly ItcpmContext _context;

        public PresentacionsController(ItcpmContext context)
        {
            _context = context;
        }

        // GET: api/Presentacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Presentacion>>> GetPresentacións()
        {
          if (_context.Presentacións == null)
          {
              return NotFound();
          }
            return await _context.Presentacións.ToListAsync();
        }

        // GET: api/Presentacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Presentacion>> GetPresentacion(int id)
        {
          if (_context.Presentacións == null)
          {
              return NotFound();
          }
            var presentacion = await _context.Presentacións.FindAsync(id);

            if (presentacion == null)
            {
                return NotFound();
            }

            return presentacion;
        }

        // PUT: api/Presentacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPresentacion(int id, Presentacion presentacion)
        {
            if (id != presentacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(presentacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresentacionExists(id))
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

        // POST: api/Presentacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Presentacion>> PostPresentacion(Presentacion presentacion)
        {
          if (_context.Presentacións == null)
          {
              return Problem("Entity set 'ItcpmContext.Presentacións'  is null.");
          }
            _context.Presentacións.Add(presentacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPresentacion", new { id = presentacion.Id }, presentacion);
        }

        // DELETE: api/Presentacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePresentacion(int id)
        {
            if (_context.Presentacións == null)
            {
                return NotFound();
            }
            var presentacion = await _context.Presentacións.FindAsync(id);
            if (presentacion == null)
            {
                return NotFound();
            }

            _context.Presentacións.Remove(presentacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PresentacionExists(int id)
        {
            return (_context.Presentacións?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
