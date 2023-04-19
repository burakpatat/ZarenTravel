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
    public class AgentInformationController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AgentInformationController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/AgentInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgentInformation>>> GetAgentInformations()
        {
            return await _context.AgentInformation.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/AgentInformation/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<AgentInformation>> GetAgentInformation(string Id)
        {
            var _AgentInformation = await _context.AgentInformation.FindAsync(Id);

            if (_AgentInformation == null)
            {
                return NotFound();
            }

            return _AgentInformation;
        }
        #endregion

        #region snippet_Update
        // PUT: api/AgentInformation/5
        public async Task<IActionResult> PutTodoItem(AgentInformation _AgentInformation)
        {
            _context.Entry(_AgentInformation).State = EntityState.Modified;

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
        // POST: api/AgentInformation
        [HttpPost]
        public async Task<ActionResult<AgentInformation>> PostTodoItem(AgentInformation _AgentInformation)
        {
            _context.AgentInformation.Add(_AgentInformation);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetAgentInformation), new { Id = _AgentInformation.Id }, _AgentInformation);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/AgentInformation/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<AgentInformation>> DeleteAgentInformation(string Id)
        {
            var _AgentInformation = await _context.AgentInformation.FindAsync(Id);
            if (_AgentInformation == null)
            {
                return NotFound();
            }

            _context.AgentInformation.Remove(_AgentInformation);
            await _context.SaveChangesAsync();

            return _AgentInformation;
        }
        #endregion

        private bool AgentInformationExists(string Id)
        {
            return _context.AgentInformation.Any(e => e.Id == Id);
        }
    }
}