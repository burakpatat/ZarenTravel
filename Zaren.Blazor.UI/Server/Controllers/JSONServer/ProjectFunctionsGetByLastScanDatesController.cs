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
    public partial class ProjectFunctionsGetByLastScanDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByLastScanDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByLastScanDatesFunc(LastScanDate={LastScanDate})")]
        public IActionResult ProjectFunctionsGetByLastScanDatesFunc([FromODataUri] string LastScanDate)
        {
            this.OnProjectFunctionsGetByLastScanDatesDefaultParams(ref LastScanDate);

            var items = this.context.ProjectFunctionsGetByLastScanDates.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByLastScanDate] @LastScanDate={0}", LastScanDate).ToList().AsQueryable();

            this.OnProjectFunctionsGetByLastScanDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByLastScanDatesDefaultParams(ref string LastScanDate);

        partial void OnProjectFunctionsGetByLastScanDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByLastScanDate> items);
    }
}
