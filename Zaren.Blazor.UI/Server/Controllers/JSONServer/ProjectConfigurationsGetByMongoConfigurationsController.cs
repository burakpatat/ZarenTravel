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
    public partial class ProjectConfigurationsGetByMongoConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByMongoConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByMongoConfigurationsFunc(MongoConfiguration={MongoConfiguration})")]
        public IActionResult ProjectConfigurationsGetByMongoConfigurationsFunc([FromODataUri] string MongoConfiguration)
        {
            this.OnProjectConfigurationsGetByMongoConfigurationsDefaultParams(ref MongoConfiguration);

            var items = this.context.ProjectConfigurationsGetByMongoConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByMongoConfiguration] @MongoConfiguration={0}", MongoConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByMongoConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByMongoConfigurationsDefaultParams(ref string MongoConfiguration);

        partial void OnProjectConfigurationsGetByMongoConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByMongoConfiguration> items);
    }
}
