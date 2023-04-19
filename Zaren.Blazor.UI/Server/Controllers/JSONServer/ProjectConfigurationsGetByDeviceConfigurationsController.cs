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
    public partial class ProjectConfigurationsGetByDeviceConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByDeviceConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByDeviceConfigurationsFunc(DeviceConfiguration={DeviceConfiguration})")]
        public IActionResult ProjectConfigurationsGetByDeviceConfigurationsFunc([FromODataUri] string DeviceConfiguration)
        {
            this.OnProjectConfigurationsGetByDeviceConfigurationsDefaultParams(ref DeviceConfiguration);

            var items = this.context.ProjectConfigurationsGetByDeviceConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByDeviceConfiguration] @DeviceConfiguration={0}", DeviceConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByDeviceConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByDeviceConfigurationsDefaultParams(ref string DeviceConfiguration);

        partial void OnProjectConfigurationsGetByDeviceConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDeviceConfiguration> items);
    }
}
