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
    public partial class ProjectConfigurationsGetByXmlConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByXmlConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByXmlConfigurationsFunc(XMLConfiguration={XMLConfiguration})")]
        public IActionResult ProjectConfigurationsGetByXmlConfigurationsFunc([FromODataUri] string XMLConfiguration)
        {
            this.OnProjectConfigurationsGetByXmlConfigurationsDefaultParams(ref XMLConfiguration);

            var items = this.context.ProjectConfigurationsGetByXmlConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByXMLConfiguration] @XMLConfiguration={0}", XMLConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByXmlConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByXmlConfigurationsDefaultParams(ref string XMLConfiguration);

        partial void OnProjectConfigurationsGetByXmlConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByXmlConfiguration> items);
    }
}
