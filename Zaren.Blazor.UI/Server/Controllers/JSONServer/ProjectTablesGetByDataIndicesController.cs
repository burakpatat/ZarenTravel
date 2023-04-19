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
    public partial class ProjectTablesGetByDataIndicesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByDataIndicesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByDataIndicesFunc(DataIndex={DataIndex})")]
        public IActionResult ProjectTablesGetByDataIndicesFunc([FromODataUri] string DataIndex)
        {
            this.OnProjectTablesGetByDataIndicesDefaultParams(ref DataIndex);

            var items = this.context.ProjectTablesGetByDataIndices.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByDataIndex] @DataIndex={0}", DataIndex).ToList().AsQueryable();

            this.OnProjectTablesGetByDataIndicesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByDataIndicesDefaultParams(ref string DataIndex);

        partial void OnProjectTablesGetByDataIndicesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByDataIndex> items);
    }
}
