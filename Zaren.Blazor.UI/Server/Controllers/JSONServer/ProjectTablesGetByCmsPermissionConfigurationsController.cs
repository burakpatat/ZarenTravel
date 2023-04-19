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
    public partial class ProjectTablesGetByCmsPermissionConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByCmsPermissionConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByCmsPermissionConfigurationsFunc(CMSPermissionConfiguration={CMSPermissionConfiguration})")]
        public IActionResult ProjectTablesGetByCmsPermissionConfigurationsFunc([FromODataUri] string CMSPermissionConfiguration)
        {
            this.OnProjectTablesGetByCmsPermissionConfigurationsDefaultParams(ref CMSPermissionConfiguration);

            var items = this.context.ProjectTablesGetByCmsPermissionConfigurations.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByCMSPermissionConfiguration] @CMSPermissionConfiguration={0}", CMSPermissionConfiguration).ToList().AsQueryable();

            this.OnProjectTablesGetByCmsPermissionConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByCmsPermissionConfigurationsDefaultParams(ref string CMSPermissionConfiguration);

        partial void OnProjectTablesGetByCmsPermissionConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCmsPermissionConfiguration> items);
    }
}
