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
    public partial class ProjectConfigurationsGetByCssConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByCssConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByCssConfigurationsFunc(CssConfiguration={CssConfiguration})")]
        public IActionResult ProjectConfigurationsGetByCssConfigurationsFunc([FromODataUri] string CssConfiguration)
        {
            this.OnProjectConfigurationsGetByCssConfigurationsDefaultParams(ref CssConfiguration);

            var items = this.context.ProjectConfigurationsGetByCssConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByCssConfiguration] @CssConfiguration={0}", CssConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByCssConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByCssConfigurationsDefaultParams(ref string CssConfiguration);

        partial void OnProjectConfigurationsGetByCssConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByCssConfiguration> items);
    }
}
