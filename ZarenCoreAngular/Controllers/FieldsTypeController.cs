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
    public class FieldsTypeController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public FieldsTypeController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/FieldsType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FieldsType>>> GetFieldsTypes()
        {
            return await _context.FieldsType.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/FieldsType/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<FieldsType>> GetFieldsType(string Id)
        {
            var _FieldsType = await _context.FieldsType.FindAsync(Id);

            if (_FieldsType == null)
            {
                return NotFound();
            }

            return _FieldsType;
        }
        #endregion

        #region snippet_Update
        // PUT: api/FieldsType/5
        public async Task<IActionResult> PutTodoItem(FieldsType _FieldsType)
        {
            _context.Entry(_FieldsType).State = EntityState.Modified;

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
        // POST: api/FieldsType
        [HttpPost]
        public async Task<ActionResult<FieldsType>> PostTodoItem(FieldsType _FieldsType)
        {
            _context.FieldsType.Add(_FieldsType);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetFieldsType), new { Id = _FieldsType.Id }, _FieldsType);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/FieldsType/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<FieldsType>> DeleteFieldsType(string Id)
        {
            var _FieldsType = await _context.FieldsType.FindAsync(Id);
            if (_FieldsType == null)
            {
                return NotFound();
            }

            _context.FieldsType.Remove(_FieldsType);
            await _context.SaveChangesAsync();

            return _FieldsType;
        }
        #endregion

        private bool FieldsTypeExists(string Id)
        {
            return _context.FieldsType.Any(e => e.Id == Id);
        }
    }
}