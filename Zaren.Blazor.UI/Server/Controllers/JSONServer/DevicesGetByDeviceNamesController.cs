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
    public partial class DevicesGetByDeviceNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DevicesGetByDeviceNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DevicesGetByDeviceNamesFunc(DeviceName={DeviceName})")]
        public IActionResult DevicesGetByDeviceNamesFunc([FromODataUri] string DeviceName)
        {
            this.OnDevicesGetByDeviceNamesDefaultParams(ref DeviceName);

            var items = this.context.DevicesGetByDeviceNames.FromSqlRaw("EXEC [dbo].[DevicesGetByDeviceName] @DeviceName={0}", DeviceName).ToList().AsQueryable();

            this.OnDevicesGetByDeviceNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDevicesGetByDeviceNamesDefaultParams(ref string DeviceName);

        partial void OnDevicesGetByDeviceNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DevicesGetByDeviceName> items);
    }
}
