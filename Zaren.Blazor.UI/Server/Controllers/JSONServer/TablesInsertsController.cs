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
    public partial class TablesInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public TablesInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/TablesInsertsFunc(ProjectId={ProjectId},TableName={TableName},Config={Config})")]
        public IActionResult TablesInsertsFunc([FromODataUri] long? ProjectId, [FromODataUri] string TableName, [FromODataUri] string Config)
        {
            this.OnTablesInsertsDefaultParams(ref ProjectId, ref TableName, ref Config);

            var items = this.context.TablesInserts.FromSqlRaw("EXEC [dbo].[TablesInsert] @ProjectId={0}, @TableName={1}, @Config={2}", ProjectId, TableName, Config).ToList().AsQueryable();

            this.OnTablesInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnTablesInsertsDefaultParams(ref long? ProjectId, ref string TableName, ref string Config);

        partial void OnTablesInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.TablesInsert> items);
    }
}
