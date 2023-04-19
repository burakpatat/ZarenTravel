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
    public partial class ProjectConfigurationsGetByElasticSearchConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByElasticSearchConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByElasticSearchConfigurationsFunc(ElasticSearchConfiguration={ElasticSearchConfiguration})")]
        public IActionResult ProjectConfigurationsGetByElasticSearchConfigurationsFunc([FromODataUri] string ElasticSearchConfiguration)
        {
            this.OnProjectConfigurationsGetByElasticSearchConfigurationsDefaultParams(ref ElasticSearchConfiguration);

            var items = this.context.ProjectConfigurationsGetByElasticSearchConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByElasticSearchConfiguration] @ElasticSearchConfiguration={0}", ElasticSearchConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByElasticSearchConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByElasticSearchConfigurationsDefaultParams(ref string ElasticSearchConfiguration);

        partial void OnProjectConfigurationsGetByElasticSearchConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByElasticSearchConfiguration> items);
    }
}
