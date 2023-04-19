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
    public partial class ProjectPageComponentElementsGetByLastScanDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByLastScanDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByLastScanDatesFunc(LastScanDate={LastScanDate})")]
        public IActionResult ProjectPageComponentElementsGetByLastScanDatesFunc([FromODataUri] string LastScanDate)
        {
            this.OnProjectPageComponentElementsGetByLastScanDatesDefaultParams(ref LastScanDate);

            var items = this.context.ProjectPageComponentElementsGetByLastScanDates.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByLastScanDate] @LastScanDate={0}", LastScanDate).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByLastScanDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByLastScanDatesDefaultParams(ref string LastScanDate);

        partial void OnProjectPageComponentElementsGetByLastScanDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByLastScanDate> items);
    }
}
