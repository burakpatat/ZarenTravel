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
    public class PNRController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PNRController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/PNR
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PNR>>> GetPNRs()
        {
            return await _context.PNR.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/PNR/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<PNR>> GetPNR(string Id)
        {
            var _PNR = await _context.PNR.FindAsync(Id);

            if (_PNR == null)
            {
                return NotFound();
            }

            return _PNR;
        }
        #endregion

        #region snippet_Update
        // PUT: api/PNR/5
        public async Task<IActionResult> PutTodoItem(PNR _PNR)
        {
            _context.Entry(_PNR).State = EntityState.Modified;

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
        // POST: api/PNR
        [HttpPost]
        public async Task<ActionResult<PNR>> PostTodoItem(PNR _PNR)
        {
            _context.PNR.Add(_PNR);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetPNR), new { Id = _PNR.Id }, _PNR);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/PNR/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<PNR>> DeletePNR(string Id)
        {
            var _PNR = await _context.PNR.FindAsync(Id);
            if (_PNR == null)
            {
                return NotFound();
            }

            _context.PNR.Remove(_PNR);
            await _context.SaveChangesAsync();

            return _PNR;
        }
        #endregion

        private bool PNRExists(string Id)
        {
            return _context.PNR.Any(e => e.Id == Id);
        }
    }
}