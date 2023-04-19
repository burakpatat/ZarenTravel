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
    public partial class ProjectTableColumnsGetByTableIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByTableIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByTableIdsFunc(TableId={TableId})")]
        public IActionResult ProjectTableColumnsGetByTableIdsFunc([FromODataUri] int? TableId)
        {
            this.OnProjectTableColumnsGetByTableIdsDefaultParams(ref TableId);

            var items = this.context.ProjectTableColumnsGetByTableIds.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByTableId] @TableId={0}", TableId).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByTableIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByTableIdsDefaultParams(ref int? TableId);

        partial void OnProjectTableColumnsGetByTableIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByTableId> items);
    }
}