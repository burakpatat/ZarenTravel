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
    public class AgencyGroupController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AgencyGroupController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/AgencyGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgencyGroup>>> GetAgencyGroups()
        {
            return await _context.AgencyGroup.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/AgencyGroup/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<AgencyGroup>> GetAgencyGroup(string Id)
        {
            var _AgencyGroup = await _context.AgencyGroup.FindAsync(Id);

            if (_AgencyGroup == null)
            {
                return NotFound();
            }

            return _AgencyGroup;
        }
        #endregion

        #region snippet_Update
        // PUT: api/AgencyGroup/5
        public async Task<IActionResult> PutTodoItem(AgencyGroup _AgencyGroup)
        {
            _context.Entry(_AgencyGroup).State = EntityState.Modified;

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
        // POST: api/AgencyGroup
        [HttpPost]
        public async Task<ActionResult<AgencyGroup>> PostTodoItem(AgencyGroup _AgencyGroup)
        {
            _context.AgencyGroup.Add(_AgencyGroup);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetAgencyGroup), new { Id = _AgencyGroup.Id }, _AgencyGroup);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/AgencyGroup/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<AgencyGroup>> DeleteAgencyGroup(string Id)
        {
            var _AgencyGroup = await _context.AgencyGroup.FindAsync(Id);
            if (_AgencyGroup == null)
            {
                return NotFound();
            }

            _context.AgencyGroup.Remove(_AgencyGroup);
            await _context.SaveChangesAsync();

            return _AgencyGroup;
        }
        #endregion

        private bool AgencyGroupExists(string Id)
        {
            return _context.AgencyGroup.Any(e => e.Id == Id);
        }
    }
}