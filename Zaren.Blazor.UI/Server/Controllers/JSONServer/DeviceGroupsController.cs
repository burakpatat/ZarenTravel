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
    [Route("odata/JSONServer/DeviceGroups")]
    public partial class DeviceGroupsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DeviceGroupsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.JSONServer.DeviceGroup> GetDeviceGroups()
        {
            var items = this.context.DeviceGroups.AsQueryable<ZarenUI.Server.Models.JSONServer.DeviceGroup>();
            this.OnDeviceGroupsRead(ref items);

            return items;
        }

        partial void OnDeviceGroupsRead(ref IQueryable<ZarenUI.Server.Models.JSONServer.DeviceGroup> items);

        partial void OnDeviceGroupGet(ref SingleResult<ZarenUI.Server.Models.JSONServer.DeviceGroup> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/JSONServer/DeviceGroups(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.JSONServer.DeviceGroup> GetDeviceGroup(int key)
        {
            var items = this.context.DeviceGroups.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnDeviceGroupGet(ref result);

            return result;
        }
        partial void OnDeviceGroupDeleted(ZarenUI.Server.Models.JSONServer.DeviceGroup item);
        partial void OnAfterDeviceGroupDeleted(ZarenUI.Server.Models.JSONServer.DeviceGroup item);

        [HttpDelete("/odata/JSONServer/DeviceGroups(Id={Id})")]
        public IActionResult DeleteDeviceGroup(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.DeviceGroups
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnDeviceGroupDeleted(item);
                this.context.DeviceGroups.Remove(item);
                this.context.SaveChanges();
                this.OnAfterDeviceGroupDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnDeviceGroupUpdated(ZarenUI.Server.Models.JSONServer.DeviceGroup item);
        partial void OnAfterDeviceGroupUpdated(ZarenUI.Server.Models.JSONServer.DeviceGroup item);

        [HttpPut("/odata/JSONServer/DeviceGroups(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutDeviceGroup(int key, [FromBody]ZarenUI.Server.Models.JSONServer.DeviceGroup item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.Id != key))
                {
                    return BadRequest();
                }
                this.OnDeviceGroupUpdated(item);
                this.context.DeviceGroups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.DeviceGroups.Where(i => i.Id == key);
                ;
                this.OnAfterDeviceGroupUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/JSONServer/DeviceGroups(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchDeviceGroup(int key, [FromBody]Delta<ZarenUI.Server.Models.JSONServer.DeviceGroup> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.DeviceGroups.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnDeviceGroupUpdated(item);
                this.context.DeviceGroups.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.DeviceGroups.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnDeviceGroupCreated(ZarenUI.Server.Models.JSONServer.DeviceGroup item);
        partial void OnAfterDeviceGroupCreated(ZarenUI.Server.Models.JSONServer.DeviceGroup item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.JSONServer.DeviceGroup item)
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

                this.OnDeviceGroupCreated(item);
                this.context.DeviceGroups.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.DeviceGroups.Where(i => i.Id == item.Id);

                ;

                this.OnAfterDeviceGroupCreated(item);

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
