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
    public partial class ProjectFunctionsGetByFunctionGroupIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByFunctionGroupIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByFunctionGroupIdsFunc(FunctionGroupId={FunctionGroupId})")]
        public IActionResult ProjectFunctionsGetByFunctionGroupIdsFunc([FromODataUri] int? FunctionGroupId)
        {
            this.OnProjectFunctionsGetByFunctionGroupIdsDefaultParams(ref FunctionGroupId);

            var items = this.context.ProjectFunctionsGetByFunctionGroupIds.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByFunctionGroupId] @FunctionGroupId={0}", FunctionGroupId).ToList().AsQueryable();

            this.OnProjectFunctionsGetByFunctionGroupIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByFunctionGroupIdsDefaultParams(ref int? FunctionGroupId);

        partial void OnProjectFunctionsGetByFunctionGroupIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByFunctionGroupId> items);
    }
}
