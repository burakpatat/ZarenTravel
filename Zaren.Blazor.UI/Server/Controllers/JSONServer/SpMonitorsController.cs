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
    public partial class SpMonitorsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public SpMonitorsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/SpMonitorsFunc()")]
        public IActionResult SpMonitorsFunc()
        {
            this.OnSpMonitorsDefaultParams();

            var items = this.context.SpMonitors.FromSqlRaw("EXEC [dbo].[sp_monitor] ").ToList().AsQueryable();

            this.OnSpMonitorsInvoke(ref items);

            return Ok(items);
        }

        partial void OnSpMonitorsDefaultParams();

        partial void OnSpMonitorsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.SpMonitor> items);
    }
}
