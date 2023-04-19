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
    public partial class ProjectConfigurationsGetByHelpDocumentConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByHelpDocumentConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByHelpDocumentConfigurationsFunc(HelpDocumentConfiguration={HelpDocumentConfiguration})")]
        public IActionResult ProjectConfigurationsGetByHelpDocumentConfigurationsFunc([FromODataUri] string HelpDocumentConfiguration)
        {
            this.OnProjectConfigurationsGetByHelpDocumentConfigurationsDefaultParams(ref HelpDocumentConfiguration);

            var items = this.context.ProjectConfigurationsGetByHelpDocumentConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByHelpDocumentConfiguration] @HelpDocumentConfiguration={0}", HelpDocumentConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByHelpDocumentConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByHelpDocumentConfigurationsDefaultParams(ref string HelpDocumentConfiguration);

        partial void OnProjectConfigurationsGetByHelpDocumentConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByHelpDocumentConfiguration> items);
    }
}
