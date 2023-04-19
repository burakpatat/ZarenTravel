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
    public partial class ProjectPageComponentsGetLastScanDateBetweensController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetLastScanDateBetweensController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetLastScanDateBetweensFunc(LastScanDateStart={LastScanDateStart},LastScanDateEnd={LastScanDateEnd})")]
        public IActionResult ProjectPageComponentsGetLastScanDateBetweensFunc([FromODataUri] string LastScanDateStart, [FromODataUri] string LastScanDateEnd)
        {
            this.OnProjectPageComponentsGetLastScanDateBetweensDefaultParams(ref LastScanDateStart, ref LastScanDateEnd);

            var items = this.context.ProjectPageComponentsGetLastScanDateBetweens.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetLastScanDateBetween] @LastScanDateStart={0}, @LastScanDateEnd={1}", LastScanDateStart, LastScanDateEnd).ToList().AsQueryable();

            this.OnProjectPageComponentsGetLastScanDateBetweensInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetLastScanDateBetweensDefaultParams(ref string LastScanDateStart, ref string LastScanDateEnd);

        partial void OnProjectPageComponentsGetLastScanDateBetweensInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetLastScanDateBetween> items);
    }
}
