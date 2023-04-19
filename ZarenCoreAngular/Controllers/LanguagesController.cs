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
    public class LanguagesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public LanguagesController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/Languages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Languages>>> GetLanguagess()
        {
            return await _context.Languages.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/Languages/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Languages>> GetLanguages(string Id)
        {
            var _Languages = await _context.Languages.FindAsync(Id);

            if (_Languages == null)
            {
                return NotFound();
            }

            return _Languages;
        }
        #endregion

        #region snippet_Update
        // PUT: api/Languages/5
        public async Task<IActionResult> PutTodoItem(Languages _Languages)
        {
            _context.Entry(_Languages).State = EntityState.Modified;

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
        // POST: api/Languages
        [HttpPost]
        public async Task<ActionResult<Languages>> PostTodoItem(Languages _Languages)
        {
            _context.Languages.Add(_Languages);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetLanguages), new { Id = _Languages.Id }, _Languages);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/Languages/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Languages>> DeleteLanguages(string Id)
        {
            var _Languages = await _context.Languages.FindAsync(Id);
            if (_Languages == null)
            {
                return NotFound();
            }

            _context.Languages.Remove(_Languages);
            await _context.SaveChangesAsync();

            return _Languages;
        }
        #endregion

        private bool LanguagesExists(string Id)
        {
            return _context.Languages.Any(e => e.Id == Id);
        }
    }
}