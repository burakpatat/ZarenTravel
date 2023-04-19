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
    public partial class DeviceGroupsGetAllsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DeviceGroupsGetAllsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DeviceGroupsGetAllsFunc()")]
        public IActionResult DeviceGroupsGetAllsFunc()
        {
            this.OnDeviceGroupsGetAllsDefaultParams();

            var items = this.context.DeviceGroupsGetAlls.FromSqlRaw("EXEC [dbo].[DeviceGroupsGetAll] ").ToList().AsQueryable();

            this.OnDeviceGroupsGetAllsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDeviceGroupsGetAllsDefaultParams();

        partial void OnDeviceGroupsGetAllsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DeviceGroupsGetAll> items);
    }
}
