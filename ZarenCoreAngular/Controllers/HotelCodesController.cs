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
    public class HotelCodesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public HotelCodesController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/HotelCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelCodes>>> GetHotelCodess()
        {
            return await _context.HotelCodes.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/HotelCodes/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<HotelCodes>> GetHotelCodes(string Id)
        {
            var _HotelCodes = await _context.HotelCodes.FindAsync(Id);

            if (_HotelCodes == null)
            {
                return NotFound();
            }

            return _HotelCodes;
        }
        #endregion

        #region snippet_Update
        // PUT: api/HotelCodes/5
        public async Task<IActionResult> PutTodoItem(HotelCodes _HotelCodes)
        {
            _context.Entry(_HotelCodes).State = EntityState.Modified;

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
        // POST: api/HotelCodes
        [HttpPost]
        public async Task<ActionResult<HotelCodes>> PostTodoItem(HotelCodes _HotelCodes)
        {
            _context.HotelCodes.Add(_HotelCodes);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetHotelCodes), new { Id = _HotelCodes.Id }, _HotelCodes);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/HotelCodes/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<HotelCodes>> DeleteHotelCodes(string Id)
        {
            var _HotelCodes = await _context.HotelCodes.FindAsync(Id);
            if (_HotelCodes == null)
            {
                return NotFound();
            }

            _context.HotelCodes.Remove(_HotelCodes);
            await _context.SaveChangesAsync();

            return _HotelCodes;
        }
        #endregion

        private bool HotelCodesExists(string Id)
        {
            return _context.HotelCodes.Any(e => e.Id == Id);
        }
    }
}