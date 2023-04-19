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
    public partial class ProjectConfigurationsGetByAngularConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByAngularConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByAngularConfigurationsFunc(AngularConfiguration={AngularConfiguration})")]
        public IActionResult ProjectConfigurationsGetByAngularConfigurationsFunc([FromODataUri] string AngularConfiguration)
        {
            this.OnProjectConfigurationsGetByAngularConfigurationsDefaultParams(ref AngularConfiguration);

            var items = this.context.ProjectConfigurationsGetByAngularConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByAngularConfiguration] @AngularConfiguration={0}", AngularConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByAngularConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByAngularConfigurationsDefaultParams(ref string AngularConfiguration);

        partial void OnProjectConfigurationsGetByAngularConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByAngularConfiguration> items);
    }
}
