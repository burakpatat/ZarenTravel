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
    public partial class ProjectFunctionsGetLastScanDateBetweensController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetLastScanDateBetweensController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetLastScanDateBetweensFunc(LastScanDateStart={LastScanDateStart},LastScanDateEnd={LastScanDateEnd})")]
        public IActionResult ProjectFunctionsGetLastScanDateBetweensFunc([FromODataUri] string LastScanDateStart, [FromODataUri] string LastScanDateEnd)
        {
            this.OnProjectFunctionsGetLastScanDateBetweensDefaultParams(ref LastScanDateStart, ref LastScanDateEnd);

            var items = this.context.ProjectFunctionsGetLastScanDateBetweens.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetLastScanDateBetween] @LastScanDateStart={0}, @LastScanDateEnd={1}", LastScanDateStart, LastScanDateEnd).ToList().AsQueryable();

            this.OnProjectFunctionsGetLastScanDateBetweensInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetLastScanDateBetweensDefaultParams(ref string LastScanDateStart, ref string LastScanDateEnd);

        partial void OnProjectFunctionsGetLastScanDateBetweensInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetLastScanDateBetween> items);
    }
}
