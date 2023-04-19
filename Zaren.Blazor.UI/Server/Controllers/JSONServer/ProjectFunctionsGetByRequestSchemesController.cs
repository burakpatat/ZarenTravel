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
    public partial class ProjectFunctionsGetByRequestSchemesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByRequestSchemesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByRequestSchemesFunc(RequestScheme={RequestScheme})")]
        public IActionResult ProjectFunctionsGetByRequestSchemesFunc([FromODataUri] string RequestScheme)
        {
            this.OnProjectFunctionsGetByRequestSchemesDefaultParams(ref RequestScheme);

            var items = this.context.ProjectFunctionsGetByRequestSchemes.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByRequestScheme] @RequestScheme={0}", RequestScheme).ToList().AsQueryable();

            this.OnProjectFunctionsGetByRequestSchemesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByRequestSchemesDefaultParams(ref string RequestScheme);

        partial void OnProjectFunctionsGetByRequestSchemesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByRequestScheme> items);
    }
}
