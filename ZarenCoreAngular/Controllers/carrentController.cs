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
    public class carrentController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public carrentController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/carrent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<carrent>>> Getcarrents()
        {
            return await _context.carrent.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/carrent/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<carrent>> Getcarrent(string Id)
        {
            var _carrent = await _context.carrent.FindAsync(Id);

            if (_carrent == null)
            {
                return NotFound();
            }

            return _carrent;
        }
        #endregion

        #region snippet_Update
        // PUT: api/carrent/5
        public async Task<IActionResult> PutTodoItem(carrent _carrent)
        {
            _context.Entry(_carrent).State = EntityState.Modified;

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
        // POST: api/carrent
        [HttpPost]
        public async Task<ActionResult<carrent>> PostTodoItem(carrent _carrent)
        {
            _context.carrent.Add(_carrent);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(Getcarrent), new { Id = _carrent.Id }, _carrent);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/carrent/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<carrent>> Deletecarrent(string Id)
        {
            var _carrent = await _context.carrent.FindAsync(Id);
            if (_carrent == null)
            {
                return NotFound();
            }

            _context.carrent.Remove(_carrent);
            await _context.SaveChangesAsync();

            return _carrent;
        }
        #endregion

        private bool carrentExists(string Id)
        {
            return _context.carrent.Any(e => e.Id == Id);
        }
    }
}