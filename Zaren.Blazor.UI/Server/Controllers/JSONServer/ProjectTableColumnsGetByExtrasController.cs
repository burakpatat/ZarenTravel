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
    public partial class ProjectTableColumnsGetByExtrasController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByExtrasController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByExtrasFunc(Extra={Extra})")]
        public IActionResult ProjectTableColumnsGetByExtrasFunc([FromODataUri] string Extra)
        {
            this.OnProjectTableColumnsGetByExtrasDefaultParams(ref Extra);

            var items = this.context.ProjectTableColumnsGetByExtras.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByExtra] @Extra={0}", Extra).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByExtrasInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByExtrasDefaultParams(ref string Extra);

        partial void OnProjectTableColumnsGetByExtrasInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByExtra> items);
    }
}
