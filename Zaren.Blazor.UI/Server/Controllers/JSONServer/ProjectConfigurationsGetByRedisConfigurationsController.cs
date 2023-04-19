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
    public partial class ProjectConfigurationsGetByRedisConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByRedisConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByRedisConfigurationsFunc(RedisConfiguration={RedisConfiguration})")]
        public IActionResult ProjectConfigurationsGetByRedisConfigurationsFunc([FromODataUri] string RedisConfiguration)
        {
            this.OnProjectConfigurationsGetByRedisConfigurationsDefaultParams(ref RedisConfiguration);

            var items = this.context.ProjectConfigurationsGetByRedisConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByRedisConfiguration] @RedisConfiguration={0}", RedisConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByRedisConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByRedisConfigurationsDefaultParams(ref string RedisConfiguration);

        partial void OnProjectConfigurationsGetByRedisConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByRedisConfiguration> items);
    }
}
