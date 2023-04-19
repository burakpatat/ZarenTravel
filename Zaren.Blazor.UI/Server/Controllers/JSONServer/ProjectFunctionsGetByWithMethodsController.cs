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
    public partial class ProjectFunctionsGetByWithMethodsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByWithMethodsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByWithMethodsFunc(WithMethods={WithMethods})")]
        public IActionResult ProjectFunctionsGetByWithMethodsFunc([FromODataUri] string WithMethods)
        {
            this.OnProjectFunctionsGetByWithMethodsDefaultParams(ref WithMethods);

            var items = this.context.ProjectFunctionsGetByWithMethods.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByWithMethods] @WithMethods={0}", WithMethods).ToList().AsQueryable();

            this.OnProjectFunctionsGetByWithMethodsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByWithMethodsDefaultParams(ref string WithMethods);

        partial void OnProjectFunctionsGetByWithMethodsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWithMethod> items);
    }
}
