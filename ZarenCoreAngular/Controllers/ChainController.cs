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
    public class ChainController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ChainController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/Chain
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chain>>> GetChains()
        {
            return await _context.Chain.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/Chain/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Chain>> GetChain(string Id)
        {
            var _Chain = await _context.Chain.FindAsync(Id);

            if (_Chain == null)
            {
                return NotFound();
            }

            return _Chain;
        }
        #endregion

        #region snippet_Update
        // PUT: api/Chain/5
        public async Task<IActionResult> PutTodoItem(Chain _Chain)
        {
            _context.Entry(_Chain).State = EntityState.Modified;

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
        // POST: api/Chain
        [HttpPost]
        public async Task<ActionResult<Chain>> PostTodoItem(Chain _Chain)
        {
            _context.Chain.Add(_Chain);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetChain), new { Id = _Chain.Id }, _Chain);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/Chain/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Chain>> DeleteChain(string Id)
        {
            var _Chain = await _context.Chain.FindAsync(Id);
            if (_Chain == null)
            {
                return NotFound();
            }

            _context.Chain.Remove(_Chain);
            await _context.SaveChangesAsync();

            return _Chain;
        }
        #endregion

        private bool ChainExists(string Id)
        {
            return _context.Chain.Any(e => e.Id == Id);
        }
    }
}