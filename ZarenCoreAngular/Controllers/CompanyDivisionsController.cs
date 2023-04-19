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
    public class CompanyDivisionsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CompanyDivisionsController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/CompanyDivisions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDivisions>>> GetCompanyDivisionss()
        {
            return await _context.CompanyDivisions.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/CompanyDivisions/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<CompanyDivisions>> GetCompanyDivisions(string Id)
        {
            var _CompanyDivisions = await _context.CompanyDivisions.FindAsync(Id);

            if (_CompanyDivisions == null)
            {
                return NotFound();
            }

            return _CompanyDivisions;
        }
        #endregion

        #region snippet_Update
        // PUT: api/CompanyDivisions/5
        public async Task<IActionResult> PutTodoItem(CompanyDivisions _CompanyDivisions)
        {
            _context.Entry(_CompanyDivisions).State = EntityState.Modified;

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
        // POST: api/CompanyDivisions
        [HttpPost]
        public async Task<ActionResult<CompanyDivisions>> PostTodoItem(CompanyDivisions _CompanyDivisions)
        {
            _context.CompanyDivisions.Add(_CompanyDivisions);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetCompanyDivisions), new { Id = _CompanyDivisions.Id }, _CompanyDivisions);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/CompanyDivisions/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<CompanyDivisions>> DeleteCompanyDivisions(string Id)
        {
            var _CompanyDivisions = await _context.CompanyDivisions.FindAsync(Id);
            if (_CompanyDivisions == null)
            {
                return NotFound();
            }

            _context.CompanyDivisions.Remove(_CompanyDivisions);
            await _context.SaveChangesAsync();

            return _CompanyDivisions;
        }
        #endregion

        private bool CompanyDivisionsExists(string Id)
        {
            return _context.CompanyDivisions.Any(e => e.Id == Id);
        }
    }
}