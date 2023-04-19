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
    public class CompanyGroupController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CompanyGroupController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/CompanyGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyGroup>>> GetCompanyGroups()
        {
            return await _context.CompanyGroup.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/CompanyGroup/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<CompanyGroup>> GetCompanyGroup(string Id)
        {
            var _CompanyGroup = await _context.CompanyGroup.FindAsync(Id);

            if (_CompanyGroup == null)
            {
                return NotFound();
            }

            return _CompanyGroup;
        }
        #endregion

        #region snippet_Update
        // PUT: api/CompanyGroup/5
        public async Task<IActionResult> PutTodoItem(CompanyGroup _CompanyGroup)
        {
            _context.Entry(_CompanyGroup).State = EntityState.Modified;

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
        // POST: api/CompanyGroup
        [HttpPost]
        public async Task<ActionResult<CompanyGroup>> PostTodoItem(CompanyGroup _CompanyGroup)
        {
            _context.CompanyGroup.Add(_CompanyGroup);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetCompanyGroup), new { Id = _CompanyGroup.Id }, _CompanyGroup);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/CompanyGroup/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<CompanyGroup>> DeleteCompanyGroup(string Id)
        {
            var _CompanyGroup = await _context.CompanyGroup.FindAsync(Id);
            if (_CompanyGroup == null)
            {
                return NotFound();
            }

            _context.CompanyGroup.Remove(_CompanyGroup);
            await _context.SaveChangesAsync();

            return _CompanyGroup;
        }
        #endregion

        private bool CompanyGroupExists(string Id)
        {
            return _context.CompanyGroup.Any(e => e.Id == Id);
        }
    }
}