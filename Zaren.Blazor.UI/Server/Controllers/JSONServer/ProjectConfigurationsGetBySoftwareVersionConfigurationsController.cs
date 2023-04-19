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
    public partial class ProjectConfigurationsGetBySoftwareVersionConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetBySoftwareVersionConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetBySoftwareVersionConfigurationsFunc(SoftwareVersionConfiguration={SoftwareVersionConfiguration})")]
        public IActionResult ProjectConfigurationsGetBySoftwareVersionConfigurationsFunc([FromODataUri] string SoftwareVersionConfiguration)
        {
            this.OnProjectConfigurationsGetBySoftwareVersionConfigurationsDefaultParams(ref SoftwareVersionConfiguration);

            var items = this.context.ProjectConfigurationsGetBySoftwareVersionConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetBySoftwareVersionConfiguration] @SoftwareVersionConfiguration={0}", SoftwareVersionConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetBySoftwareVersionConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetBySoftwareVersionConfigurationsDefaultParams(ref string SoftwareVersionConfiguration);

        partial void OnProjectConfigurationsGetBySoftwareVersionConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetBySoftwareVersionConfiguration> items);
    }
}
