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
    public class ProgramasController : ControllerBase
    {
        private readonly ItcpmContext _context;

        public ProgramasController(ItcpmContext context)
        {
            _context = context;
        }

        // GET: api/Programas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programa>>> GetProgramas()
        {
          if (_context.Programas == null)
          {
              return NotFound();
          }
            return await _context.Programas.ToListAsync();
        }

        // GET: api/Programas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Programa>> GetPrograma(int id)
        {
          if (_context.Programas == null)
          {
              return NotFound();
          }
            var programa = await _context.Programas.FindAsync(id);

            if (programa == null)
            {
                return NotFound();
            }

            return programa;
        }

        // PUT: api/Programas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrograma(int id, Programa programa)
        {
            if (id != programa.Id)
            {
                return BadRequest();
            }

            _context.Entry(programa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramaExists(id))
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

        // POST: api/Programas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Programa>> PostPrograma(Programa programa)
        {
          if (_context.Programas == null)
          {
              return Problem("Entity set 'ItcpmContext.Programas'  is null.");
          }
            _context.Programas.Add(programa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrograma", new { id = programa.Id }, programa);
        }

        // DELETE: api/Programas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrograma(int id)
        {
            if (_context.Programas == null)
            {
                return NotFound();
            }
            var programa = await _context.Programas.FindAsync(id);
            if (programa == null)
            {
                return NotFound();
            }

            _context.Programas.Remove(programa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgramaExists(int id)
        {
            return (_context.Programas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
