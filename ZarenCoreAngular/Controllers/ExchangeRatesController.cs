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
    public class ExchangeRatesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ExchangeRatesController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/ExchangeRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExchangeRates>>> GetExchangeRatess()
        {
            return await _context.ExchangeRates.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/ExchangeRates/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<ExchangeRates>> GetExchangeRates(string Id)
        {
            var _ExchangeRates = await _context.ExchangeRates.FindAsync(Id);

            if (_ExchangeRates == null)
            {
                return NotFound();
            }

            return _ExchangeRates;
        }
        #endregion

        #region snippet_Update
        // PUT: api/ExchangeRates/5
        public async Task<IActionResult> PutTodoItem(ExchangeRates _ExchangeRates)
        {
            _context.Entry(_ExchangeRates).State = EntityState.Modified;

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
        // POST: api/ExchangeRates
        [HttpPost]
        public async Task<ActionResult<ExchangeRates>> PostTodoItem(ExchangeRates _ExchangeRates)
        {
            _context.ExchangeRates.Add(_ExchangeRates);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetExchangeRates), new { Id = _ExchangeRates.Id }, _ExchangeRates);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/ExchangeRates/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ExchangeRates>> DeleteExchangeRates(string Id)
        {
            var _ExchangeRates = await _context.ExchangeRates.FindAsync(Id);
            if (_ExchangeRates == null)
            {
                return NotFound();
            }

            _context.ExchangeRates.Remove(_ExchangeRates);
            await _context.SaveChangesAsync();

            return _ExchangeRates;
        }
        #endregion

        private bool ExchangeRatesExists(string Id)
        {
            return _context.ExchangeRates.Any(e => e.Id == Id);
        }
    }
}