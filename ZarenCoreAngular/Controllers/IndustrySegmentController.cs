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
    public class IndustrySegmentController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public IndustrySegmentController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/IndustrySegment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IndustrySegment>>> GetIndustrySegments()
        {
            return await _context.IndustrySegment.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/IndustrySegment/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<IndustrySegment>> GetIndustrySegment(string Id)
        {
            var _IndustrySegment = await _context.IndustrySegment.FindAsync(Id);

            if (_IndustrySegment == null)
            {
                return NotFound();
            }

            return _IndustrySegment;
        }
        #endregion

        #region snippet_Update
        // PUT: api/IndustrySegment/5
        public async Task<IActionResult> PutTodoItem(IndustrySegment _IndustrySegment)
        {
            _context.Entry(_IndustrySegment).State = EntityState.Modified;

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
        // POST: api/IndustrySegment
        [HttpPost]
        public async Task<ActionResult<IndustrySegment>> PostTodoItem(IndustrySegment _IndustrySegment)
        {
            _context.IndustrySegment.Add(_IndustrySegment);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetIndustrySegment), new { Id = _IndustrySegment.Id }, _IndustrySegment);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/IndustrySegment/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<IndustrySegment>> DeleteIndustrySegment(string Id)
        {
            var _IndustrySegment = await _context.IndustrySegment.FindAsync(Id);
            if (_IndustrySegment == null)
            {
                return NotFound();
            }

            _context.IndustrySegment.Remove(_IndustrySegment);
            await _context.SaveChangesAsync();

            return _IndustrySegment;
        }
        #endregion

        private bool IndustrySegmentExists(string Id)
        {
            return _context.IndustrySegment.Any(e => e.Id == Id);
        }
    }
}