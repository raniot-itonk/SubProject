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
    public class ToolBoxesController : ControllerBase
    {
        private readonly CraftsmanContext _context;

        public ToolBoxesController(CraftsmanContext context)
        {
            _context = context;
        }

        // GET: api/ToolBoxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToolBox>>> GetToolBoxes()
        {
            return await _context.ToolBoxes.Include(box => box.Tools).ToListAsync();
        }

        // GET: api/ToolBoxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToolBox>> GetToolBox(long id)
        {
            var toolBox = await _context.ToolBoxes.FindAsync(id);

            if (toolBox == null)
            {
                return NotFound();
            }

            return toolBox;
        }

        // PUT: api/ToolBoxes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToolBox(long id, ToolBox toolBox)
        {
            if (id != toolBox.Id)
            {
                return BadRequest();
            }

            _context.Entry(toolBox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToolBoxExists(id))
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

        // POST: api/ToolBoxes
        [HttpPost]
        public async Task<ActionResult<ToolBox>> PostToolBox(ToolBox toolBox)
        {
            _context.ToolBoxes.Add(toolBox);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToolBox", new { id = toolBox.Id }, toolBox);
        }

        // DELETE: api/ToolBoxes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ToolBox>> DeleteToolBox(long id)
        {
            var toolBox = await _context.ToolBoxes.Include(box => box.Tools).FirstOrDefaultAsync(box => box.Id == id);
            if (toolBox == null)
            {
                return NotFound();
            }

            _context.ToolBoxes.Remove(toolBox);
            await _context.SaveChangesAsync();

            return toolBox;
        }

        private bool ToolBoxExists(long id)
        {
            return _context.ToolBoxes.Any(e => e.Id == id);
        }
    }
}
