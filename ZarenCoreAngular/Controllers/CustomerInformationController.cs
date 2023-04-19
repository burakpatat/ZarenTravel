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
    public class CustomerInformationController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CustomerInformationController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/CustomerInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerInformation>>> GetCustomerInformations()
        {
            return await _context.CustomerInformation.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/CustomerInformation/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<CustomerInformation>> GetCustomerInformation(string Id)
        {
            var _CustomerInformation = await _context.CustomerInformation.FindAsync(Id);

            if (_CustomerInformation == null)
            {
                return NotFound();
            }

            return _CustomerInformation;
        }
        #endregion

        #region snippet_Update
        // PUT: api/CustomerInformation/5
        public async Task<IActionResult> PutTodoItem(CustomerInformation _CustomerInformation)
        {
            _context.Entry(_CustomerInformation).State = EntityState.Modified;

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
        // POST: api/CustomerInformation
        [HttpPost]
        public async Task<ActionResult<CustomerInformation>> PostTodoItem(CustomerInformation _CustomerInformation)
        {
            _context.CustomerInformation.Add(_CustomerInformation);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetCustomerInformation), new { Id = _CustomerInformation.Id }, _CustomerInformation);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/CustomerInformation/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<CustomerInformation>> DeleteCustomerInformation(string Id)
        {
            var _CustomerInformation = await _context.CustomerInformation.FindAsync(Id);
            if (_CustomerInformation == null)
            {
                return NotFound();
            }

            _context.CustomerInformation.Remove(_CustomerInformation);
            await _context.SaveChangesAsync();

            return _CustomerInformation;
        }
        #endregion

        private bool CustomerInformationExists(string Id)
        {
            return _context.CustomerInformation.Any(e => e.Id == Id);
        }
    }
}