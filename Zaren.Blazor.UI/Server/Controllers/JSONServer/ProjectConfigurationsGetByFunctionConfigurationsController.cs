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
    public partial class ProjectConfigurationsGetByFunctionConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByFunctionConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByFunctionConfigurationsFunc(FunctionConfiguration={FunctionConfiguration})")]
        public IActionResult ProjectConfigurationsGetByFunctionConfigurationsFunc([FromODataUri] string FunctionConfiguration)
        {
            this.OnProjectConfigurationsGetByFunctionConfigurationsDefaultParams(ref FunctionConfiguration);

            var items = this.context.ProjectConfigurationsGetByFunctionConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByFunctionConfiguration] @FunctionConfiguration={0}", FunctionConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByFunctionConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByFunctionConfigurationsDefaultParams(ref string FunctionConfiguration);

        partial void OnProjectConfigurationsGetByFunctionConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByFunctionConfiguration> items);
    }
}
