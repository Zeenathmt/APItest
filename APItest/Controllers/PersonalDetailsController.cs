using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APItest.Models;

namespace APItest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDetailsController : ControllerBase
    {
        private readonly PersonalDetailContext _context;

        public PersonalDetailsController(PersonalDetailContext context)
        {
            _context = context;
        }

        // GET: api/PersonalDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalDetail>>> GetPersonalDetails()
        {
            return await _context.PersonalDetails.ToListAsync();
        }

        // GET: api/PersonalDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalDetail>> GetPersonalDetail(int id)
        {
            var personalDetail = await _context.PersonalDetails.FindAsync(id);

            if (personalDetail == null)
            {
                return NotFound();
            }

            return personalDetail;
        }

        // PUT: api/PersonalDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalDetail(int id, PersonalDetail personalDetail)
        {
            if (id != personalDetail.PId)
            {
                return BadRequest();
            }

            _context.Entry(personalDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalDetailExists(id))
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

        // POST: api/PersonalDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PersonalDetail>> PostPersonalDetail(PersonalDetail personalDetail)
        {
            _context.PersonalDetails.Add(personalDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalDetail", new { id = personalDetail.PId }, personalDetail);
        }

        // DELETE: api/PersonalDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonalDetail>> DeletePersonalDetail(int id)
        {
            var personalDetail = await _context.PersonalDetails.FindAsync(id);
            if (personalDetail == null)
            {
                return NotFound();
            }

            _context.PersonalDetails.Remove(personalDetail);
            await _context.SaveChangesAsync();

            return personalDetail;
        }

        private bool PersonalDetailExists(int id)
        {
            return _context.PersonalDetails.Any(e => e.PId == id);
        }
    }
}
