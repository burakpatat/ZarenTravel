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
    public class AccommodationExtrasController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AccommodationExtrasController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/AccommodationExtras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccommodationExtras>>> GetAccommodationExtrass()
        {
            return await _context.AccommodationExtras.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/AccommodationExtras/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<AccommodationExtras>> GetAccommodationExtras(string Id)
        {
            var _AccommodationExtras = await _context.AccommodationExtras.FindAsync(Id);

            if (_AccommodationExtras == null)
            {
                return NotFound();
            }

            return _AccommodationExtras;
        }
        #endregion

        #region snippet_Update
        // PUT: api/AccommodationExtras/5
        public async Task<IActionResult> PutTodoItem(AccommodationExtras _AccommodationExtras)
        {
            _context.Entry(_AccommodationExtras).State = EntityState.Modified;

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
        // POST: api/AccommodationExtras
        [HttpPost]
        public async Task<ActionResult<AccommodationExtras>> PostTodoItem(AccommodationExtras _AccommodationExtras)
        {
            _context.AccommodationExtras.Add(_AccommodationExtras);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetAccommodationExtras), new { Id = _AccommodationExtras.Id }, _AccommodationExtras);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/AccommodationExtras/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<AccommodationExtras>> DeleteAccommodationExtras(string Id)
        {
            var _AccommodationExtras = await _context.AccommodationExtras.FindAsync(Id);
            if (_AccommodationExtras == null)
            {
                return NotFound();
            }

            _context.AccommodationExtras.Remove(_AccommodationExtras);
            await _context.SaveChangesAsync();

            return _AccommodationExtras;
        }
        #endregion

        private bool AccommodationExtrasExists(string Id)
        {
            return _context.AccommodationExtras.Any(e => e.Id == Id);
        }
    }
}