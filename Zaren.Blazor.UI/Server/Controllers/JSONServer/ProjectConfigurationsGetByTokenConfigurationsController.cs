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
    public partial class ProjectConfigurationsGetByTokenConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByTokenConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByTokenConfigurationsFunc(TokenConfiguration={TokenConfiguration})")]
        public IActionResult ProjectConfigurationsGetByTokenConfigurationsFunc([FromODataUri] string TokenConfiguration)
        {
            this.OnProjectConfigurationsGetByTokenConfigurationsDefaultParams(ref TokenConfiguration);

            var items = this.context.ProjectConfigurationsGetByTokenConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByTokenConfiguration] @TokenConfiguration={0}", TokenConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByTokenConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByTokenConfigurationsDefaultParams(ref string TokenConfiguration);

        partial void OnProjectConfigurationsGetByTokenConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTokenConfiguration> items);
    }
}
