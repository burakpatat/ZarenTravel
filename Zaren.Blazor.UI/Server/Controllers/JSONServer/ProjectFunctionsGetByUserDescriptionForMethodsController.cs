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
    public partial class ProjectFunctionsGetByUserDescriptionForMethodsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByUserDescriptionForMethodsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByUserDescriptionForMethodsFunc(UserDescriptionForMethod={UserDescriptionForMethod})")]
        public IActionResult ProjectFunctionsGetByUserDescriptionForMethodsFunc([FromODataUri] string UserDescriptionForMethod)
        {
            this.OnProjectFunctionsGetByUserDescriptionForMethodsDefaultParams(ref UserDescriptionForMethod);

            var items = this.context.ProjectFunctionsGetByUserDescriptionForMethods.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByUserDescriptionForMethod] @UserDescriptionForMethod={0}", UserDescriptionForMethod).ToList().AsQueryable();

            this.OnProjectFunctionsGetByUserDescriptionForMethodsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByUserDescriptionForMethodsDefaultParams(ref string UserDescriptionForMethod);

        partial void OnProjectFunctionsGetByUserDescriptionForMethodsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByUserDescriptionForMethod> items);
    }
}
