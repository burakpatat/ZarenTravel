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
    public partial class ProjectPageComponentElementsGetByFunctionTriggerRanksController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByFunctionTriggerRanksController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByFunctionTriggerRanksFunc(FunctionTriggerRank={FunctionTriggerRank})")]
        public IActionResult ProjectPageComponentElementsGetByFunctionTriggerRanksFunc([FromODataUri] int? FunctionTriggerRank)
        {
            this.OnProjectPageComponentElementsGetByFunctionTriggerRanksDefaultParams(ref FunctionTriggerRank);

            var items = this.context.ProjectPageComponentElementsGetByFunctionTriggerRanks.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByFunctionTriggerRank] @FunctionTriggerRank={0}", FunctionTriggerRank).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByFunctionTriggerRanksInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByFunctionTriggerRanksDefaultParams(ref int? FunctionTriggerRank);

        partial void OnProjectPageComponentElementsGetByFunctionTriggerRanksInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByFunctionTriggerRank> items);
    }
}
