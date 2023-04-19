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
    public partial class ProjectConfigurationsGetByDataBaseConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByDataBaseConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByDataBaseConfigurationsFunc(DataBaseConfiguration={DataBaseConfiguration})")]
        public IActionResult ProjectConfigurationsGetByDataBaseConfigurationsFunc([FromODataUri] string DataBaseConfiguration)
        {
            this.OnProjectConfigurationsGetByDataBaseConfigurationsDefaultParams(ref DataBaseConfiguration);

            var items = this.context.ProjectConfigurationsGetByDataBaseConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByDataBaseConfiguration] @DataBaseConfiguration={0}", DataBaseConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByDataBaseConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByDataBaseConfigurationsDefaultParams(ref string DataBaseConfiguration);

        partial void OnProjectConfigurationsGetByDataBaseConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDataBaseConfiguration> items);
    }
}
