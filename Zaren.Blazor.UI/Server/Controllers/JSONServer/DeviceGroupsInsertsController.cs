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
    public partial class DeviceGroupsInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DeviceGroupsInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DeviceGroupsInsertsFunc(Name={Name})")]
        public IActionResult DeviceGroupsInsertsFunc([FromODataUri] string Name)
        {
            this.OnDeviceGroupsInsertsDefaultParams(ref Name);

            var items = this.context.DeviceGroupsInserts.FromSqlRaw("EXEC [dbo].[DeviceGroupsInsert] @Name={0}", Name).ToList().AsQueryable();

            this.OnDeviceGroupsInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDeviceGroupsInsertsDefaultParams(ref string Name);

        partial void OnDeviceGroupsInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DeviceGroupsInsert> items);
    }
}
