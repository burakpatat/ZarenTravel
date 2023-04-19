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
    public partial class ProjectFunctionsGetByWillLogAllResponsesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByWillLogAllResponsesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByWillLogAllResponsesFunc(WillLogAllResponse={WillLogAllResponse})")]
        public IActionResult ProjectFunctionsGetByWillLogAllResponsesFunc([FromODataUri] bool? WillLogAllResponse)
        {
            this.OnProjectFunctionsGetByWillLogAllResponsesDefaultParams(ref WillLogAllResponse);

            var items = this.context.ProjectFunctionsGetByWillLogAllResponses.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByWillLogAllResponse] @WillLogAllResponse={0}", WillLogAllResponse).ToList().AsQueryable();

            this.OnProjectFunctionsGetByWillLogAllResponsesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByWillLogAllResponsesDefaultParams(ref bool? WillLogAllResponse);

        partial void OnProjectFunctionsGetByWillLogAllResponsesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWillLogAllResponse> items);
    }
}
