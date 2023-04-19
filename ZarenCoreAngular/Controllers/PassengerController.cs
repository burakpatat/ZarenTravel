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
    public class PassengerController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PassengerController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/Passenger
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passenger>>> GetPassengers()
        {
            return await _context.Passenger.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/Passenger/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Passenger>> GetPassenger(string Id)
        {
            var _Passenger = await _context.Passenger.FindAsync(Id);

            if (_Passenger == null)
            {
                return NotFound();
            }

            return _Passenger;
        }
        #endregion

        #region snippet_Update
        // PUT: api/Passenger/5
        public async Task<IActionResult> PutTodoItem(Passenger _Passenger)
        {
            _context.Entry(_Passenger).State = EntityState.Modified;

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
        // POST: api/Passenger
        [HttpPost]
        public async Task<ActionResult<Passenger>> PostTodoItem(Passenger _Passenger)
        {
            _context.Passenger.Add(_Passenger);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetPassenger), new { Id = _Passenger.Id }, _Passenger);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/Passenger/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Passenger>> DeletePassenger(string Id)
        {
            var _Passenger = await _context.Passenger.FindAsync(Id);
            if (_Passenger == null)
            {
                return NotFound();
            }

            _context.Passenger.Remove(_Passenger);
            await _context.SaveChangesAsync();

            return _Passenger;
        }
        #endregion

        private bool PassengerExists(string Id)
        {
            return _context.Passenger.Any(e => e.Id == Id);
        }
    }
}