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
    public partial class ProjectConfigurationsGetByThemeConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByThemeConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByThemeConfigurationsFunc(ThemeConfiguration={ThemeConfiguration})")]
        public IActionResult ProjectConfigurationsGetByThemeConfigurationsFunc([FromODataUri] string ThemeConfiguration)
        {
            this.OnProjectConfigurationsGetByThemeConfigurationsDefaultParams(ref ThemeConfiguration);

            var items = this.context.ProjectConfigurationsGetByThemeConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByThemeConfiguration] @ThemeConfiguration={0}", ThemeConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByThemeConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByThemeConfigurationsDefaultParams(ref string ThemeConfiguration);

        partial void OnProjectConfigurationsGetByThemeConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByThemeConfiguration> items);
    }
}
