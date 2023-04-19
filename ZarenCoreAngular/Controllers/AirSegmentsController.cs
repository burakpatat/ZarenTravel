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
    public class AirSegmentsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AirSegmentsController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/AirSegments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirSegments>>> GetAirSegmentss()
        {
            return await _context.AirSegments.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/AirSegments/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<AirSegments>> GetAirSegments(string Id)
        {
            var _AirSegments = await _context.AirSegments.FindAsync(Id);

            if (_AirSegments == null)
            {
                return NotFound();
            }

            return _AirSegments;
        }
        #endregion

        #region snippet_Update
        // PUT: api/AirSegments/5
        public async Task<IActionResult> PutTodoItem(AirSegments _AirSegments)
        {
            _context.Entry(_AirSegments).State = EntityState.Modified;

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
        // POST: api/AirSegments
        [HttpPost]
        public async Task<ActionResult<AirSegments>> PostTodoItem(AirSegments _AirSegments)
        {
            _context.AirSegments.Add(_AirSegments);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetAirSegments), new { Id = _AirSegments.Id }, _AirSegments);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/AirSegments/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<AirSegments>> DeleteAirSegments(string Id)
        {
            var _AirSegments = await _context.AirSegments.FindAsync(Id);
            if (_AirSegments == null)
            {
                return NotFound();
            }

            _context.AirSegments.Remove(_AirSegments);
            await _context.SaveChangesAsync();

            return _AirSegments;
        }
        #endregion

        private bool AirSegmentsExists(string Id)
        {
            return _context.AirSegments.Any(e => e.Id == Id);
        }
    }
}