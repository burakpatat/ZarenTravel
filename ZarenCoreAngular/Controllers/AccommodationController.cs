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
    public class AccommodationController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AccommodationController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/Accommodation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accommodation>>> GetAccommodations()
        {
            return await _context.Accommodation.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/Accommodation/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Accommodation>> GetAccommodation(string Id)
        {
            var _Accommodation = await _context.Accommodation.FindAsync(Id);

            if (_Accommodation == null)
            {
                return NotFound();
            }

            return _Accommodation;
        }
        #endregion

        #region snippet_Update
        // PUT: api/Accommodation/5
        public async Task<IActionResult> PutTodoItem(Accommodation _Accommodation)
        {
            _context.Entry(_Accommodation).State = EntityState.Modified;

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
        // POST: api/Accommodation
        [HttpPost]
        public async Task<ActionResult<Accommodation>> PostTodoItem(Accommodation _Accommodation)
        {
            _context.Accommodation.Add(_Accommodation);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetAccommodation), new { Id = _Accommodation.Id }, _Accommodation);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/Accommodation/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Accommodation>> DeleteAccommodation(string Id)
        {
            var _Accommodation = await _context.Accommodation.FindAsync(Id);
            if (_Accommodation == null)
            {
                return NotFound();
            }

            _context.Accommodation.Remove(_Accommodation);
            await _context.SaveChangesAsync();

            return _Accommodation;
        }
        #endregion

        private bool AccommodationExists(string Id)
        {
            return _context.Accommodation.Any(e => e.Id == Id);
        }
    }
}