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
    public partial class ProjectFunctionsGetByFunctionCallRankInGroupsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByFunctionCallRankInGroupsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByFunctionCallRankInGroupsFunc(FunctionCallRankInGroup={FunctionCallRankInGroup})")]
        public IActionResult ProjectFunctionsGetByFunctionCallRankInGroupsFunc([FromODataUri] int? FunctionCallRankInGroup)
        {
            this.OnProjectFunctionsGetByFunctionCallRankInGroupsDefaultParams(ref FunctionCallRankInGroup);

            var items = this.context.ProjectFunctionsGetByFunctionCallRankInGroups.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByFunctionCallRankInGroup] @FunctionCallRankInGroup={0}", FunctionCallRankInGroup).ToList().AsQueryable();

            this.OnProjectFunctionsGetByFunctionCallRankInGroupsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByFunctionCallRankInGroupsDefaultParams(ref int? FunctionCallRankInGroup);

        partial void OnProjectFunctionsGetByFunctionCallRankInGroupsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByFunctionCallRankInGroup> items);
    }
}
