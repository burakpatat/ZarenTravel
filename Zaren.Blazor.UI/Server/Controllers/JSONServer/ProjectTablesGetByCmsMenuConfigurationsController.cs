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
    public partial class ProjectTablesGetByCmsMenuConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByCmsMenuConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByCmsMenuConfigurationsFunc(CMSMenuConfiguration={CMSMenuConfiguration})")]
        public IActionResult ProjectTablesGetByCmsMenuConfigurationsFunc([FromODataUri] string CMSMenuConfiguration)
        {
            this.OnProjectTablesGetByCmsMenuConfigurationsDefaultParams(ref CMSMenuConfiguration);

            var items = this.context.ProjectTablesGetByCmsMenuConfigurations.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByCMSMenuConfiguration] @CMSMenuConfiguration={0}", CMSMenuConfiguration).ToList().AsQueryable();

            this.OnProjectTablesGetByCmsMenuConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByCmsMenuConfigurationsDefaultParams(ref string CMSMenuConfiguration);

        partial void OnProjectTablesGetByCmsMenuConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCmsMenuConfiguration> items);
    }
}
