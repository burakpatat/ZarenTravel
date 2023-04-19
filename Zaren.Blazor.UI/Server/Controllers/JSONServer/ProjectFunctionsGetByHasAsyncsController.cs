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
    public partial class ProjectFunctionsGetByHasAsyncsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByHasAsyncsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByHasAsyncsFunc(HasAsync={HasAsync})")]
        public IActionResult ProjectFunctionsGetByHasAsyncsFunc([FromODataUri] bool? HasAsync)
        {
            this.OnProjectFunctionsGetByHasAsyncsDefaultParams(ref HasAsync);

            var items = this.context.ProjectFunctionsGetByHasAsyncs.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByHasAsync] @HasAsync={0}", HasAsync).ToList().AsQueryable();

            this.OnProjectFunctionsGetByHasAsyncsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByHasAsyncsDefaultParams(ref bool? HasAsync);

        partial void OnProjectFunctionsGetByHasAsyncsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByHasAsync> items);
    }
}
