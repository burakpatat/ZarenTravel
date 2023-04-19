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
    public partial class ProjectConfigurationsGetByTsConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByTsConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByTsConfigurationsFunc(TsConfiguration={TsConfiguration})")]
        public IActionResult ProjectConfigurationsGetByTsConfigurationsFunc([FromODataUri] string TsConfiguration)
        {
            this.OnProjectConfigurationsGetByTsConfigurationsDefaultParams(ref TsConfiguration);

            var items = this.context.ProjectConfigurationsGetByTsConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByTsConfiguration] @TsConfiguration={0}", TsConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByTsConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByTsConfigurationsDefaultParams(ref string TsConfiguration);

        partial void OnProjectConfigurationsGetByTsConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTsConfiguration> items);
    }
}
