using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sm_center_TT.Extensions;
using sm_center_TT.Models;
using sm_center_TT.Services;

namespace sm_center_TT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DoctorsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }


        // GET: api/Doctors/5/polyclinic
        [HttpGet("{page}/{sort}")]
        public ActionResult GetDoctorSorted(int page = 0, string? sort = "Polyclinic")
        {
            var doctors = (from doctor in _context.Doctors
                           where doctor.PolyclinicId == null
                           join cabinet in _context.Cabinets on doctor.CabinetId equals cabinet.Id
                           join specialization in _context.Specializations on doctor.SpecializationId equals specialization.Id
                           select new { FullName = doctor.FullName, Specialization = specialization.Name, Cabinet = cabinet.Number, Polyclinic = -1 })

                   .Concat(from doctor in _context.Doctors
                           join cabinet in _context.Cabinets on doctor.CabinetId equals cabinet.Id
                           join specialization in _context.Specializations on doctor.SpecializationId equals specialization.Id
                           join polyclinics in _context.Polyclinics on doctor.PolyclinicId.GetValueOrDefault() equals polyclinics.Id
                           select new { FullName = doctor.FullName, Specialization = specialization.Name, Cabinet = cabinet.Number, Polyclinic = polyclinics.Number });

            if (doctors == null)
            {
                return NotFound();
            }

            return Ok(doctors.OrderByDynamic(sort, false).Skip(page * 5).Take(5));

        }
        
        // PUT: api/Doctors/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

        // POST: api/Doctors

        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new { id = doctor.Id }, doctor);
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
