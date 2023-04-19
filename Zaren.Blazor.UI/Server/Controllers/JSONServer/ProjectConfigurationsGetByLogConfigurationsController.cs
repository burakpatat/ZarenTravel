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
    public partial class ProjectConfigurationsGetByLogConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByLogConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByLogConfigurationsFunc(LogConfiguration={LogConfiguration})")]
        public IActionResult ProjectConfigurationsGetByLogConfigurationsFunc([FromODataUri] string LogConfiguration)
        {
            this.OnProjectConfigurationsGetByLogConfigurationsDefaultParams(ref LogConfiguration);

            var items = this.context.ProjectConfigurationsGetByLogConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByLogConfiguration] @LogConfiguration={0}", LogConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByLogConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByLogConfigurationsDefaultParams(ref string LogConfiguration);

        partial void OnProjectConfigurationsGetByLogConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByLogConfiguration> items);
    }
}
