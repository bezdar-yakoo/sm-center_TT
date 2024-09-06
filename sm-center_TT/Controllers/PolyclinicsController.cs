using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sm_center_TT.Models;
using sm_center_TT.Services;

namespace sm_center_TT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolyclinicsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PolyclinicsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Polyclinics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Polyclinic>>> GetPolyclinics()
        {
            return await _context.Polyclinics.ToListAsync();
        }

        // GET: api/Polyclinics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Polyclinic>> GetPolyclinic(int id)
        {
            var polyclinic = await _context.Polyclinics.FindAsync(id);

            if (polyclinic == null)
            {
                return NotFound();
            }

            return polyclinic;
        }

        // PUT: api/Polyclinics/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolyclinic(int id, Polyclinic polyclinic)
        {
            if (id != polyclinic.Id)
            {
                return BadRequest();
            }

            _context.Entry(polyclinic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolyclinicExists(id))
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

        // POST: api/Polyclinics

        [HttpPost]
        public async Task<ActionResult<Polyclinic>> PostPolyclinic(Polyclinic polyclinic)
        {
            _context.Polyclinics.Add(polyclinic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolyclinic", new { id = polyclinic.Id }, polyclinic);
        }

        // DELETE: api/Polyclinics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolyclinic(int id)
        {
            var polyclinic = await _context.Polyclinics.FindAsync(id);
            if (polyclinic == null)
            {
                return NotFound();
            }

            _context.Polyclinics.Remove(polyclinic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PolyclinicExists(int id)
        {
            return _context.Polyclinics.Any(e => e.Id == id);
        }
    }
}
