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
    public class HotelController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public HotelController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/Hotel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            return await _context.Hotel.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/Hotel/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Hotel>> GetHotel(string Id)
        {
            var _Hotel = await _context.Hotel.FindAsync(Id);

            if (_Hotel == null)
            {
                return NotFound();
            }

            return _Hotel;
        }
        #endregion

        #region snippet_Update
        // PUT: api/Hotel/5
        public async Task<IActionResult> PutTodoItem(Hotel _Hotel)
        {
            _context.Entry(_Hotel).State = EntityState.Modified;

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
        // POST: api/Hotel
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostTodoItem(Hotel _Hotel)
        {
            _context.Hotel.Add(_Hotel);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetHotel), new { Id = _Hotel.Id }, _Hotel);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/Hotel/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel(string Id)
        {
            var _Hotel = await _context.Hotel.FindAsync(Id);
            if (_Hotel == null)
            {
                return NotFound();
            }

            _context.Hotel.Remove(_Hotel);
            await _context.SaveChangesAsync();

            return _Hotel;
        }
        #endregion

        private bool HotelExists(string Id)
        {
            return _context.Hotel.Any(e => e.Id == Id);
        }
    }
}