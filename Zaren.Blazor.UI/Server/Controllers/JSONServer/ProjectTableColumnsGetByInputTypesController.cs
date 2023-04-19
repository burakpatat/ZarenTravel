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
    public partial class ProjectTableColumnsGetByInputTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByInputTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByInputTypesFunc(InputType={InputType})")]
        public IActionResult ProjectTableColumnsGetByInputTypesFunc([FromODataUri] int? InputType)
        {
            this.OnProjectTableColumnsGetByInputTypesDefaultParams(ref InputType);

            var items = this.context.ProjectTableColumnsGetByInputTypes.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByInputType] @InputType={0}", InputType).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByInputTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByInputTypesDefaultParams(ref int? InputType);

        partial void OnProjectTableColumnsGetByInputTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByInputType> items);
    }
}
