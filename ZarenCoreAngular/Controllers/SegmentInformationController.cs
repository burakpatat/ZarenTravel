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
    public class SegmentInformationController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SegmentInformationController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/SegmentInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SegmentInformation>>> GetSegmentInformations()
        {
            return await _context.SegmentInformation.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/SegmentInformation/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<SegmentInformation>> GetSegmentInformation(string Id)
        {
            var _SegmentInformation = await _context.SegmentInformation.FindAsync(Id);

            if (_SegmentInformation == null)
            {
                return NotFound();
            }

            return _SegmentInformation;
        }
        #endregion

        #region snippet_Update
        // PUT: api/SegmentInformation/5
        public async Task<IActionResult> PutTodoItem(SegmentInformation _SegmentInformation)
        {
            _context.Entry(_SegmentInformation).State = EntityState.Modified;

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
        // POST: api/SegmentInformation
        [HttpPost]
        public async Task<ActionResult<SegmentInformation>> PostTodoItem(SegmentInformation _SegmentInformation)
        {
            _context.SegmentInformation.Add(_SegmentInformation);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetSegmentInformation), new { Id = _SegmentInformation.Id }, _SegmentInformation);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/SegmentInformation/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<SegmentInformation>> DeleteSegmentInformation(string Id)
        {
            var _SegmentInformation = await _context.SegmentInformation.FindAsync(Id);
            if (_SegmentInformation == null)
            {
                return NotFound();
            }

            _context.SegmentInformation.Remove(_SegmentInformation);
            await _context.SaveChangesAsync();

            return _SegmentInformation;
        }
        #endregion

        private bool SegmentInformationExists(string Id)
        {
            return _context.SegmentInformation.Any(e => e.Id == Id);
        }
    }
}