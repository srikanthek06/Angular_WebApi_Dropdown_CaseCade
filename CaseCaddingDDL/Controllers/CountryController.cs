using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaseCaddingDDL.Data;
using CaseCaddingDDL.Models;
using Microsoft.AspNetCore.Cors;

namespace CaseCaddingDDL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CountryPolicy")]
    public class CountryController : ControllerBase
    {
        private readonly CascadeContext _context;

        public CountryController(CascadeContext context)
        {
            _context = context;
        }

        // GET: api/Country
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryMaster>>> GetCountry()
        {
            try
            {
                 var result = await _context.Country.Include(s => s.States).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryMaster>> GetCountryMaster(int id)
        {
            var countryMaster = await _context.Country
                .Include(s => s.States)
                .FirstOrDefaultAsync(c => c.CountryId == id);

            if (countryMaster == null)
            {
                return NotFound();
            }

            return countryMaster;
        }

        // GET: api/Country/5/state
        [HttpGet("{id}/state")]
        public async Task<ActionResult<IList<StateMaster>>> GetStates(int id)
        {
            var countryMaster = await _context.Country
                .Include(s => s.States)
                .FirstOrDefaultAsync(c => c.CountryId == id);

            if (countryMaster == null)
            {
                return NotFound();
            }

            return countryMaster.States.ToList();
        }

        // PUT: api/Country/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountryMaster(int id, CountryMaster countryMaster)
        {
            if (id != countryMaster.CountryId)
            {
                return BadRequest();
            }

            _context.Entry(countryMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryMasterExists(id))
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

        // POST: api/Country
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CountryMaster>> PostCountryMaster(CountryMaster countryMaster)
        {
            _context.Country.Add(countryMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountryMaster", new { id = countryMaster.CountryId }, countryMaster);
        }

        // DELETE: api/Country/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CountryMaster>> DeleteCountryMaster(int id)
        {
            var countryMaster = await _context.Country.FindAsync(id);
            if (countryMaster == null)
            {
                return NotFound();
            }

            _context.Country.Remove(countryMaster);
            await _context.SaveChangesAsync();

            return countryMaster;
        }

        private bool CountryMasterExists(int id)
        {
            return _context.Country.Any(e => e.CountryId == id);
        }
    }
}
