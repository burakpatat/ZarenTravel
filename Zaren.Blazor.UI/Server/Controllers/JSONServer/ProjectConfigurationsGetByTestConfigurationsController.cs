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
    public partial class ProjectConfigurationsGetByTestConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByTestConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByTestConfigurationsFunc(TestConfiguration={TestConfiguration})")]
        public IActionResult ProjectConfigurationsGetByTestConfigurationsFunc([FromODataUri] string TestConfiguration)
        {
            this.OnProjectConfigurationsGetByTestConfigurationsDefaultParams(ref TestConfiguration);

            var items = this.context.ProjectConfigurationsGetByTestConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByTestConfiguration] @TestConfiguration={0}", TestConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByTestConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByTestConfigurationsDefaultParams(ref string TestConfiguration);

        partial void OnProjectConfigurationsGetByTestConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTestConfiguration> items);
    }
}
