using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Entities;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APPUSERsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public APPUSERsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/APPUSERs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<APPUSER>>> GetAPPUSERs()
        {
            return await _context.APPUSERs.ToListAsync();
        }

        // GET: api/APPUSERs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<APPUSER>> GetAPPUSER(int id)
        {
            var aPPUSER = await _context.APPUSERs.FindAsync(id);

            if (aPPUSER == null)
            {
                return NotFound();
            }

            return aPPUSER;
        }

        // PUT: api/APPUSERs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAPPUSER(int id, APPUSER aPPUSER)
        {
            if (id != aPPUSER.id)
            {
                return BadRequest();
            }

            _context.Entry(aPPUSER).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APPUSERExists(id))
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

        // POST: api/APPUSERs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<APPUSER>> PostAPPUSER(APPUSER aPPUSER)
        {
            _context.APPUSERs.Add(aPPUSER);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAPPUSER", new { id = aPPUSER.id }, aPPUSER);
        }

        // DELETE: api/APPUSERs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAPPUSER(int id)
        {
            var aPPUSER = await _context.APPUSERs.FindAsync(id);
            if (aPPUSER == null)
            {
                return NotFound();
            }

            _context.APPUSERs.Remove(aPPUSER);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool APPUSERExists(int id)
        {
            return _context.APPUSERs.Any(e => e.id == id);
        }
    }
}
