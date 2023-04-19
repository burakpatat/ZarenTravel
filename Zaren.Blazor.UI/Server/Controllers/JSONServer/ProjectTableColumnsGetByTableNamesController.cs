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
    public partial class ProjectTableColumnsGetByTableNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByTableNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByTableNamesFunc(TableName={TableName})")]
        public IActionResult ProjectTableColumnsGetByTableNamesFunc([FromODataUri] string TableName)
        {
            this.OnProjectTableColumnsGetByTableNamesDefaultParams(ref TableName);

            var items = this.context.ProjectTableColumnsGetByTableNames.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByTableName] @TableName={0}", TableName).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByTableNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByTableNamesDefaultParams(ref string TableName);

        partial void OnProjectTableColumnsGetByTableNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByTableName> items);
    }
}
