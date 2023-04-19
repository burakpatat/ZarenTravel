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
    public partial class ProjectConfigurationsGetByTenantWhiteListConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByTenantWhiteListConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByTenantWhiteListConfigurationsFunc(TenantWhiteListConfiguration={TenantWhiteListConfiguration})")]
        public IActionResult ProjectConfigurationsGetByTenantWhiteListConfigurationsFunc([FromODataUri] string TenantWhiteListConfiguration)
        {
            this.OnProjectConfigurationsGetByTenantWhiteListConfigurationsDefaultParams(ref TenantWhiteListConfiguration);

            var items = this.context.ProjectConfigurationsGetByTenantWhiteListConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByTenantWhiteListConfiguration] @TenantWhiteListConfiguration={0}", TenantWhiteListConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByTenantWhiteListConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByTenantWhiteListConfigurationsDefaultParams(ref string TenantWhiteListConfiguration);

        partial void OnProjectConfigurationsGetByTenantWhiteListConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTenantWhiteListConfiguration> items);
    }
}
