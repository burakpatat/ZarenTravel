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
    public partial class ProjectConfigurationsGetByFtpConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByFtpConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByFtpConfigurationsFunc(FtpConfiguration={FtpConfiguration})")]
        public IActionResult ProjectConfigurationsGetByFtpConfigurationsFunc([FromODataUri] string FtpConfiguration)
        {
            this.OnProjectConfigurationsGetByFtpConfigurationsDefaultParams(ref FtpConfiguration);

            var items = this.context.ProjectConfigurationsGetByFtpConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByFtpConfiguration] @FtpConfiguration={0}", FtpConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByFtpConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByFtpConfigurationsDefaultParams(ref string FtpConfiguration);

        partial void OnProjectConfigurationsGetByFtpConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByFtpConfiguration> items);
    }
}
