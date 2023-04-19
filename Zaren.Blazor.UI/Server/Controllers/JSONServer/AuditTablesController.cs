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
    [Route("odata/JSONServer/AuditTables")]
    public partial class AuditTablesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditTablesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditTable> GetAuditTables()
        {
            var items = this.context.AuditTables.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditTable>();
            this.OnAuditTablesRead(ref items);

            return items;
        }

        partial void OnAuditTablesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditTable> items);

        partial void OnAuditTableGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditTable> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditTables(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditTable> GetAuditTable(long key)
        {
            var items = this.context.AuditTables.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditTableGet(ref result);

            return result;
        }
        partial void OnAuditTableDeleted(ZarenUI.Server.Models.JSONServer.AuditTable item);
        partial void OnAfterAuditTableDeleted(ZarenUI.Server.Models.JSONServer.AuditTable item);

        [HttpDelete("/odata/JSONServer/AuditTables(LogID={LogID})")]
        public IActionResult DeleteAuditTable(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditTables
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditTableDeleted(item);
                this.context.AuditTables.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditTableDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditTableUpdated(ZarenUI.Server.Models.JSONServer.AuditTable item);
        partial void OnAfterAuditTableUpdated(ZarenUI.Server.Models.JSONServer.AuditTable item);

        [HttpPut("/odata/JSONServer/AuditTables(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditTable(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditTable item)
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
                this.OnAuditTableUpdated(item);
                this.context.AuditTables.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditTables.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditTableUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditTables(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditTable(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditTable> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditTables.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditTableUpdated(item);
                this.context.AuditTables.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditTables.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditTableCreated(ZarenUI.Server.Models.JSONServer.AuditTable item);
        partial void OnAfterAuditTableCreated(ZarenUI.Server.Models.JSONServer.AuditTable item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditTable item)
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

                this.OnAuditTableCreated(item);
                this.context.AuditTables.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditTables.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditTableCreated(item);

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
