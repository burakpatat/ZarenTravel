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
    public class AirExtrasController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AirExtrasController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/AirExtras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirExtras>>> GetAirExtrass()
        {
            return await _context.AirExtras.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/AirExtras/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<AirExtras>> GetAirExtras(string Id)
        {
            var _AirExtras = await _context.AirExtras.FindAsync(Id);

            if (_AirExtras == null)
            {
                return NotFound();
            }

            return _AirExtras;
        }
        #endregion

        #region snippet_Update
        // PUT: api/AirExtras/5
        public async Task<IActionResult> PutTodoItem(AirExtras _AirExtras)
        {
            _context.Entry(_AirExtras).State = EntityState.Modified;

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
        // POST: api/AirExtras
        [HttpPost]
        public async Task<ActionResult<AirExtras>> PostTodoItem(AirExtras _AirExtras)
        {
            _context.AirExtras.Add(_AirExtras);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetAirExtras), new { Id = _AirExtras.Id }, _AirExtras);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/AirExtras/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<AirExtras>> DeleteAirExtras(string Id)
        {
            var _AirExtras = await _context.AirExtras.FindAsync(Id);
            if (_AirExtras == null)
            {
                return NotFound();
            }

            _context.AirExtras.Remove(_AirExtras);
            await _context.SaveChangesAsync();

            return _AirExtras;
        }
        #endregion

        private bool AirExtrasExists(string Id)
        {
            return _context.AirExtras.Any(e => e.Id == Id);
        }
    }
}