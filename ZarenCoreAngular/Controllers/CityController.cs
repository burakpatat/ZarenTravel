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
    public class CityController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CityController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/City
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCitys()
        {
            return await _context.City.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/City/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<City>> GetCity(string Id)
        {
            var _City = await _context.City.FindAsync(Id);

            if (_City == null)
            {
                return NotFound();
            }

            return _City;
        }
        #endregion

        #region snippet_Update
        // PUT: api/City/5
        public async Task<IActionResult> PutTodoItem(City _City)
        {
            _context.Entry(_City).State = EntityState.Modified;

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
        // POST: api/City
        [HttpPost]
        public async Task<ActionResult<City>> PostTodoItem(City _City)
        {
            _context.City.Add(_City);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetCity), new { Id = _City.Id }, _City);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/City/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<City>> DeleteCity(string Id)
        {
            var _City = await _context.City.FindAsync(Id);
            if (_City == null)
            {
                return NotFound();
            }

            _context.City.Remove(_City);
            await _context.SaveChangesAsync();

            return _City;
        }
        #endregion

        private bool CityExists(string Id)
        {
            return _context.City.Any(e => e.Id == Id);
        }
    }
}