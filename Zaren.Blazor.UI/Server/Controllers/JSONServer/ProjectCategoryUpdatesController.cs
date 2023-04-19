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
    public partial class ProjectCategoryUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectCategoryUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectCategoryUpdatesFunc(Id={Id},CategoryName={CategoryName},ParentId={ParentId},SampleUrl={SampleUrl},CategoryNameTr={CategoryNameTr})")]
        public IActionResult ProjectCategoryUpdatesFunc([FromODataUri] int? Id, [FromODataUri] string CategoryName, [FromODataUri] int? ParentId, [FromODataUri] string SampleUrl, [FromODataUri] string CategoryNameTr)
        {
            this.OnProjectCategoryUpdatesDefaultParams(ref Id, ref CategoryName, ref ParentId, ref SampleUrl, ref CategoryNameTr);

            var items = this.context.ProjectCategoryUpdates.FromSqlRaw("EXEC [dbo].[ProjectCategoryUpdate] @Id={0}, @CategoryName={1}, @ParentId={2}, @SampleUrl={3}, @CategoryNameTr={4}", Id, CategoryName, ParentId, SampleUrl, CategoryNameTr).ToList().AsQueryable();

            this.OnProjectCategoryUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectCategoryUpdatesDefaultParams(ref int? Id, ref string CategoryName, ref int? ParentId, ref string SampleUrl, ref string CategoryNameTr);

        partial void OnProjectCategoryUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectCategoryUpdate> items);
    }
}
