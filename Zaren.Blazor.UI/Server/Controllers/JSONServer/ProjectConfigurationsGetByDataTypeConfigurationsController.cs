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
    public partial class ProjectConfigurationsGetByDataTypeConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByDataTypeConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByDataTypeConfigurationsFunc(DataTypeConfiguration={DataTypeConfiguration})")]
        public IActionResult ProjectConfigurationsGetByDataTypeConfigurationsFunc([FromODataUri] string DataTypeConfiguration)
        {
            this.OnProjectConfigurationsGetByDataTypeConfigurationsDefaultParams(ref DataTypeConfiguration);

            var items = this.context.ProjectConfigurationsGetByDataTypeConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByDataTypeConfiguration] @DataTypeConfiguration={0}", DataTypeConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByDataTypeConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByDataTypeConfigurationsDefaultParams(ref string DataTypeConfiguration);

        partial void OnProjectConfigurationsGetByDataTypeConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDataTypeConfiguration> items);
    }
}
