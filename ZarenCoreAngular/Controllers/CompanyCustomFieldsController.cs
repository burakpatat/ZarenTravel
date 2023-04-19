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
    public class CompanyCustomFieldsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CompanyCustomFieldsController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/CompanyCustomFields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyCustomFields>>> GetCompanyCustomFieldss()
        {
            return await _context.CompanyCustomFields.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/CompanyCustomFields/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<CompanyCustomFields>> GetCompanyCustomFields(string Id)
        {
            var _CompanyCustomFields = await _context.CompanyCustomFields.FindAsync(Id);

            if (_CompanyCustomFields == null)
            {
                return NotFound();
            }

            return _CompanyCustomFields;
        }
        #endregion

        #region snippet_Update
        // PUT: api/CompanyCustomFields/5
        public async Task<IActionResult> PutTodoItem(CompanyCustomFields _CompanyCustomFields)
        {
            _context.Entry(_CompanyCustomFields).State = EntityState.Modified;

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
        // POST: api/CompanyCustomFields
        [HttpPost]
        public async Task<ActionResult<CompanyCustomFields>> PostTodoItem(CompanyCustomFields _CompanyCustomFields)
        {
            _context.CompanyCustomFields.Add(_CompanyCustomFields);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetCompanyCustomFields), new { Id = _CompanyCustomFields.Id }, _CompanyCustomFields);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/CompanyCustomFields/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<CompanyCustomFields>> DeleteCompanyCustomFields(string Id)
        {
            var _CompanyCustomFields = await _context.CompanyCustomFields.FindAsync(Id);
            if (_CompanyCustomFields == null)
            {
                return NotFound();
            }

            _context.CompanyCustomFields.Remove(_CompanyCustomFields);
            await _context.SaveChangesAsync();

            return _CompanyCustomFields;
        }
        #endregion

        private bool CompanyCustomFieldsExists(string Id)
        {
            return _context.CompanyCustomFields.Any(e => e.Id == Id);
        }
    }
}