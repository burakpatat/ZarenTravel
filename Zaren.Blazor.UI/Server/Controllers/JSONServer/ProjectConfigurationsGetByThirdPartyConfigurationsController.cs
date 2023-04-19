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
    public partial class ProjectConfigurationsGetByThirdPartyConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByThirdPartyConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByThirdPartyConfigurationsFunc(ThirdPartyConfiguration={ThirdPartyConfiguration})")]
        public IActionResult ProjectConfigurationsGetByThirdPartyConfigurationsFunc([FromODataUri] string ThirdPartyConfiguration)
        {
            this.OnProjectConfigurationsGetByThirdPartyConfigurationsDefaultParams(ref ThirdPartyConfiguration);

            var items = this.context.ProjectConfigurationsGetByThirdPartyConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByThirdPartyConfiguration] @ThirdPartyConfiguration={0}", ThirdPartyConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByThirdPartyConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByThirdPartyConfigurationsDefaultParams(ref string ThirdPartyConfiguration);

        partial void OnProjectConfigurationsGetByThirdPartyConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByThirdPartyConfiguration> items);
    }
}
