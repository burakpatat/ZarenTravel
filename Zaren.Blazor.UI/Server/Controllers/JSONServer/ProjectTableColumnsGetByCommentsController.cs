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
    public partial class ProjectTableColumnsGetByCommentsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByCommentsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByCommentsFunc(Comment={Comment})")]
        public IActionResult ProjectTableColumnsGetByCommentsFunc([FromODataUri] string Comment)
        {
            this.OnProjectTableColumnsGetByCommentsDefaultParams(ref Comment);

            var items = this.context.ProjectTableColumnsGetByComments.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByComment] @Comment={0}", Comment).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByCommentsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByCommentsDefaultParams(ref string Comment);

        partial void OnProjectTableColumnsGetByCommentsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByComment> items);
    }
}
