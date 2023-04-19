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
    public partial class ProjectPageComponentsGetByLastScanDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByLastScanDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByLastScanDatesFunc(LastScanDate={LastScanDate})")]
        public IActionResult ProjectPageComponentsGetByLastScanDatesFunc([FromODataUri] string LastScanDate)
        {
            this.OnProjectPageComponentsGetByLastScanDatesDefaultParams(ref LastScanDate);

            var items = this.context.ProjectPageComponentsGetByLastScanDates.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByLastScanDate] @LastScanDate={0}", LastScanDate).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByLastScanDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByLastScanDatesDefaultParams(ref string LastScanDate);

        partial void OnProjectPageComponentsGetByLastScanDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByLastScanDate> items);
    }
}
