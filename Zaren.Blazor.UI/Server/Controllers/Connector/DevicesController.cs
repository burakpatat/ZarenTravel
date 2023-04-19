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

namespace ZarenUI.Server.Controllers.Connector
{
    [Route("odata/Connector/Devices")]
    public partial class DevicesController : ODataController
    {
        private ZarenUI.Server.Data.ConnectorContext context;

        public DevicesController(ZarenUI.Server.Data.ConnectorContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<ZarenUI.Server.Models.Connector.Device> GetDevices()
        {
            var items = this.context.Devices.AsQueryable<ZarenUI.Server.Models.Connector.Device>();
            this.OnDevicesRead(ref items);

            return items;
        }

        partial void OnDevicesRead(ref IQueryable<ZarenUI.Server.Models.Connector.Device> items);

        partial void OnDeviceGet(ref SingleResult<ZarenUI.Server.Models.Connector.Device> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/Connector/Devices(Id={Id})")]
        public SingleResult<ZarenUI.Server.Models.Connector.Device> GetDevice(int key)
        {
            var items = this.context.Devices.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnDeviceGet(ref result);

            return result;
        }
        partial void OnDeviceDeleted(ZarenUI.Server.Models.Connector.Device item);
        partial void OnAfterDeviceDeleted(ZarenUI.Server.Models.Connector.Device item);

        [HttpDelete("/odata/Connector/Devices(Id={Id})")]
        public IActionResult DeleteDevice(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.Devices
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnDeviceDeleted(item);
                this.context.Devices.Remove(item);
                this.context.SaveChanges();
                this.OnAfterDeviceDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnDeviceUpdated(ZarenUI.Server.Models.Connector.Device item);
        partial void OnAfterDeviceUpdated(ZarenUI.Server.Models.Connector.Device item);

        [HttpPut("/odata/Connector/Devices(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutDevice(int key, [FromBody]ZarenUI.Server.Models.Connector.Device item)
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
                this.OnDeviceUpdated(item);
                this.context.Devices.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Devices.Where(i => i.Id == key);
                ;
                this.OnAfterDeviceUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/Connector/Devices(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchDevice(int key, [FromBody]Delta<ZarenUI.Server.Models.Connector.Device> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.Devices.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnDeviceUpdated(item);
                this.context.Devices.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Devices.Where(i => i.Id == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnDeviceCreated(ZarenUI.Server.Models.Connector.Device item);
        partial void OnAfterDeviceCreated(ZarenUI.Server.Models.Connector.Device item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] ZarenUI.Server.Models.Connector.Device item)
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

                this.OnDeviceCreated(item);
                this.context.Devices.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Devices.Where(i => i.Id == item.Id);

                ;

                this.OnAfterDeviceCreated(item);

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
