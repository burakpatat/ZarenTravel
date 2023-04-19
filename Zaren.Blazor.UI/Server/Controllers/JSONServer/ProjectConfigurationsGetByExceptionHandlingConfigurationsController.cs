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
    public partial class ProjectConfigurationsGetByExceptionHandlingConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByExceptionHandlingConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByExceptionHandlingConfigurationsFunc(ExceptionHandlingConfiguration={ExceptionHandlingConfiguration})")]
        public IActionResult ProjectConfigurationsGetByExceptionHandlingConfigurationsFunc([FromODataUri] string ExceptionHandlingConfiguration)
        {
            this.OnProjectConfigurationsGetByExceptionHandlingConfigurationsDefaultParams(ref ExceptionHandlingConfiguration);

            var items = this.context.ProjectConfigurationsGetByExceptionHandlingConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByExceptionHandlingConfiguration] @ExceptionHandlingConfiguration={0}", ExceptionHandlingConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByExceptionHandlingConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByExceptionHandlingConfigurationsDefaultParams(ref string ExceptionHandlingConfiguration);

        partial void OnProjectConfigurationsGetByExceptionHandlingConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByExceptionHandlingConfiguration> items);
    }
}
