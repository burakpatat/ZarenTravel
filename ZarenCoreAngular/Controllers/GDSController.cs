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
    public class GDSController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public GDSController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/GDS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GDS>>> GetGDSs()
        {
            return await _context.GDS.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/GDS/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<GDS>> GetGDS(string Id)
        {
            var _GDS = await _context.GDS.FindAsync(Id);

            if (_GDS == null)
            {
                return NotFound();
            }

            return _GDS;
        }
        #endregion

        #region snippet_Update
        // PUT: api/GDS/5
        public async Task<IActionResult> PutTodoItem(GDS _GDS)
        {
            _context.Entry(_GDS).State = EntityState.Modified;

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
        // POST: api/GDS
        [HttpPost]
        public async Task<ActionResult<GDS>> PostTodoItem(GDS _GDS)
        {
            _context.GDS.Add(_GDS);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetGDS), new { Id = _GDS.Id }, _GDS);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/GDS/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<GDS>> DeleteGDS(string Id)
        {
            var _GDS = await _context.GDS.FindAsync(Id);
            if (_GDS == null)
            {
                return NotFound();
            }

            _context.GDS.Remove(_GDS);
            await _context.SaveChangesAsync();

            return _GDS;
        }
        #endregion

        private bool GDSExists(string Id)
        {
            return _context.GDS.Any(e => e.Id == Id);
        }
    }
}