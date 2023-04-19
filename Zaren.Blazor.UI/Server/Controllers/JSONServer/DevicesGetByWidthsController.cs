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
    public partial class DevicesGetByWidthsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DevicesGetByWidthsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DevicesGetByWidthsFunc(Width={Width})")]
        public IActionResult DevicesGetByWidthsFunc([FromODataUri] int? Width)
        {
            this.OnDevicesGetByWidthsDefaultParams(ref Width);

            var items = this.context.DevicesGetByWidths.FromSqlRaw("EXEC [dbo].[DevicesGetByWidth] @Width={0}", Width).ToList().AsQueryable();

            this.OnDevicesGetByWidthsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDevicesGetByWidthsDefaultParams(ref int? Width);

        partial void OnDevicesGetByWidthsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DevicesGetByWidth> items);
    }
}
