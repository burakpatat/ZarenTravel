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
    public partial class ProjectTableColumnsGetByDefaultValuesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByDefaultValuesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByDefaultValuesFunc(DefaultValue={DefaultValue})")]
        public IActionResult ProjectTableColumnsGetByDefaultValuesFunc([FromODataUri] string DefaultValue)
        {
            this.OnProjectTableColumnsGetByDefaultValuesDefaultParams(ref DefaultValue);

            var items = this.context.ProjectTableColumnsGetByDefaultValues.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByDefaultValue] @DefaultValue={0}", DefaultValue).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByDefaultValuesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByDefaultValuesDefaultParams(ref string DefaultValue);

        partial void OnProjectTableColumnsGetByDefaultValuesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByDefaultValue> items);
    }
}
