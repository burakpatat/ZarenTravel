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
    [Route("odata/JSONServer/AuditDeviceGroups")]
    public partial class AuditDeviceGroupsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditDeviceGroupsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditDeviceGroup> GetAuditDeviceGroups()
        {
            var items = this.context.AuditDeviceGroups.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditDeviceGroup>();
            this.OnAuditDeviceGroupsRead(ref items);

            return items;
        }

        partial void OnAuditDeviceGroupsRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditDeviceGroup> items);

        partial void OnAuditDeviceGroupGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditDeviceGroup> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditDeviceGroups(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditDeviceGroup> GetAuditDeviceGroup(long key)
        {
            var items = this.context.AuditDeviceGroups.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditDeviceGroupGet(ref result);

            return result;
        }
        partial void OnAuditDeviceGroupDeleted(ZarenUI.Server.Models.JSONServer.AuditDeviceGroup item);
        partial void OnAfterAuditDeviceGroupDeleted(ZarenUI.Server.Models.JSONServer.AuditDeviceGroup item);

        [HttpDelete("/odata/JSONServer/AuditDeviceGroups(LogID={LogID})")]
        public IActionResult DeleteAuditDeviceGroup(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditDeviceGroups
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditDeviceGroupDeleted(item);
                this.context.AuditDeviceGroups.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditDeviceGroupDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditDeviceGroupUpdated(ZarenUI.Server.Models.JSONServer.AuditDeviceGroup item);
        partial void OnAfterAuditDeviceGroupUpdated(ZarenUI.Server.Models.JSONServer.AuditDeviceGroup item);

        [HttpPut("/odata/JSONServer/AuditDeviceGroups(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditDeviceGroup(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditDeviceGroup item)
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
                this.OnAuditDeviceGroupUpdated(item);
                this.context.AuditDeviceGroups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditDeviceGroups.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditDeviceGroupUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditDeviceGroups(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditDeviceGroup(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditDeviceGroup> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditDeviceGroups.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditDeviceGroupUpdated(item);
                this.context.AuditDeviceGroups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditDeviceGroups.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditDeviceGroupCreated(ZarenUI.Server.Models.JSONServer.AuditDeviceGroup item);
        partial void OnAfterAuditDeviceGroupCreated(ZarenUI.Server.Models.JSONServer.AuditDeviceGroup item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditDeviceGroup item)
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

                this.OnAuditDeviceGroupCreated(item);
                this.context.AuditDeviceGroups.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditDeviceGroups.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditDeviceGroupCreated(item);

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
