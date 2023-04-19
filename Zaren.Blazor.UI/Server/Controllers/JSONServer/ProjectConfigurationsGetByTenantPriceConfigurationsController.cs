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
    public partial class ProjectConfigurationsGetByTenantPriceConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByTenantPriceConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByTenantPriceConfigurationsFunc(TenantPriceConfiguration={TenantPriceConfiguration})")]
        public IActionResult ProjectConfigurationsGetByTenantPriceConfigurationsFunc([FromODataUri] string TenantPriceConfiguration)
        {
            this.OnProjectConfigurationsGetByTenantPriceConfigurationsDefaultParams(ref TenantPriceConfiguration);

            var items = this.context.ProjectConfigurationsGetByTenantPriceConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByTenantPriceConfiguration] @TenantPriceConfiguration={0}", TenantPriceConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByTenantPriceConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByTenantPriceConfigurationsDefaultParams(ref string TenantPriceConfiguration);

        partial void OnProjectConfigurationsGetByTenantPriceConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTenantPriceConfiguration> items);
    }
}
