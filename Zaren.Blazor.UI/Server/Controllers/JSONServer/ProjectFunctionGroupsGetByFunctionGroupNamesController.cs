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
    public partial class ProjectFunctionGroupsGetByFunctionGroupNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionGroupsGetByFunctionGroupNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionGroupsGetByFunctionGroupNamesFunc(FunctionGroupName={FunctionGroupName})")]
        public IActionResult ProjectFunctionGroupsGetByFunctionGroupNamesFunc([FromODataUri] string FunctionGroupName)
        {
            this.OnProjectFunctionGroupsGetByFunctionGroupNamesDefaultParams(ref FunctionGroupName);

            var items = this.context.ProjectFunctionGroupsGetByFunctionGroupNames.FromSqlRaw("EXEC [dbo].[ProjectFunctionGroupsGetByFunctionGroupName] @FunctionGroupName={0}", FunctionGroupName).ToList().AsQueryable();

            this.OnProjectFunctionGroupsGetByFunctionGroupNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionGroupsGetByFunctionGroupNamesDefaultParams(ref string FunctionGroupName);

        partial void OnProjectFunctionGroupsGetByFunctionGroupNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetByFunctionGroupName> items);
    }
}
