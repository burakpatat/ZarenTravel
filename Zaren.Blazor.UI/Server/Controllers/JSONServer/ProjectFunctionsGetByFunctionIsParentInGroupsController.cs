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
    public partial class ProjectFunctionsGetByFunctionIsParentInGroupsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByFunctionIsParentInGroupsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByFunctionIsParentInGroupsFunc(FunctionIsParentInGroup={FunctionIsParentInGroup})")]
        public IActionResult ProjectFunctionsGetByFunctionIsParentInGroupsFunc([FromODataUri] bool? FunctionIsParentInGroup)
        {
            this.OnProjectFunctionsGetByFunctionIsParentInGroupsDefaultParams(ref FunctionIsParentInGroup);

            var items = this.context.ProjectFunctionsGetByFunctionIsParentInGroups.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByFunctionIsParentInGroup] @FunctionIsParentInGroup={0}", FunctionIsParentInGroup).ToList().AsQueryable();

            this.OnProjectFunctionsGetByFunctionIsParentInGroupsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByFunctionIsParentInGroupsDefaultParams(ref bool? FunctionIsParentInGroup);

        partial void OnProjectFunctionsGetByFunctionIsParentInGroupsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByFunctionIsParentInGroup> items);
    }
}
