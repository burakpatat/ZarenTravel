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
    public partial class TablesUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public TablesUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/TablesUpdatesFunc(Id={Id},ProjectId={ProjectId},TableName={TableName},Config={Config})")]
        public IActionResult TablesUpdatesFunc([FromODataUri] long? Id, [FromODataUri] long? ProjectId, [FromODataUri] string TableName, [FromODataUri] string Config)
        {
            this.OnTablesUpdatesDefaultParams(ref Id, ref ProjectId, ref TableName, ref Config);

            var items = this.context.TablesUpdates.FromSqlRaw("EXEC [dbo].[TablesUpdate] @Id={0}, @ProjectId={1}, @TableName={2}, @Config={3}", Id, ProjectId, TableName, Config).ToList().AsQueryable();

            this.OnTablesUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnTablesUpdatesDefaultParams(ref long? Id, ref long? ProjectId, ref string TableName, ref string Config);

        partial void OnTablesUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.TablesUpdate> items);
    }
}
