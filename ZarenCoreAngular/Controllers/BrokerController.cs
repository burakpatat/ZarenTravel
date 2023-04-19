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
    public class BrokerController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BrokerController(DatabaseContext context)
        {
            _context = context;
        }
        #endregion

        // GET: api/Broker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Broker>>> GetBrokers()
        {
            return await _context.Broker.ToListAsync();
        }

        #region snippet_GetByID
        // GET: api/Broker/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Broker>> GetBroker(string Id)
        {
            var _Broker = await _context.Broker.FindAsync(Id);

            if (_Broker == null)
            {
                return NotFound();
            }

            return _Broker;
        }
        #endregion

        #region snippet_Update
        // PUT: api/Broker/5
        public async Task<IActionResult> PutTodoItem(Broker _Broker)
        {
            _context.Entry(_Broker).State = EntityState.Modified;

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
        // POST: api/Broker
        [HttpPost]
        public async Task<ActionResult<Broker>> PostTodoItem(Broker _Broker)
        {
            _context.Broker.Add(_Broker);
			
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction(nameof(GetBroker), new { Id = _Broker.Id }, _Broker);
        }
        #endregion

        #region snippet_Delete
        // DELETE: api/Broker/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Broker>> DeleteBroker(string Id)
        {
            var _Broker = await _context.Broker.FindAsync(Id);
            if (_Broker == null)
            {
                return NotFound();
            }

            _context.Broker.Remove(_Broker);
            await _context.SaveChangesAsync();

            return _Broker;
        }
        #endregion

        private bool BrokerExists(string Id)
        {
            return _context.Broker.Any(e => e.Id == Id);
        }
    }
}