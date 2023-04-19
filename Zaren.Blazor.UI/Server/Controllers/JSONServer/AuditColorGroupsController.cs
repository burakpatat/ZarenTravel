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
    [Route("odata/JSONServer/AuditColorGroups")]
    public partial class AuditColorGroupsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditColorGroupsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditColorGroup> GetAuditColorGroups()
        {
            var items = this.context.AuditColorGroups.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditColorGroup>();
            this.OnAuditColorGroupsRead(ref items);

            return items;
        }

        partial void OnAuditColorGroupsRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditColorGroup> items);

        partial void OnAuditColorGroupGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditColorGroup> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditColorGroups(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditColorGroup> GetAuditColorGroup(long key)
        {
            var items = this.context.AuditColorGroups.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditColorGroupGet(ref result);

            return result;
        }
        partial void OnAuditColorGroupDeleted(ZarenUI.Server.Models.JSONServer.AuditColorGroup item);
        partial void OnAfterAuditColorGroupDeleted(ZarenUI.Server.Models.JSONServer.AuditColorGroup item);

        [HttpDelete("/odata/JSONServer/AuditColorGroups(LogID={LogID})")]
        public IActionResult DeleteAuditColorGroup(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditColorGroups
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditColorGroupDeleted(item);
                this.context.AuditColorGroups.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditColorGroupDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditColorGroupUpdated(ZarenUI.Server.Models.JSONServer.AuditColorGroup item);
        partial void OnAfterAuditColorGroupUpdated(ZarenUI.Server.Models.JSONServer.AuditColorGroup item);

        [HttpPut("/odata/JSONServer/AuditColorGroups(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditColorGroup(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditColorGroup item)
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
                this.OnAuditColorGroupUpdated(item);
                this.context.AuditColorGroups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditColorGroups.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditColorGroupUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditColorGroups(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditColorGroup(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditColorGroup> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditColorGroups.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditColorGroupUpdated(item);
                this.context.AuditColorGroups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditColorGroups.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditColorGroupCreated(ZarenUI.Server.Models.JSONServer.AuditColorGroup item);
        partial void OnAfterAuditColorGroupCreated(ZarenUI.Server.Models.JSONServer.AuditColorGroup item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditColorGroup item)
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

                this.OnAuditColorGroupCreated(item);
                this.context.AuditColorGroups.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditColorGroups.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditColorGroupCreated(item);

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
