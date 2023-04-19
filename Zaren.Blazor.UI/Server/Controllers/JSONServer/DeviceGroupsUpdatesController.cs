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
    public partial class DeviceGroupsUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DeviceGroupsUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DeviceGroupsUpdatesFunc(Id={Id},Name={Name})")]
        public IActionResult DeviceGroupsUpdatesFunc([FromODataUri] int? Id, [FromODataUri] string Name)
        {
            this.OnDeviceGroupsUpdatesDefaultParams(ref Id, ref Name);

            var items = this.context.DeviceGroupsUpdates.FromSqlRaw("EXEC [dbo].[DeviceGroupsUpdate] @Id={0}, @Name={1}", Id, Name).ToList().AsQueryable();

            this.OnDeviceGroupsUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDeviceGroupsUpdatesDefaultParams(ref int? Id, ref string Name);

        partial void OnDeviceGroupsUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DeviceGroupsUpdate> items);
    }
}
