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
    public class CountryController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CountryController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/Country
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountrys()
        {
            return await _context.Country.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/Country/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Country>> GetCountry(string Id)
        {
            var _Country = await _context.Country.FindAsync(Id);

            if (_Country == null)
            {
                return NotFound();
            }

            return _Country;
        }
        #endregion

        #region snippet_Update
        // PUT: api/Country/5
        public async Task<IActionResult> PutTodoItem(Country _Country)
        {
            _context.Entry(_Country).State = EntityState.Modified;

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
        // POST: api/Country
        [HttpPost]
        public async Task<ActionResult<Country>> PostTodoItem(Country _Country)
        {
            _context.Country.Add(_Country);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetCountry), new { Id = _Country.Id }, _Country);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/Country/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Country>> DeleteCountry(string Id)
        {
            var _Country = await _context.Country.FindAsync(Id);
            if (_Country == null)
            {
                return NotFound();
            }

            _context.Country.Remove(_Country);
            await _context.SaveChangesAsync();

            return _Country;
        }
        #endregion

        private bool CountryExists(string Id)
        {
            return _context.Country.Any(e => e.Id == Id);
        }
    }
}