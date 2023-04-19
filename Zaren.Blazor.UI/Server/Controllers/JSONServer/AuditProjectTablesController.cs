using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ZarenUI.Server.Controllers.JSONServer
{
    [Route("odata/JSONServer/AuditProjectTables")]
    public partial class AuditProjectTablesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditProjectTablesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditProjectTable> GetAuditProjectTables()
        {
            var items = this.context.AuditProjectTables.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectTable>();
            this.OnAuditProjectTablesRead(ref items);

            return items;
        }

        partial void OnAuditProjectTablesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectTable> items);

        partial void OnAuditProjectTableGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectTable> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditProjectTables(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectTable> GetAuditProjectTable(long key)
        {
            var items = this.context.AuditProjectTables.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditProjectTableGet(ref result);

            return result;
        }
        partial void OnAuditProjectTableDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectTable item);
        partial void OnAfterAuditProjectTableDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectTable item);

        [HttpDelete("/odata/JSONServer/AuditProjectTables(LogID={LogID})")]
        public IActionResult DeleteAuditProjectTable(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditProjectTables
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditProjectTableDeleted(item);
                this.context.AuditProjectTables.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditProjectTableDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectTableUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectTable item);
        partial void OnAfterAuditProjectTableUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectTable item);

        [HttpPut("/odata/JSONServer/AuditProjectTables(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditProjectTable(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditProjectTable item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.LogID != key))
                {
                    return BadRequest();
                }
                this.OnAuditProjectTableUpdated(item);
                this.context.AuditProjectTables.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectTables.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditProjectTableUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditProjectTables(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditProjectTable(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditProjectTable> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditProjectTables.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditProjectTableUpdated(item);
                this.context.AuditProjectTables.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectTables.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectTableCreated(ZarenUI.Server.Models.JSONServer.AuditProjectTable item);
        partial void OnAfterAuditProjectTableCreated(ZarenUI.Server.Models.JSONServer.AuditProjectTable item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditProjectTable item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null)
                {
                    return BadRequest();
                }

                this.OnAuditProjectTableCreated(item);
                this.context.AuditProjectTables.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectTables.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditProjectTableCreated(item);

                return new ObjectResult(SingleResult.Create(itemToReturn))
                {
                    StatusCode = 201
                };
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
