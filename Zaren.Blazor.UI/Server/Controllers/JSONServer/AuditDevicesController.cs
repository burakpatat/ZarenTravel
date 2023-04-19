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
    [Route("odata/JSONServer/AuditDevices")]
    public partial class AuditDevicesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public AuditDevicesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.AuditDevice> GetAuditDevices()
        {
            var items = this.context.AuditDevices.AsQueryable<ZarenUI.Server.Models.JSONServer.AuditDevice>();
            this.OnAuditDevicesRead(ref items);

            return items;
        }

        partial void OnAuditDevicesRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.AuditDevice> items);

        partial void OnAuditDeviceGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.AuditDevice> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/AuditDevices(LogID={LogID})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.AuditDevice> GetAuditDevice(long key)
        {
            var items = this.context.AuditDevices.Where(i => i.LogID == key);
            var result = SingleResult.Create(items);

            OnAuditDeviceGet(ref result);

            return result;
        }
        partial void OnAuditDeviceDeleted(ZarenUI.Server.Models.JSONServer.AuditDevice item);
        partial void OnAfterAuditDeviceDeleted(ZarenUI.Server.Models.JSONServer.AuditDevice item);

        [HttpDelete("/odata/JSONServer/AuditDevices(LogID={LogID})")]
        public IActionResult DeleteAuditDevice(long key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.AuditDevices
                    .Where(i => i.LogID == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnAuditDeviceDeleted(item);
                this.context.AuditDevices.Remove(item);
                this.context.SaveChanges();
                this.OnAfterAuditDeviceDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditDeviceUpdated(ZarenUI.Server.Models.JSONServer.AuditDevice item);
        partial void OnAfterAuditDeviceUpdated(ZarenUI.Server.Models.JSONServer.AuditDevice item);

        [HttpPut("/odata/JSONServer/AuditDevices(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutAuditDevice(long key, [FromBody]ZarenUI.Server.Models.JSONServer.AuditDevice item)
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
                this.OnAuditDeviceUpdated(item);
                this.context.AuditDevices.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditDevices.Where(i => i.LogID == key);
                ;
                this.OnAfterAuditDeviceUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/AuditDevices(LogID={LogID})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchAuditDevice(long key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.AuditDevice> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.AuditDevices.Where(i => i.LogID == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnAuditDeviceUpdated(item);
                this.context.AuditDevices.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditDevices.Where(i => i.LogID == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnAuditDeviceCreated(ZarenUI.Server.Models.JSONServer.AuditDevice item);
        partial void OnAfterAuditDeviceCreated(ZarenUI.Server.Models.JSONServer.AuditDevice item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.AuditDevice item)
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

                this.OnAuditDeviceCreated(item);
                this.context.AuditDevices.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.AuditDevices.Where(i => i.LogID == item.LogID);

                ;

                this.OnAfterAuditDeviceCreated(item);

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
