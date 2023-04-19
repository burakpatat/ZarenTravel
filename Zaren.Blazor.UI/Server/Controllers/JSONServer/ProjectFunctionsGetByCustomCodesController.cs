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
    public partial class ProjectFunctionsGetByCustomCodesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByCustomCodesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByCustomCodesFunc(CustomCode={CustomCode})")]
        public IActionResult ProjectFunctionsGetByCustomCodesFunc([FromODataUri] string CustomCode)
        {
            this.OnProjectFunctionsGetByCustomCodesDefaultParams(ref CustomCode);

            var items = this.context.ProjectFunctionsGetByCustomCodes.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByCustomCode] @CustomCode={0}", CustomCode).ToList().AsQueryable();

            this.OnProjectFunctionsGetByCustomCodesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByCustomCodesDefaultParams(ref string CustomCode);

        partial void OnProjectFunctionsGetByCustomCodesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCustomCode> items);
    }
}
