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
    public partial class ProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponsesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponsesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponsesFunc(CallAfterFunctionsSuccessfullResponse={CallAfterFunctionsSuccessfullResponse})")]
        public IActionResult ProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponsesFunc([FromODataUri] int? CallAfterFunctionsSuccessfullResponse)
        {
            this.OnProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponsesDefaultParams(ref CallAfterFunctionsSuccessfullResponse);

            var items = this.context.ProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponses.FromSqlRaw("EXEC [dbo].[ProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponse] @CallAfterFunctionsSuccessfullResponse={0}", CallAfterFunctionsSuccessfullResponse).ToList().AsQueryable();

            this.OnProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponsesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponsesDefaultParams(ref int? CallAfterFunctionsSuccessfullResponse);

        partial void OnProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponsesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponse> items);
    }
}
