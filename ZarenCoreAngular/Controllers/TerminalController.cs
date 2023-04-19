using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreWebApi.Models;

namespace CoreWebApi.Controllers
{
    #region CoreWebApi.Controller
    [Route("api/[controller]")]
    [ApiController]
    public class TerminalController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TerminalController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/Terminal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Terminal>>> GetTerminals()
        {
            return await _context.Terminal.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/Terminal/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Terminal>> GetTerminal(string Id)
        {
            var _Terminal = await _context.Terminal.FindAsync(Id);

            if (_Terminal == null)
            {
                return NotFound();
            }

            return _Terminal;
        }
        #endregion

        #region snippet_Update
        // PUT: api/Terminal/5
        public async Task<IActionResult> PutTodoItem(Terminal _Terminal)
        {
            _context.Entry(_Terminal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }
        #endregion

        #region snippet_Create
        // POST: api/Terminal
        [HttpPost]
        public async Task<ActionResult<Terminal>> PostTodoItem(Terminal _Terminal)
        {
            _context.Terminal.Add(_Terminal);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetTerminal), new { Id = _Terminal.Id }, _Terminal);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/Terminal/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Terminal>> DeleteTerminal(string Id)
        {
            var _Terminal = await _context.Terminal.FindAsync(Id);
            if (_Terminal == null)
            {
                return NotFound();
            }

            _context.Terminal.Remove(_Terminal);
            await _context.SaveChangesAsync();

            return _Terminal;
        }
        #endregion

        private bool TerminalExists(string Id)
        {
            return _context.Terminal.Any(e => e.Id == Id);
        }
    }
}