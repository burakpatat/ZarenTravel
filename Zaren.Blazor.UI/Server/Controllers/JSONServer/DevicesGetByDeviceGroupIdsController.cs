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
    public partial class DevicesGetByDeviceGroupIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DevicesGetByDeviceGroupIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DevicesGetByDeviceGroupIdsFunc(DeviceGroupId={DeviceGroupId})")]
        public IActionResult DevicesGetByDeviceGroupIdsFunc([FromODataUri] int? DeviceGroupId)
        {
            this.OnDevicesGetByDeviceGroupIdsDefaultParams(ref DeviceGroupId);

            var items = this.context.DevicesGetByDeviceGroupIds.FromSqlRaw("EXEC [dbo].[DevicesGetByDeviceGroupId] @DeviceGroupId={0}", DeviceGroupId).ToList().AsQueryable();

            this.OnDevicesGetByDeviceGroupIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDevicesGetByDeviceGroupIdsDefaultParams(ref int? DeviceGroupId);

        partial void OnDevicesGetByDeviceGroupIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DevicesGetByDeviceGroupId> items);
    }
}
