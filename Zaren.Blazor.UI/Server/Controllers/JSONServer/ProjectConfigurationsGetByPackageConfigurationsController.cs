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
    public partial class ProjectConfigurationsGetByPackageConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByPackageConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByPackageConfigurationsFunc(PackageConfiguration={PackageConfiguration})")]
        public IActionResult ProjectConfigurationsGetByPackageConfigurationsFunc([FromODataUri] string PackageConfiguration)
        {
            this.OnProjectConfigurationsGetByPackageConfigurationsDefaultParams(ref PackageConfiguration);

            var items = this.context.ProjectConfigurationsGetByPackageConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByPackageConfiguration] @PackageConfiguration={0}", PackageConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByPackageConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByPackageConfigurationsDefaultParams(ref string PackageConfiguration);

        partial void OnProjectConfigurationsGetByPackageConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByPackageConfiguration> items);
    }
}
