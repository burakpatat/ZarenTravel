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
    public partial class ProjectConfigurationsGetByCmsConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByCmsConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByCmsConfigurationsFunc(CMSConfiguration={CMSConfiguration})")]
        public IActionResult ProjectConfigurationsGetByCmsConfigurationsFunc([FromODataUri] string CMSConfiguration)
        {
            this.OnProjectConfigurationsGetByCmsConfigurationsDefaultParams(ref CMSConfiguration);

            var items = this.context.ProjectConfigurationsGetByCmsConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByCMSConfiguration] @CMSConfiguration={0}", CMSConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByCmsConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByCmsConfigurationsDefaultParams(ref string CMSConfiguration);

        partial void OnProjectConfigurationsGetByCmsConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByCmsConfiguration> items);
    }
}
