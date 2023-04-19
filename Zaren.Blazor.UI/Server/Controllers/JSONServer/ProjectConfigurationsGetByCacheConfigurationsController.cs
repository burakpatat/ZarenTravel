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
    public partial class ProjectConfigurationsGetByCacheConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByCacheConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByCacheConfigurationsFunc(CacheConfiguration={CacheConfiguration})")]
        public IActionResult ProjectConfigurationsGetByCacheConfigurationsFunc([FromODataUri] string CacheConfiguration)
        {
            this.OnProjectConfigurationsGetByCacheConfigurationsDefaultParams(ref CacheConfiguration);

            var items = this.context.ProjectConfigurationsGetByCacheConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByCacheConfiguration] @CacheConfiguration={0}", CacheConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByCacheConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByCacheConfigurationsDefaultParams(ref string CacheConfiguration);

        partial void OnProjectConfigurationsGetByCacheConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByCacheConfiguration> items);
    }
}
