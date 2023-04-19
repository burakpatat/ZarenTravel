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
    public partial class ProjectFunctionsGetByResponseSchemesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByResponseSchemesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByResponseSchemesFunc(ResponseScheme={ResponseScheme})")]
        public IActionResult ProjectFunctionsGetByResponseSchemesFunc([FromODataUri] string ResponseScheme)
        {
            this.OnProjectFunctionsGetByResponseSchemesDefaultParams(ref ResponseScheme);

            var items = this.context.ProjectFunctionsGetByResponseSchemes.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByResponseScheme] @ResponseScheme={0}", ResponseScheme).ToList().AsQueryable();

            this.OnProjectFunctionsGetByResponseSchemesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByResponseSchemesDefaultParams(ref string ResponseScheme);

        partial void OnProjectFunctionsGetByResponseSchemesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByResponseScheme> items);
    }
}
