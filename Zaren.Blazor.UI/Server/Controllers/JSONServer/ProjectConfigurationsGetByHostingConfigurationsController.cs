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
    public partial class ProjectConfigurationsGetByHostingConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByHostingConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByHostingConfigurationsFunc(HostingConfiguration={HostingConfiguration})")]
        public IActionResult ProjectConfigurationsGetByHostingConfigurationsFunc([FromODataUri] string HostingConfiguration)
        {
            this.OnProjectConfigurationsGetByHostingConfigurationsDefaultParams(ref HostingConfiguration);

            var items = this.context.ProjectConfigurationsGetByHostingConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByHostingConfiguration] @HostingConfiguration={0}", HostingConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByHostingConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByHostingConfigurationsDefaultParams(ref string HostingConfiguration);

        partial void OnProjectConfigurationsGetByHostingConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByHostingConfiguration> items);
    }
}
