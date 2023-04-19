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
    public partial class ProjectPageComponentElementsGetByWillLogAllResponsesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByWillLogAllResponsesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByWillLogAllResponsesFunc(WillLogAllResponse={WillLogAllResponse})")]
        public IActionResult ProjectPageComponentElementsGetByWillLogAllResponsesFunc([FromODataUri] bool? WillLogAllResponse)
        {
            this.OnProjectPageComponentElementsGetByWillLogAllResponsesDefaultParams(ref WillLogAllResponse);

            var items = this.context.ProjectPageComponentElementsGetByWillLogAllResponses.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByWillLogAllResponse] @WillLogAllResponse={0}", WillLogAllResponse).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByWillLogAllResponsesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByWillLogAllResponsesDefaultParams(ref bool? WillLogAllResponse);

        partial void OnProjectPageComponentElementsGetByWillLogAllResponsesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWillLogAllResponse> items);
    }
}
