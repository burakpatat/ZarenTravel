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
    public partial class ProjectConfigurationsGetByWcfConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByWcfConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByWcfConfigurationsFunc(WCFConfiguration={WCFConfiguration})")]
        public IActionResult ProjectConfigurationsGetByWcfConfigurationsFunc([FromODataUri] string WCFConfiguration)
        {
            this.OnProjectConfigurationsGetByWcfConfigurationsDefaultParams(ref WCFConfiguration);

            var items = this.context.ProjectConfigurationsGetByWcfConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByWCFConfiguration] @WCFConfiguration={0}", WCFConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByWcfConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByWcfConfigurationsDefaultParams(ref string WCFConfiguration);

        partial void OnProjectConfigurationsGetByWcfConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByWcfConfiguration> items);
    }
}
