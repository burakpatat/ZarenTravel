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
    public partial class ProjectTableColumnsGetByColumnNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByColumnNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByColumnNamesFunc(ColumnName={ColumnName})")]
        public IActionResult ProjectTableColumnsGetByColumnNamesFunc([FromODataUri] string ColumnName)
        {
            this.OnProjectTableColumnsGetByColumnNamesDefaultParams(ref ColumnName);

            var items = this.context.ProjectTableColumnsGetByColumnNames.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByColumnName] @ColumnName={0}", ColumnName).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByColumnNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByColumnNamesDefaultParams(ref string ColumnName);

        partial void OnProjectTableColumnsGetByColumnNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByColumnName> items);
    }
}
