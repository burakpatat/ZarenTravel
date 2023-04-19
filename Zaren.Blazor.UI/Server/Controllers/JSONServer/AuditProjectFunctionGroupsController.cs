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
    [Route("odata/JSONServer/AuditProjectFunctionGroups")]
    public partial class AuditProjectFunctionGroupsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditProjectFunctionGroupsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditProjectFunctionGroup> GetAuditProjectFunctionGroups()
        {
            var items = this.context.AuditProjectFunctionGroups.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectFunctionGroup>();
            this.OnAuditProjectFunctionGroupsRead(ref items);

            return items;
        }

        partial void OnAuditProjectFunctionGroupsRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditProjectFunctionGroup> items);

        partial void OnAuditProjectFunctionGroupGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectFunctionGroup> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditProjectFunctionGroups(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditProjectFunctionGroup> GetAuditProjectFunctionGroup(long key)
        {
            var items = this.context.AuditProjectFunctionGroups.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditProjectFunctionGroupGet(ref result);

            return result;
        }
        partial void OnAuditProjectFunctionGroupDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectFunctionGroup item);
        partial void OnAfterAuditProjectFunctionGroupDeleted(ZarenUI.Server.Models.JSONServer.AuditProjectFunctionGroup item);

        [HttpDelete("/odata/JSONServer/AuditProjectFunctionGroups(LogID={LogID})")]
        public IActionResult DeleteAuditProjectFunctionGroup(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditProjectFunctionGroups
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditProjectFunctionGroupDeleted(item);
                this.context.AuditProjectFunctionGroups.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditProjectFunctionGroupDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectFunctionGroupUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectFunctionGroup item);
        partial void OnAfterAuditProjectFunctionGroupUpdated(ZarenUI.Server.Models.JSONServer.AuditProjectFunctionGroup item);

        [HttpPut("/odata/JSONServer/AuditProjectFunctionGroups(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditProjectFunctionGroup(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditProjectFunctionGroup item)
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
                this.OnAuditProjectFunctionGroupUpdated(item);
                this.context.AuditProjectFunctionGroups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectFunctionGroups.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditProjectFunctionGroupUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditProjectFunctionGroups(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditProjectFunctionGroup(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditProjectFunctionGroup> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditProjectFunctionGroups.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditProjectFunctionGroupUpdated(item);
                this.context.AuditProjectFunctionGroups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectFunctionGroups.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditProjectFunctionGroupCreated(ZarenUI.Server.Models.JSONServer.AuditProjectFunctionGroup item);
        partial void OnAfterAuditProjectFunctionGroupCreated(ZarenUI.Server.Models.JSONServer.AuditProjectFunctionGroup item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditProjectFunctionGroup item)
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

                this.OnAuditProjectFunctionGroupCreated(item);
                this.context.AuditProjectFunctionGroups.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditProjectFunctionGroups.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditProjectFunctionGroupCreated(item);

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
