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
    public partial class ProjectFunctionGroupsGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionGroupsGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionGroupsGetByIdsFunc(Id={Id})")]
        public IActionResult ProjectFunctionGroupsGetByIdsFunc([FromODataUri] int? Id)
        {
            this.OnProjectFunctionGroupsGetByIdsDefaultParams(ref Id);

            var items = this.context.ProjectFunctionGroupsGetByIds.FromSqlRaw("EXEC [dbo].[ProjectFunctionGroupsGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnProjectFunctionGroupsGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionGroupsGetByIdsDefaultParams(ref int? Id);

        partial void OnProjectFunctionGroupsGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetById> items);
    }
}
