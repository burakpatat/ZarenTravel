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
    public class AirController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AirController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/Air
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Air>>> GetAirs()
        {
            return await _context.Air.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/Air/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Air>> GetAir(string Id)
        {
            var _Air = await _context.Air.FindAsync(Id);

            if (_Air == null)
            {
                return NotFound();
            }

            return _Air;
        }
        #endregion

        #region snippet_Update
        // PUT: api/Air/5
        public async Task<IActionResult> PutTodoItem(Air _Air)
        {
            _context.Entry(_Air).State = EntityState.Modified;

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
        // POST: api/Air
        [HttpPost]
        public async Task<ActionResult<Air>> PostTodoItem(Air _Air)
        {
            _context.Air.Add(_Air);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetAir), new { Id = _Air.Id }, _Air);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/Air/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Air>> DeleteAir(string Id)
        {
            var _Air = await _context.Air.FindAsync(Id);
            if (_Air == null)
            {
                return NotFound();
            }

            _context.Air.Remove(_Air);
            await _context.SaveChangesAsync();

            return _Air;
        }
        #endregion

        private bool AirExists(string Id)
        {
            return _context.Air.Any(e => e.Id == Id);
        }
    }
}