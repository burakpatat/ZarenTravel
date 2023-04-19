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
    public partial class ProjectConfigurationsGetByBootStrapConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByBootStrapConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByBootStrapConfigurationsFunc(BootStrapConfiguration={BootStrapConfiguration})")]
        public IActionResult ProjectConfigurationsGetByBootStrapConfigurationsFunc([FromODataUri] string BootStrapConfiguration)
        {
            this.OnProjectConfigurationsGetByBootStrapConfigurationsDefaultParams(ref BootStrapConfiguration);

            var items = this.context.ProjectConfigurationsGetByBootStrapConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByBootStrapConfiguration] @BootStrapConfiguration={0}", BootStrapConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByBootStrapConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByBootStrapConfigurationsDefaultParams(ref string BootStrapConfiguration);

        partial void OnProjectConfigurationsGetByBootStrapConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByBootStrapConfiguration> items);
    }
}
