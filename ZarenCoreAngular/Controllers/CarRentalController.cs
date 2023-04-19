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
    public class CarRentalController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CarRentalController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/CarRental
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarRental>>> GetCarRentals()
        {
            return await _context.CarRental.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/CarRental/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<CarRental>> GetCarRental(string Id)
        {
            var _CarRental = await _context.CarRental.FindAsync(Id);

            if (_CarRental == null)
            {
                return NotFound();
            }

            return _CarRental;
        }
        #endregion

        #region snippet_Update
        // PUT: api/CarRental/5
        public async Task<IActionResult> PutTodoItem(CarRental _CarRental)
        {
            _context.Entry(_CarRental).State = EntityState.Modified;

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
        // POST: api/CarRental
        [HttpPost]
        public async Task<ActionResult<CarRental>> PostTodoItem(CarRental _CarRental)
        {
            _context.CarRental.Add(_CarRental);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetCarRental), new { Id = _CarRental.Id }, _CarRental);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/CarRental/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<CarRental>> DeleteCarRental(string Id)
        {
            var _CarRental = await _context.CarRental.FindAsync(Id);
            if (_CarRental == null)
            {
                return NotFound();
            }

            _context.CarRental.Remove(_CarRental);
            await _context.SaveChangesAsync();

            return _CarRental;
        }
        #endregion

        private bool CarRentalExists(string Id)
        {
            return _context.CarRental.Any(e => e.Id == Id);
        }
    }
}