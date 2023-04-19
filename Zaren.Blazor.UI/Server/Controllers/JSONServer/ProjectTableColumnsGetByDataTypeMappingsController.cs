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
    public partial class ProjectTableColumnsGetByDataTypeMappingsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByDataTypeMappingsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByDataTypeMappingsFunc(DataTypeMapping={DataTypeMapping})")]
        public IActionResult ProjectTableColumnsGetByDataTypeMappingsFunc([FromODataUri] string DataTypeMapping)
        {
            this.OnProjectTableColumnsGetByDataTypeMappingsDefaultParams(ref DataTypeMapping);

            var items = this.context.ProjectTableColumnsGetByDataTypeMappings.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByDataTypeMapping] @DataTypeMapping={0}", DataTypeMapping).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByDataTypeMappingsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByDataTypeMappingsDefaultParams(ref string DataTypeMapping);

        partial void OnProjectTableColumnsGetByDataTypeMappingsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByDataTypeMapping> items);
    }
}
