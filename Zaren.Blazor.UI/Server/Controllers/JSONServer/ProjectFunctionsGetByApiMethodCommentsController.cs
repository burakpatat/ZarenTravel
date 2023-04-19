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
    public partial class ProjectFunctionsGetByApiMethodCommentsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByApiMethodCommentsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByApiMethodCommentsFunc(ApiMethodComment={ApiMethodComment})")]
        public IActionResult ProjectFunctionsGetByApiMethodCommentsFunc([FromODataUri] string ApiMethodComment)
        {
            this.OnProjectFunctionsGetByApiMethodCommentsDefaultParams(ref ApiMethodComment);

            var items = this.context.ProjectFunctionsGetByApiMethodComments.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByApiMethodComment] @ApiMethodComment={0}", ApiMethodComment).ToList().AsQueryable();

            this.OnProjectFunctionsGetByApiMethodCommentsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByApiMethodCommentsDefaultParams(ref string ApiMethodComment);

        partial void OnProjectFunctionsGetByApiMethodCommentsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByApiMethodComment> items);
    }
}
