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
    public partial class ProjectTablesGetByUniqueColumnsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByUniqueColumnsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByUniqueColumnsFunc(UniqueColumns={UniqueColumns})")]
        public IActionResult ProjectTablesGetByUniqueColumnsFunc([FromODataUri] string UniqueColumns)
        {
            this.OnProjectTablesGetByUniqueColumnsDefaultParams(ref UniqueColumns);

            var items = this.context.ProjectTablesGetByUniqueColumns.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByUniqueColumns] @UniqueColumns={0}", UniqueColumns).ToList().AsQueryable();

            this.OnProjectTablesGetByUniqueColumnsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByUniqueColumnsDefaultParams(ref string UniqueColumns);

        partial void OnProjectTablesGetByUniqueColumnsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByUniqueColumn> items);
    }
}
