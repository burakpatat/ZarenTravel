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
    public partial class ProjectTableColumnsGetByCustomCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByCustomCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByCustomCodesFunc(CustomCode={CustomCode})")]
        public IActionResult ProjectTableColumnsGetByCustomCodesFunc([FromODataUri] string CustomCode)
        {
            this.OnProjectTableColumnsGetByCustomCodesDefaultParams(ref CustomCode);

            var items = this.context.ProjectTableColumnsGetByCustomCodes.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByCustomCode] @CustomCode={0}", CustomCode).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByCustomCodesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByCustomCodesDefaultParams(ref string CustomCode);

        partial void OnProjectTableColumnsGetByCustomCodesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCustomCode> items);
    }
}
