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
    public partial class ProjectCategoryGetByParentIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectCategoryGetByParentIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectCategoryGetByParentIdsFunc(ParentId={ParentId})")]
        public IActionResult ProjectCategoryGetByParentIdsFunc([FromODataUri] int? ParentId)
        {
            this.OnProjectCategoryGetByParentIdsDefaultParams(ref ParentId);

            var items = this.context.ProjectCategoryGetByParentIds.FromSqlRaw("EXEC [dbo].[ProjectCategoryGetByParentId] @ParentId={0}", ParentId).ToList().AsQueryable();

            this.OnProjectCategoryGetByParentIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectCategoryGetByParentIdsDefaultParams(ref int? ParentId);

        partial void OnProjectCategoryGetByParentIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectCategoryGetByParentId> items);
    }
}
