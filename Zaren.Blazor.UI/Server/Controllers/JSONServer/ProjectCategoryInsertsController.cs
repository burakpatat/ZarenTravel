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
    public partial class ProjectCategoryInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectCategoryInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectCategoryInsertsFunc(CategoryName={CategoryName},ParentId={ParentId},SampleUrl={SampleUrl},CategoryNameTr={CategoryNameTr})")]
        public IActionResult ProjectCategoryInsertsFunc([FromODataUri] string CategoryName, [FromODataUri] int? ParentId, [FromODataUri] string SampleUrl, [FromODataUri] string CategoryNameTr)
        {
            this.OnProjectCategoryInsertsDefaultParams(ref CategoryName, ref ParentId, ref SampleUrl, ref CategoryNameTr);

            var items = this.context.ProjectCategoryInserts.FromSqlRaw("EXEC [dbo].[ProjectCategoryInsert] @CategoryName={0}, @ParentId={1}, @SampleUrl={2}, @CategoryNameTr={3}", CategoryName, ParentId, SampleUrl, CategoryNameTr).ToList().AsQueryable();

            this.OnProjectCategoryInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectCategoryInsertsDefaultParams(ref string CategoryName, ref int? ParentId, ref string SampleUrl, ref string CategoryNameTr);

        partial void OnProjectCategoryInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectCategoryInsert> items);
    }
}
