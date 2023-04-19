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
    public partial class ProjectCategoryGetByCategoryNameTrsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectCategoryGetByCategoryNameTrsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectCategoryGetByCategoryNameTrsFunc(CategoryNameTr={CategoryNameTr})")]
        public IActionResult ProjectCategoryGetByCategoryNameTrsFunc([FromODataUri] string CategoryNameTr)
        {
            this.OnProjectCategoryGetByCategoryNameTrsDefaultParams(ref CategoryNameTr);

            var items = this.context.ProjectCategoryGetByCategoryNameTrs.FromSqlRaw("EXEC [dbo].[ProjectCategoryGetByCategoryNameTr] @CategoryNameTr={0}", CategoryNameTr).ToList().AsQueryable();

            this.OnProjectCategoryGetByCategoryNameTrsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectCategoryGetByCategoryNameTrsDefaultParams(ref string CategoryNameTr);

        partial void OnProjectCategoryGetByCategoryNameTrsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectCategoryGetByCategoryNameTr> items);
    }
}
