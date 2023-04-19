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
    public partial class DeviceGroupsGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DeviceGroupsGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DeviceGroupsGetByIdsFunc(Id={Id})")]
        public IActionResult DeviceGroupsGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnDeviceGroupsGetByIdsDefaultParams(ref Id);

            var items = this.context.DeviceGroupsGetByIds.FromSqlRaw("EXEC [dbo].[DeviceGroupsGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnDeviceGroupsGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDeviceGroupsGetByIdsDefaultParams(ref int? Id);

        partial void OnDeviceGroupsGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DeviceGroupsGetById> items);
    }
}
