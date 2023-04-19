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
    public partial class ProjectConfigurationsGetByHtmlConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByHtmlConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByHtmlConfigurationsFunc(HtmlConfiguration={HtmlConfiguration})")]
        public IActionResult ProjectConfigurationsGetByHtmlConfigurationsFunc([FromODataUri] string HtmlConfiguration)
        {
            this.OnProjectConfigurationsGetByHtmlConfigurationsDefaultParams(ref HtmlConfiguration);

            var items = this.context.ProjectConfigurationsGetByHtmlConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByHtmlConfiguration] @HtmlConfiguration={0}", HtmlConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByHtmlConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByHtmlConfigurationsDefaultParams(ref string HtmlConfiguration);

        partial void OnProjectConfigurationsGetByHtmlConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByHtmlConfiguration> items);
    }
}
