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
    public partial class ProjectConfigurationsGetByConfigurationJsonSchemesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByConfigurationJsonSchemesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByConfigurationJsonSchemesFunc(ConfigurationJsonScheme={ConfigurationJsonScheme})")]
        public IActionResult ProjectConfigurationsGetByConfigurationJsonSchemesFunc([FromODataUri] string ConfigurationJsonScheme)
        {
            this.OnProjectConfigurationsGetByConfigurationJsonSchemesDefaultParams(ref ConfigurationJsonScheme);

            var items = this.context.ProjectConfigurationsGetByConfigurationJsonSchemes.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByConfigurationJsonScheme] @ConfigurationJsonScheme={0}", ConfigurationJsonScheme).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByConfigurationJsonSchemesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByConfigurationJsonSchemesDefaultParams(ref string ConfigurationJsonScheme);

        partial void OnProjectConfigurationsGetByConfigurationJsonSchemesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByConfigurationJsonScheme> items);
    }
}
