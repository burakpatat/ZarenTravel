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
    public partial class DevicesGetByHeightsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DevicesGetByHeightsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DevicesGetByHeightsFunc(Height={Height})")]
        public IActionResult DevicesGetByHeightsFunc([FromODataUri] int? Height)
        {
            this.OnDevicesGetByHeightsDefaultParams(ref Height);

            var items = this.context.DevicesGetByHeights.FromSqlRaw("EXEC [dbo].[DevicesGetByHeight] @Height={0}", Height).ToList().AsQueryable();

            this.OnDevicesGetByHeightsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDevicesGetByHeightsDefaultParams(ref int? Height);

        partial void OnDevicesGetByHeightsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DevicesGetByHeight> items);
    }
}
