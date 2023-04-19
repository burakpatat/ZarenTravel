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
    public partial class ProjectConfigurationsGetByDapperConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByDapperConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByDapperConfigurationsFunc(DapperConfiguration={DapperConfiguration})")]
        public IActionResult ProjectConfigurationsGetByDapperConfigurationsFunc([FromODataUri] string DapperConfiguration)
        {
            this.OnProjectConfigurationsGetByDapperConfigurationsDefaultParams(ref DapperConfiguration);

            var items = this.context.ProjectConfigurationsGetByDapperConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByDapperConfiguration] @DapperConfiguration={0}", DapperConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByDapperConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByDapperConfigurationsDefaultParams(ref string DapperConfiguration);

        partial void OnProjectConfigurationsGetByDapperConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDapperConfiguration> items);
    }
}
