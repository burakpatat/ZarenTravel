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
    public class CompanyController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CompanyController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/Company
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanys()
        {
            return await _context.Company.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/Company/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Company>> GetCompany(string Id)
        {
            var _Company = await _context.Company.FindAsync(Id);

            if (_Company == null)
            {
                return NotFound();
            }

            return _Company;
        }
        #endregion

        #region snippet_Update
        // PUT: api/Company/5
        public async Task<IActionResult> PutTodoItem(Company _Company)
        {
            _context.Entry(_Company).State = EntityState.Modified;

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
        // POST: api/Company
        [HttpPost]
        public async Task<ActionResult<Company>> PostTodoItem(Company _Company)
        {
            _context.Company.Add(_Company);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetCompany), new { Id = _Company.Id }, _Company);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/Company/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Company>> DeleteCompany(string Id)
        {
            var _Company = await _context.Company.FindAsync(Id);
            if (_Company == null)
            {
                return NotFound();
            }

            _context.Company.Remove(_Company);
            await _context.SaveChangesAsync();

            return _Company;
        }
        #endregion

        private bool CompanyExists(string Id)
        {
            return _context.Company.Any(e => e.Id == Id);
        }
    }
}