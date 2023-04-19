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
    public partial class ProjectConfigurationsGetByWindowsServiceConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByWindowsServiceConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByWindowsServiceConfigurationsFunc(WindowsServiceConfiguration={WindowsServiceConfiguration})")]
        public IActionResult ProjectConfigurationsGetByWindowsServiceConfigurationsFunc([FromODataUri] string WindowsServiceConfiguration)
        {
            this.OnProjectConfigurationsGetByWindowsServiceConfigurationsDefaultParams(ref WindowsServiceConfiguration);

            var items = this.context.ProjectConfigurationsGetByWindowsServiceConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByWindowsServiceConfiguration] @WindowsServiceConfiguration={0}", WindowsServiceConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByWindowsServiceConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByWindowsServiceConfigurationsDefaultParams(ref string WindowsServiceConfiguration);

        partial void OnProjectConfigurationsGetByWindowsServiceConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByWindowsServiceConfiguration> items);
    }
}
