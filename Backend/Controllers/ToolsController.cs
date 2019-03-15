﻿using System;
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
    public class ToolsController : ControllerBase
    {
        private readonly CraftsmanContext _context;

        public ToolsController(CraftsmanContext context)
        {
            _context = context;
        }

        // GET: api/Tools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tool>>> GetTools()
        {
            return await _context.Tools.ToListAsync();
        }

        // GET: api/Tools/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tool>> GetTool(long id)
        {
            var tool = await _context.Tools.FindAsync(id);

            if (tool == null)
            {
                return NotFound();
            }

            return tool;
        }

        // PUT: api/Tools/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTool(long id, Tool tool)
        {
            if (id != tool.Id)
            {
                return BadRequest();
            }

            _context.Entry(tool).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToolExists(id))
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

        // POST: api/Tools
        [HttpPost]
        public async Task<ActionResult<Tool>> PostTool(Tool tool)
        {
            _context.Tools.Add(tool);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTool", new { id = tool.Id }, tool);
        }

        // DELETE: api/Tools/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tool>> DeleteTool(long id)
        {
            var tool = await _context.Tools.FindAsync(id);
            if (tool == null)
            {
                return NotFound();
            }

            _context.Tools.Remove(tool);
            await _context.SaveChangesAsync();

            return tool;
        }

        private bool ToolExists(long id)
        {
            return _context.Tools.Any(e => e.Id == id);
        }
    }
}
