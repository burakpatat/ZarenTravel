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
    public class AirportController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AirportController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/Airport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Airport>>> GetAirports()
        {
            return await _context.Airport.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/Airport/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Airport>> GetAirport(string Id)
        {
            var _Airport = await _context.Airport.FindAsync(Id);

            if (_Airport == null)
            {
                return NotFound();
            }

            return _Airport;
        }
        #endregion

        #region snippet_Update
        // PUT: api/Airport/5
        public async Task<IActionResult> PutTodoItem(Airport _Airport)
        {
            _context.Entry(_Airport).State = EntityState.Modified;

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
        // POST: api/Airport
        [HttpPost]
        public async Task<ActionResult<Airport>> PostTodoItem(Airport _Airport)
        {
            _context.Airport.Add(_Airport);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetAirport), new { Id = _Airport.Id }, _Airport);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/Airport/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Airport>> DeleteAirport(string Id)
        {
            var _Airport = await _context.Airport.FindAsync(Id);
            if (_Airport == null)
            {
                return NotFound();
            }

            _context.Airport.Remove(_Airport);
            await _context.SaveChangesAsync();

            return _Airport;
        }
        #endregion

        private bool AirportExists(string Id)
        {
            return _context.Airport.Any(e => e.Id == Id);
        }
    }
}