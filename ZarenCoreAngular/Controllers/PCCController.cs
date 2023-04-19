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
    public class PCCController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PCCController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/PCC
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PCC>>> GetPCCs()
        {
            return await _context.PCC.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/PCC/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<PCC>> GetPCC(string Id)
        {
            var _PCC = await _context.PCC.FindAsync(Id);

            if (_PCC == null)
            {
                return NotFound();
            }

            return _PCC;
        }
        #endregion

        #region snippet_Update
        // PUT: api/PCC/5
        public async Task<IActionResult> PutTodoItem(PCC _PCC)
        {
            _context.Entry(_PCC).State = EntityState.Modified;

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
        // POST: api/PCC
        [HttpPost]
        public async Task<ActionResult<PCC>> PostTodoItem(PCC _PCC)
        {
            _context.PCC.Add(_PCC);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetPCC), new { Id = _PCC.Id }, _PCC);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/PCC/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<PCC>> DeletePCC(string Id)
        {
            var _PCC = await _context.PCC.FindAsync(Id);
            if (_PCC == null)
            {
                return NotFound();
            }

            _context.PCC.Remove(_PCC);
            await _context.SaveChangesAsync();

            return _PCC;
        }
        #endregion

        private bool PCCExists(string Id)
        {
            return _context.PCC.Any(e => e.Id == Id);
        }
    }
}