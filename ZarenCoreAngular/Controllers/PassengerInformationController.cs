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
    public class PassengerInformationController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PassengerInformationController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/PassengerInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassengerInformation>>> GetPassengerInformations()
        {
            return await _context.PassengerInformation.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/PassengerInformation/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<PassengerInformation>> GetPassengerInformation(string Id)
        {
            var _PassengerInformation = await _context.PassengerInformation.FindAsync(Id);

            if (_PassengerInformation == null)
            {
                return NotFound();
            }

            return _PassengerInformation;
        }
        #endregion

        #region snippet_Update
        // PUT: api/PassengerInformation/5
        public async Task<IActionResult> PutTodoItem(PassengerInformation _PassengerInformation)
        {
            _context.Entry(_PassengerInformation).State = EntityState.Modified;

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
        // POST: api/PassengerInformation
        [HttpPost]
        public async Task<ActionResult<PassengerInformation>> PostTodoItem(PassengerInformation _PassengerInformation)
        {
            _context.PassengerInformation.Add(_PassengerInformation);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetPassengerInformation), new { Id = _PassengerInformation.Id }, _PassengerInformation);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/PassengerInformation/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<PassengerInformation>> DeletePassengerInformation(string Id)
        {
            var _PassengerInformation = await _context.PassengerInformation.FindAsync(Id);
            if (_PassengerInformation == null)
            {
                return NotFound();
            }

            _context.PassengerInformation.Remove(_PassengerInformation);
            await _context.SaveChangesAsync();

            return _PassengerInformation;
        }
        #endregion

        private bool PassengerInformationExists(string Id)
        {
            return _context.PassengerInformation.Any(e => e.Id == Id);
        }
    }
}