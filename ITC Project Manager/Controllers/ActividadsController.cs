﻿using System;
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
    public class ActividadsController : ControllerBase
    {
        private readonly ItcpmContext _context;

        public ActividadsController(ItcpmContext context)
        {
            _context = context;
        }

        // GET: api/Actividads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actividad>>> GetActividads()
        {
          if (_context.Actividads == null)
          {
              return NotFound();
          }
            return await _context.Actividads.ToListAsync();
        }

        // GET: api/Actividads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actividad>> GetActividad(int id)
        {
          if (_context.Actividads == null)
          {
              return NotFound();
          }
            var actividad = await _context.Actividads.FindAsync(id);

            if (actividad == null)
            {
                return NotFound();
            }

            return actividad;
        }

        // PUT: api/Actividads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActividad(int id, Actividad actividad)
        {
            if (id != actividad.Id)
            {
                return BadRequest();
            }

            _context.Entry(actividad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadExists(id))
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

        // POST: api/Actividads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Actividad>> PostActividad(Actividad actividad)
        {
          if (_context.Actividads == null)
          {
              return Problem("Entity set 'ItcpmContext.Actividads'  is null.");
          }
            _context.Actividads.Add(actividad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActividad", new { id = actividad.Id }, actividad);
        }

        // DELETE: api/Actividads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActividad(int id)
        {
            if (_context.Actividads == null)
            {
                return NotFound();
            }
            var actividad = await _context.Actividads.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }

            _context.Actividads.Remove(actividad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActividadExists(int id)
        {
            return (_context.Actividads?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
