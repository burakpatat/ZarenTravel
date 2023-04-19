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
    public partial class ProjectTableColumnsGetByMappingConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByMappingConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByMappingConfigurationsFunc(MappingConfiguration={MappingConfiguration})")]
        public IActionResult ProjectTableColumnsGetByMappingConfigurationsFunc([FromODataUri] string MappingConfiguration)
        {
            this.OnProjectTableColumnsGetByMappingConfigurationsDefaultParams(ref MappingConfiguration);

            var items = this.context.ProjectTableColumnsGetByMappingConfigurations.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByMappingConfiguration] @MappingConfiguration={0}", MappingConfiguration).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByMappingConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByMappingConfigurationsDefaultParams(ref string MappingConfiguration);

        partial void OnProjectTableColumnsGetByMappingConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByMappingConfiguration> items);
    }
}
