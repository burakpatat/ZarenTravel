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
    public class ExtrasTypeController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ExtrasTypeController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/ExtrasType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExtrasType>>> GetExtrasTypes()
        {
            return await _context.ExtrasType.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/ExtrasType/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<ExtrasType>> GetExtrasType(string Id)
        {
            var _ExtrasType = await _context.ExtrasType.FindAsync(Id);

            if (_ExtrasType == null)
            {
                return NotFound();
            }

            return _ExtrasType;
        }
        #endregion

        #region snippet_Update
        // PUT: api/ExtrasType/5
        public async Task<IActionResult> PutTodoItem(ExtrasType _ExtrasType)
        {
            _context.Entry(_ExtrasType).State = EntityState.Modified;

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
        // POST: api/ExtrasType
        [HttpPost]
        public async Task<ActionResult<ExtrasType>> PostTodoItem(ExtrasType _ExtrasType)
        {
            _context.ExtrasType.Add(_ExtrasType);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetExtrasType), new { Id = _ExtrasType.Id }, _ExtrasType);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/ExtrasType/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ExtrasType>> DeleteExtrasType(string Id)
        {
            var _ExtrasType = await _context.ExtrasType.FindAsync(Id);
            if (_ExtrasType == null)
            {
                return NotFound();
            }

            _context.ExtrasType.Remove(_ExtrasType);
            await _context.SaveChangesAsync();

            return _ExtrasType;
        }
        #endregion

        private bool ExtrasTypeExists(string Id)
        {
            return _context.ExtrasType.Any(e => e.Id == Id);
        }
    }
}