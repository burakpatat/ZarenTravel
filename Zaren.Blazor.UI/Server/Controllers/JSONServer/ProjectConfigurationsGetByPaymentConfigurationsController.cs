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
    public partial class ProjectConfigurationsGetByPaymentConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByPaymentConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByPaymentConfigurationsFunc(PaymentConfiguration={PaymentConfiguration})")]
        public IActionResult ProjectConfigurationsGetByPaymentConfigurationsFunc([FromODataUri] string PaymentConfiguration)
        {
            this.OnProjectConfigurationsGetByPaymentConfigurationsDefaultParams(ref PaymentConfiguration);

            var items = this.context.ProjectConfigurationsGetByPaymentConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByPaymentConfiguration] @PaymentConfiguration={0}", PaymentConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByPaymentConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByPaymentConfigurationsDefaultParams(ref string PaymentConfiguration);

        partial void OnProjectConfigurationsGetByPaymentConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByPaymentConfiguration> items);
    }
}
