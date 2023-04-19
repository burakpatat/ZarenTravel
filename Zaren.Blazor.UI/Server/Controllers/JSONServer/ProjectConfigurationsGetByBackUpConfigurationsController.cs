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
    public partial class ProjectConfigurationsGetByBackUpConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByBackUpConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByBackUpConfigurationsFunc(BackUpConfiguration={BackUpConfiguration})")]
        public IActionResult ProjectConfigurationsGetByBackUpConfigurationsFunc([FromODataUri] string BackUpConfiguration)
        {
            this.OnProjectConfigurationsGetByBackUpConfigurationsDefaultParams(ref BackUpConfiguration);

            var items = this.context.ProjectConfigurationsGetByBackUpConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByBackUpConfiguration] @BackUpConfiguration={0}", BackUpConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByBackUpConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByBackUpConfigurationsDefaultParams(ref string BackUpConfiguration);

        partial void OnProjectConfigurationsGetByBackUpConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByBackUpConfiguration> items);
    }
}
