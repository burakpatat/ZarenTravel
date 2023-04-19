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
    public partial class ProjectConfigurationsGetByFileManagementConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByFileManagementConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByFileManagementConfigurationsFunc(FileManagementConfiguration={FileManagementConfiguration})")]
        public IActionResult ProjectConfigurationsGetByFileManagementConfigurationsFunc([FromODataUri] string FileManagementConfiguration)
        {
            this.OnProjectConfigurationsGetByFileManagementConfigurationsDefaultParams(ref FileManagementConfiguration);

            var items = this.context.ProjectConfigurationsGetByFileManagementConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByFileManagementConfiguration] @FileManagementConfiguration={0}", FileManagementConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByFileManagementConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByFileManagementConfigurationsDefaultParams(ref string FileManagementConfiguration);

        partial void OnProjectConfigurationsGetByFileManagementConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByFileManagementConfiguration> items);
    }
}
