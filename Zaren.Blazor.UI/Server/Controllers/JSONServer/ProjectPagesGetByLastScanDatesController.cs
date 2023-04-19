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
    public partial class ProjectPagesGetByLastScanDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByLastScanDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByLastScanDatesFunc(LastScanDate={LastScanDate})")]
        public IActionResult ProjectPagesGetByLastScanDatesFunc([FromODataUri] string LastScanDate)
        {
            this.OnProjectPagesGetByLastScanDatesDefaultParams(ref LastScanDate);

            var items = this.context.ProjectPagesGetByLastScanDates.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByLastScanDate] @LastScanDate={0}", LastScanDate).ToList().AsQueryable();

            this.OnProjectPagesGetByLastScanDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByLastScanDatesDefaultParams(ref string LastScanDate);

        partial void OnProjectPagesGetByLastScanDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByLastScanDate> items);
    }
}
