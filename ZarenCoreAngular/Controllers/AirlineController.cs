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
    public class AirlineController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AirlineController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/Airline
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Airline>>> GetAirlines()
        {
            return await _context.Airline.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/Airline/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Airline>> GetAirline(string Id)
        {
            var _Airline = await _context.Airline.FindAsync(Id);

            if (_Airline == null)
            {
                return NotFound();
            }

            return _Airline;
        }
        #endregion

        #region snippet_Update
        // PUT: api/Airline/5
        public async Task<IActionResult> PutTodoItem(Airline _Airline)
        {
            _context.Entry(_Airline).State = EntityState.Modified;

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
        // POST: api/Airline
        [HttpPost]
        public async Task<ActionResult<Airline>> PostTodoItem(Airline _Airline)
        {
            _context.Airline.Add(_Airline);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetAirline), new { Id = _Airline.Id }, _Airline);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/Airline/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Airline>> DeleteAirline(string Id)
        {
            var _Airline = await _context.Airline.FindAsync(Id);
            if (_Airline == null)
            {
                return NotFound();
            }

            _context.Airline.Remove(_Airline);
            await _context.SaveChangesAsync();

            return _Airline;
        }
        #endregion

        private bool AirlineExists(string Id)
        {
            return _context.Airline.Any(e => e.Id == Id);
        }
    }
}