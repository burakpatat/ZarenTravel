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
    public class CurrencyController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CurrencyController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/Currency
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Currency>>> GetCurrencys()
        {
            return await _context.Currency.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/Currency/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Currency>> GetCurrency(string Id)
        {
            var _Currency = await _context.Currency.FindAsync(Id);

            if (_Currency == null)
            {
                return NotFound();
            }

            return _Currency;
        }
        #endregion

        #region snippet_Update
        // PUT: api/Currency/5
        public async Task<IActionResult> PutTodoItem(Currency _Currency)
        {
            _context.Entry(_Currency).State = EntityState.Modified;

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
        // POST: api/Currency
        [HttpPost]
        public async Task<ActionResult<Currency>> PostTodoItem(Currency _Currency)
        {
            _context.Currency.Add(_Currency);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetCurrency), new { Id = _Currency.Id }, _Currency);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/Currency/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Currency>> DeleteCurrency(string Id)
        {
            var _Currency = await _context.Currency.FindAsync(Id);
            if (_Currency == null)
            {
                return NotFound();
            }

            _context.Currency.Remove(_Currency);
            await _context.SaveChangesAsync();

            return _Currency;
        }
        #endregion

        private bool CurrencyExists(string Id)
        {
            return _context.Currency.Any(e => e.Id == Id);
        }
    }
}