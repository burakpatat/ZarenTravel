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
    public partial class ProjectConfigurationsGetByDbJobConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByDbJobConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByDbJobConfigurationsFunc(DBJobConfiguration={DBJobConfiguration})")]
        public IActionResult ProjectConfigurationsGetByDbJobConfigurationsFunc([FromODataUri] string DBJobConfiguration)
        {
            this.OnProjectConfigurationsGetByDbJobConfigurationsDefaultParams(ref DBJobConfiguration);

            var items = this.context.ProjectConfigurationsGetByDbJobConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByDBJobConfiguration] @DBJobConfiguration={0}", DBJobConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByDbJobConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByDbJobConfigurationsDefaultParams(ref string DBJobConfiguration);

        partial void OnProjectConfigurationsGetByDbJobConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDbJobConfiguration> items);
    }
}
