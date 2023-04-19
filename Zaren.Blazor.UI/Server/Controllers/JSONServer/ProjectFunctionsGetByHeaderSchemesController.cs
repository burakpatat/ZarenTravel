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
    public partial class ProjectFunctionsGetByHeaderSchemesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByHeaderSchemesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByHeaderSchemesFunc(HeaderScheme={HeaderScheme})")]
        public IActionResult ProjectFunctionsGetByHeaderSchemesFunc([FromODataUri] string HeaderScheme)
        {
            this.OnProjectFunctionsGetByHeaderSchemesDefaultParams(ref HeaderScheme);

            var items = this.context.ProjectFunctionsGetByHeaderSchemes.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByHeaderScheme] @HeaderScheme={0}", HeaderScheme).ToList().AsQueryable();

            this.OnProjectFunctionsGetByHeaderSchemesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByHeaderSchemesDefaultParams(ref string HeaderScheme);

        partial void OnProjectFunctionsGetByHeaderSchemesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByHeaderScheme> items);
    }
}
