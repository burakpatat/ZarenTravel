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
    public class RoomTypeController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public RoomTypeController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/RoomType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomType>>> GetRoomTypes()
        {
            return await _context.RoomType.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/RoomType/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<RoomType>> GetRoomType(string Id)
        {
            var _RoomType = await _context.RoomType.FindAsync(Id);

            if (_RoomType == null)
            {
                return NotFound();
            }

            return _RoomType;
        }
        #endregion

        #region snippet_Update
        // PUT: api/RoomType/5
        public async Task<IActionResult> PutTodoItem(RoomType _RoomType)
        {
            _context.Entry(_RoomType).State = EntityState.Modified;

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
        // POST: api/RoomType
        [HttpPost]
        public async Task<ActionResult<RoomType>> PostTodoItem(RoomType _RoomType)
        {
            _context.RoomType.Add(_RoomType);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetRoomType), new { Id = _RoomType.Id }, _RoomType);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/RoomType/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<RoomType>> DeleteRoomType(string Id)
        {
            var _RoomType = await _context.RoomType.FindAsync(Id);
            if (_RoomType == null)
            {
                return NotFound();
            }

            _context.RoomType.Remove(_RoomType);
            await _context.SaveChangesAsync();

            return _RoomType;
        }
        #endregion

        private bool RoomTypeExists(string Id)
        {
            return _context.RoomType.Any(e => e.Id == Id);
        }
    }
}