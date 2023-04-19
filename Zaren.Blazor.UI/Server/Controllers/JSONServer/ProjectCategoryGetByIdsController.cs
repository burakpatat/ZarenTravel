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
    public partial class ProjectCategoryGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectCategoryGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectCategoryGetByIdsFunc(Id={Id})")]
        public IActionResult ProjectCategoryGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnProjectCategoryGetByIdsDefaultParams(ref Id);

            var items = this.context.ProjectCategoryGetByIds.FromSqlRaw("EXEC [dbo].[ProjectCategoryGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnProjectCategoryGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectCategoryGetByIdsDefaultParams(ref int? Id);

        partial void OnProjectCategoryGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectCategoryGetById> items);
    }
}
