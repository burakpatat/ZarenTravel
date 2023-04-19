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
    public partial class ProjectConfigurationsGetByPurchasedToolConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByPurchasedToolConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByPurchasedToolConfigurationsFunc(PurchasedToolConfiguration={PurchasedToolConfiguration})")]
        public IActionResult ProjectConfigurationsGetByPurchasedToolConfigurationsFunc([FromODataUri] string PurchasedToolConfiguration)
        {
            this.OnProjectConfigurationsGetByPurchasedToolConfigurationsDefaultParams(ref PurchasedToolConfiguration);

            var items = this.context.ProjectConfigurationsGetByPurchasedToolConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByPurchasedToolConfiguration] @PurchasedToolConfiguration={0}", PurchasedToolConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByPurchasedToolConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByPurchasedToolConfigurationsDefaultParams(ref string PurchasedToolConfiguration);

        partial void OnProjectConfigurationsGetByPurchasedToolConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByPurchasedToolConfiguration> items);
    }
}
