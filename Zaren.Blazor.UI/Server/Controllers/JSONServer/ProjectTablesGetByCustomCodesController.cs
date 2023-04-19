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
    public partial class ProjectTablesGetByCustomCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByCustomCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByCustomCodesFunc(CustomCode={CustomCode})")]
        public IActionResult ProjectTablesGetByCustomCodesFunc([FromODataUri] string CustomCode)
        {
            this.OnProjectTablesGetByCustomCodesDefaultParams(ref CustomCode);

            var items = this.context.ProjectTablesGetByCustomCodes.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByCustomCode] @CustomCode={0}", CustomCode).ToList().AsQueryable();

            this.OnProjectTablesGetByCustomCodesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByCustomCodesDefaultParams(ref string CustomCode);

        partial void OnProjectTablesGetByCustomCodesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCustomCode> items);
    }
}
