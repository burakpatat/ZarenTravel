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
    public partial class ProjectPageComponentElementsGetByCommentsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByCommentsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByCommentsFunc(Comment={Comment})")]
        public IActionResult ProjectPageComponentElementsGetByCommentsFunc([FromODataUri] string Comment)
        {
            this.OnProjectPageComponentElementsGetByCommentsDefaultParams(ref Comment);

            var items = this.context.ProjectPageComponentElementsGetByComments.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByComment] @Comment={0}", Comment).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByCommentsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByCommentsDefaultParams(ref string Comment);

        partial void OnProjectPageComponentElementsGetByCommentsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByComment> items);
    }
}
