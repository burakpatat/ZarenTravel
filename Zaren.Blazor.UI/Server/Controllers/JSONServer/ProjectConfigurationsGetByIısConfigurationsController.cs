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
    public partial class ProjectConfigurationsGetByIısConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByIısConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByIısConfigurationsFunc(IISConfiguration={IISConfiguration})")]
        public IActionResult ProjectConfigurationsGetByIısConfigurationsFunc([FromODataUri] string IISConfiguration)
        {
            this.OnProjectConfigurationsGetByIısConfigurationsDefaultParams(ref IISConfiguration);

            var items = this.context.ProjectConfigurationsGetByIısConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByIISConfiguration] @IISConfiguration={0}", IISConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByIısConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByIısConfigurationsDefaultParams(ref string IISConfiguration);

        partial void OnProjectConfigurationsGetByIısConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByIısConfiguration> items);
    }
}
