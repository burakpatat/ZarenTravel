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
    public partial class ProjectFunctionsGetByWillLogCodeMergeDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByWillLogCodeMergeDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByWillLogCodeMergeDatesFunc(WillLogCodeMergeDate={WillLogCodeMergeDate})")]
        public IActionResult ProjectFunctionsGetByWillLogCodeMergeDatesFunc([FromODataUri] bool? WillLogCodeMergeDate)
        {
            this.OnProjectFunctionsGetByWillLogCodeMergeDatesDefaultParams(ref WillLogCodeMergeDate);

            var items = this.context.ProjectFunctionsGetByWillLogCodeMergeDates.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByWillLogCodeMergeDate] @WillLogCodeMergeDate={0}", WillLogCodeMergeDate).ToList().AsQueryable();

            this.OnProjectFunctionsGetByWillLogCodeMergeDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByWillLogCodeMergeDatesDefaultParams(ref bool? WillLogCodeMergeDate);

        partial void OnProjectFunctionsGetByWillLogCodeMergeDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWillLogCodeMergeDate> items);
    }
}
