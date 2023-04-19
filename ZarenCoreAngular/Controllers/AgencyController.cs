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
    public class AgencyController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AgencyController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/Agency
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agency>>> GetAgencys()
        {
            return await _context.Agency.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/Agency/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Agency>> GetAgency(string Id)
        {
            var _Agency = await _context.Agency.FindAsync(Id);

            if (_Agency == null)
            {
                return NotFound();
            }

            return _Agency;
        }
        #endregion

        #region snippet_Update
        // PUT: api/Agency/5
        public async Task<IActionResult> PutTodoItem(Agency _Agency)
        {
            _context.Entry(_Agency).State = EntityState.Modified;

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
        // POST: api/Agency
        [HttpPost]
        public async Task<ActionResult<Agency>> PostTodoItem(Agency _Agency)
        {
            _context.Agency.Add(_Agency);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetAgency), new { Id = _Agency.Id }, _Agency);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/Agency/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Agency>> DeleteAgency(string Id)
        {
            var _Agency = await _context.Agency.FindAsync(Id);
            if (_Agency == null)
            {
                return NotFound();
            }

            _context.Agency.Remove(_Agency);
            await _context.SaveChangesAsync();

            return _Agency;
        }
        #endregion

        private bool AgencyExists(string Id)
        {
            return _context.Agency.Any(e => e.Id == Id);
        }
    }
}