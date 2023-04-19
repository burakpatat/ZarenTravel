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
    public partial class ProjectConfigurationsGetBySslConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetBySslConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetBySslConfigurationsFunc(SSLConfiguration={SSLConfiguration})")]
        public IActionResult ProjectConfigurationsGetBySslConfigurationsFunc([FromODataUri] string SSLConfiguration)
        {
            this.OnProjectConfigurationsGetBySslConfigurationsDefaultParams(ref SSLConfiguration);

            var items = this.context.ProjectConfigurationsGetBySslConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetBySSLConfiguration] @SSLConfiguration={0}", SSLConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetBySslConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetBySslConfigurationsDefaultParams(ref string SSLConfiguration);

        partial void OnProjectConfigurationsGetBySslConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetBySslConfiguration> items);
    }
}
