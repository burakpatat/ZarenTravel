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
    public class ReservationInformationController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ReservationInformationController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/ReservationInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationInformation>>> GetReservationInformations()
        {
            return await _context.ReservationInformation.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/ReservationInformation/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<ReservationInformation>> GetReservationInformation(string Id)
        {
            var _ReservationInformation = await _context.ReservationInformation.FindAsync(Id);

            if (_ReservationInformation == null)
            {
                return NotFound();
            }

            return _ReservationInformation;
        }
        #endregion

        #region snippet_Update
        // PUT: api/ReservationInformation/5
        public async Task<IActionResult> PutTodoItem(ReservationInformation _ReservationInformation)
        {
            _context.Entry(_ReservationInformation).State = EntityState.Modified;

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
        // POST: api/ReservationInformation
        [HttpPost]
        public async Task<ActionResult<ReservationInformation>> PostTodoItem(ReservationInformation _ReservationInformation)
        {
            _context.ReservationInformation.Add(_ReservationInformation);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetReservationInformation), new { Id = _ReservationInformation.Id }, _ReservationInformation);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/ReservationInformation/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ReservationInformation>> DeleteReservationInformation(string Id)
        {
            var _ReservationInformation = await _context.ReservationInformation.FindAsync(Id);
            if (_ReservationInformation == null)
            {
                return NotFound();
            }

            _context.ReservationInformation.Remove(_ReservationInformation);
            await _context.SaveChangesAsync();

            return _ReservationInformation;
        }
        #endregion

        private bool ReservationInformationExists(string Id)
        {
            return _context.ReservationInformation.Any(e => e.Id == Id);
        }
    }
}