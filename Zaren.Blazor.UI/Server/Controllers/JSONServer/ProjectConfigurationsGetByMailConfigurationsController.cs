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
    public partial class ProjectConfigurationsGetByMailConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByMailConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByMailConfigurationsFunc(MailConfiguration={MailConfiguration})")]
        public IActionResult ProjectConfigurationsGetByMailConfigurationsFunc([FromODataUri] string MailConfiguration)
        {
            this.OnProjectConfigurationsGetByMailConfigurationsDefaultParams(ref MailConfiguration);

            var items = this.context.ProjectConfigurationsGetByMailConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByMailConfiguration] @MailConfiguration={0}", MailConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByMailConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByMailConfigurationsDefaultParams(ref string MailConfiguration);

        partial void OnProjectConfigurationsGetByMailConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByMailConfiguration> items);
    }
}
