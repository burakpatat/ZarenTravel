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
    public class PNRCustomFieldsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PNRCustomFieldsController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/PNRCustomFields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PNRCustomFields>>> GetPNRCustomFieldss()
        {
            return await _context.PNRCustomFields.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/PNRCustomFields/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<PNRCustomFields>> GetPNRCustomFields(string Id)
        {
            var _PNRCustomFields = await _context.PNRCustomFields.FindAsync(Id);

            if (_PNRCustomFields == null)
            {
                return NotFound();
            }

            return _PNRCustomFields;
        }
        #endregion

        #region snippet_Update
        // PUT: api/PNRCustomFields/5
        public async Task<IActionResult> PutTodoItem(PNRCustomFields _PNRCustomFields)
        {
            _context.Entry(_PNRCustomFields).State = EntityState.Modified;

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
        // POST: api/PNRCustomFields
        [HttpPost]
        public async Task<ActionResult<PNRCustomFields>> PostTodoItem(PNRCustomFields _PNRCustomFields)
        {
            _context.PNRCustomFields.Add(_PNRCustomFields);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetPNRCustomFields), new { Id = _PNRCustomFields.Id }, _PNRCustomFields);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/PNRCustomFields/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<PNRCustomFields>> DeletePNRCustomFields(string Id)
        {
            var _PNRCustomFields = await _context.PNRCustomFields.FindAsync(Id);
            if (_PNRCustomFields == null)
            {
                return NotFound();
            }

            _context.PNRCustomFields.Remove(_PNRCustomFields);
            await _context.SaveChangesAsync();

            return _PNRCustomFields;
        }
        #endregion

        private bool PNRCustomFieldsExists(string Id)
        {
            return _context.PNRCustomFields.Any(e => e.Id == Id);
        }
    }
}