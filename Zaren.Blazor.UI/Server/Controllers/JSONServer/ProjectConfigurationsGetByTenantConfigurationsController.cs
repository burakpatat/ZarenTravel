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
    public partial class ProjectConfigurationsGetByTenantConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByTenantConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByTenantConfigurationsFunc(TenantConfiguration={TenantConfiguration})")]
        public IActionResult ProjectConfigurationsGetByTenantConfigurationsFunc([FromODataUri] string TenantConfiguration)
        {
            this.OnProjectConfigurationsGetByTenantConfigurationsDefaultParams(ref TenantConfiguration);

            var items = this.context.ProjectConfigurationsGetByTenantConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByTenantConfiguration] @TenantConfiguration={0}", TenantConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByTenantConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByTenantConfigurationsDefaultParams(ref string TenantConfiguration);

        partial void OnProjectConfigurationsGetByTenantConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTenantConfiguration> items);
    }
}
