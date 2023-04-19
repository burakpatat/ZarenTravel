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
    public partial class ProjectCategoryGetAllsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectCategoryGetAllsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectCategoryGetAllsFunc()")]
        public IActionResult ProjectCategoryGetAllsFunc()
        {
            this.OnProjectCategoryGetAllsDefaultParams();

            var items = this.context.ProjectCategoryGetAlls.FromSqlRaw("EXEC [dbo].[ProjectCategoryGetAll] ").ToList().AsQueryable();

            this.OnProjectCategoryGetAllsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectCategoryGetAllsDefaultParams();

        partial void OnProjectCategoryGetAllsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectCategoryGetAll> items);
    }
}
