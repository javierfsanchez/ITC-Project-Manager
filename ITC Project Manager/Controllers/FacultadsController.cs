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
    public class FacultadsController : ControllerBase
    {
        private readonly ItcpmContext _context;

        public FacultadsController(ItcpmContext context)
        {
            _context = context;
        }

        // GET: api/Facultads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facultad>>> GetFacultads()
        {
          if (_context.Facultads == null)
          {
              return NotFound();
          }
            return await _context.Facultads.ToListAsync();
        }

        // GET: api/Facultads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facultad>> GetFacultad(int id)
        {
          if (_context.Facultads == null)
          {
              return NotFound();
          }
            var facultad = await _context.Facultads.FindAsync(id);

            if (facultad == null)
            {
                return NotFound();
            }

            return facultad;
        }

        // PUT: api/Facultads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacultad(int id, Facultad facultad)
        {
            if (id != facultad.Id)
            {
                return BadRequest();
            }

            _context.Entry(facultad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacultadExists(id))
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

        // POST: api/Facultads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Facultad>> PostFacultad(Facultad facultad)
        {
          if (_context.Facultads == null)
          {
              return Problem("Entity set 'ItcpmContext.Facultads'  is null.");
          }
            _context.Facultads.Add(facultad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacultad", new { id = facultad.Id }, facultad);
        }

        // DELETE: api/Facultads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacultad(int id)
        {
            if (_context.Facultads == null)
            {
                return NotFound();
            }
            var facultad = await _context.Facultads.FindAsync(id);
            if (facultad == null)
            {
                return NotFound();
            }

            _context.Facultads.Remove(facultad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacultadExists(int id)
        {
            return (_context.Facultads?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
