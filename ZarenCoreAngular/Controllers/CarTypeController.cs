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
    public class CarTypeController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CarTypeController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/CarType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarType>>> GetCarTypes()
        {
            return await _context.CarType.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/CarType/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<CarType>> GetCarType(string Id)
        {
            var _CarType = await _context.CarType.FindAsync(Id);

            if (_CarType == null)
            {
                return NotFound();
            }

            return _CarType;
        }
        #endregion

        #region snippet_Update
        // PUT: api/CarType/5
        public async Task<IActionResult> PutTodoItem(CarType _CarType)
        {
            _context.Entry(_CarType).State = EntityState.Modified;

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
        // POST: api/CarType
        [HttpPost]
        public async Task<ActionResult<CarType>> PostTodoItem(CarType _CarType)
        {
            _context.CarType.Add(_CarType);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetCarType), new { Id = _CarType.Id }, _CarType);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/CarType/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<CarType>> DeleteCarType(string Id)
        {
            var _CarType = await _context.CarType.FindAsync(Id);
            if (_CarType == null)
            {
                return NotFound();
            }

            _context.CarType.Remove(_CarType);
            await _context.SaveChangesAsync();

            return _CarType;
        }
        #endregion

        private bool CarTypeExists(string Id)
        {
            return _context.CarType.Any(e => e.Id == Id);
        }
    }
}