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
    public partial class ProjectTableColumnsGetByIsNullablesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByIsNullablesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByIsNullablesFunc(IsNullable={IsNullable})")]
        public IActionResult ProjectTableColumnsGetByIsNullablesFunc([FromODataUri] bool? IsNullable)
        {
            this.OnProjectTableColumnsGetByIsNullablesDefaultParams(ref IsNullable);

            var items = this.context.ProjectTableColumnsGetByIsNullables.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByIsNullable] @IsNullable={0}", IsNullable).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByIsNullablesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByIsNullablesDefaultParams(ref bool? IsNullable);

        partial void OnProjectTableColumnsGetByIsNullablesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByIsNullable> items);
    }
}
