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
    public partial class ProjectTablesGetByColumnsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByColumnsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByColumnsFunc(Columns={Columns})")]
        public IActionResult ProjectTablesGetByColumnsFunc([FromODataUri] string Columns)
        {
            this.OnProjectTablesGetByColumnsDefaultParams(ref Columns);

            var items = this.context.ProjectTablesGetByColumns.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByColumns] @Columns={0}", Columns).ToList().AsQueryable();

            this.OnProjectTablesGetByColumnsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByColumnsDefaultParams(ref string Columns);

        partial void OnProjectTablesGetByColumnsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByColumn> items);
    }
}
