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
    public partial class ProjectTablesGetByTableNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByTableNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByTableNamesFunc(TableName={TableName})")]
        public IActionResult ProjectTablesGetByTableNamesFunc([FromODataUri] string TableName)
        {
            this.OnProjectTablesGetByTableNamesDefaultParams(ref TableName);

            var items = this.context.ProjectTablesGetByTableNames.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByTableName] @TableName={0}", TableName).ToList().AsQueryable();

            this.OnProjectTablesGetByTableNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByTableNamesDefaultParams(ref string TableName);

        partial void OnProjectTablesGetByTableNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByTableName> items);
    }
}
