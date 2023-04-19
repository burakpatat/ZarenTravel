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
    public partial class ProjectPagesGetLastScanDateBetweensController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetLastScanDateBetweensController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetLastScanDateBetweensFunc(LastScanDateStart={LastScanDateStart},LastScanDateEnd={LastScanDateEnd})")]
        public IActionResult ProjectPagesGetLastScanDateBetweensFunc([FromODataUri] string LastScanDateStart, [FromODataUri] string LastScanDateEnd)
        {
            this.OnProjectPagesGetLastScanDateBetweensDefaultParams(ref LastScanDateStart, ref LastScanDateEnd);

            var items = this.context.ProjectPagesGetLastScanDateBetweens.FromSqlRaw("EXEC [dbo].[ProjectPagesGetLastScanDateBetween] @LastScanDateStart={0}, @LastScanDateEnd={1}", LastScanDateStart, LastScanDateEnd).ToList().AsQueryable();

            this.OnProjectPagesGetLastScanDateBetweensInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetLastScanDateBetweensDefaultParams(ref string LastScanDateStart, ref string LastScanDateEnd);

        partial void OnProjectPagesGetLastScanDateBetweensInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetLastScanDateBetween> items);
    }
}
