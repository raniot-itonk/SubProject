using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DB;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CraftsmenController : ControllerBase
    {
        private readonly CraftsmanContext _context;

        public CraftsmenController(CraftsmanContext context)
        {
            _context = context;
        }

        // GET: api/Craftsmen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Craftsman>>> GetCraftsmen()
        {
            return await _context.Craftsmen.Include(craftsman => craftsman.ToolBoxes).ThenInclude(box => box.Tools).ToListAsync();
        }

        // GET: api/Craftsmen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Craftsman>> GetCraftsman(long id)
        {
            var craftsman = await _context.Craftsmen.FindAsync(id);

            if (craftsman == null)
            {
                return NotFound();
            }

            return craftsman;
        }

        // PUT: api/Craftsmen/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCraftsman(long id, Craftsman craftsman)
        {
            if (id != craftsman.Id)
            {
                return BadRequest();
            }

            _context.Entry(craftsman).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CraftsmanExists(id))
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

        // POST: api/Craftsmen
        [HttpPost]
        public async Task<ActionResult<Craftsman>> PostCraftsman(Craftsman craftsman)
        {
            _context.Craftsmen.Add(craftsman);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCraftsman", new { id = craftsman.Id }, craftsman);
        }

        // DELETE: api/Craftsmen/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Craftsman>> DeleteCraftsman(long id)
        {
            var craftsman = await _context.Craftsmen.Include(craftsman1 => craftsman1.ToolBoxes)
                .ThenInclude(box => box.Tools).FirstOrDefaultAsync(craftsman1 => craftsman1.Id == id);
            if (craftsman == null)
            {
                return NotFound();
            }

            _context.Craftsmen.Remove(craftsman);
            await _context.SaveChangesAsync();

            return craftsman;
        }

        private bool CraftsmanExists(long id)
        {
            return _context.Craftsmen.Any(e => e.Id == id);
        }
    }
}
