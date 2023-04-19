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
    public partial class ProjectTablesGetByCmsRouteConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByCmsRouteConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByCmsRouteConfigurationsFunc(CMSRouteConfiguration={CMSRouteConfiguration})")]
        public IActionResult ProjectTablesGetByCmsRouteConfigurationsFunc([FromODataUri] string CMSRouteConfiguration)
        {
            this.OnProjectTablesGetByCmsRouteConfigurationsDefaultParams(ref CMSRouteConfiguration);

            var items = this.context.ProjectTablesGetByCmsRouteConfigurations.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByCMSRouteConfiguration] @CMSRouteConfiguration={0}", CMSRouteConfiguration).ToList().AsQueryable();

            this.OnProjectTablesGetByCmsRouteConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByCmsRouteConfigurationsDefaultParams(ref string CMSRouteConfiguration);

        partial void OnProjectTablesGetByCmsRouteConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCmsRouteConfiguration> items);
    }
}
