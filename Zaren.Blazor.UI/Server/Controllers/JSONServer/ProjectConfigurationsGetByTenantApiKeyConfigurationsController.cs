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
    public partial class ProjectConfigurationsGetByTenantApiKeyConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByTenantApiKeyConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByTenantApiKeyConfigurationsFunc(TenantApiKeyConfiguration={TenantApiKeyConfiguration})")]
        public IActionResult ProjectConfigurationsGetByTenantApiKeyConfigurationsFunc([FromODataUri] string TenantApiKeyConfiguration)
        {
            this.OnProjectConfigurationsGetByTenantApiKeyConfigurationsDefaultParams(ref TenantApiKeyConfiguration);

            var items = this.context.ProjectConfigurationsGetByTenantApiKeyConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByTenantApiKeyConfiguration] @TenantApiKeyConfiguration={0}", TenantApiKeyConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByTenantApiKeyConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByTenantApiKeyConfigurationsDefaultParams(ref string TenantApiKeyConfiguration);

        partial void OnProjectConfigurationsGetByTenantApiKeyConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTenantApiKeyConfiguration> items);
    }
}
