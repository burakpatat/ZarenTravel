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
    public partial class ProjectPageComponentElementsGetByWillLogCodeMergeDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByWillLogCodeMergeDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByWillLogCodeMergeDatesFunc(WillLogCodeMergeDate={WillLogCodeMergeDate})")]
        public IActionResult ProjectPageComponentElementsGetByWillLogCodeMergeDatesFunc([FromODataUri] bool? WillLogCodeMergeDate)
        {
            this.OnProjectPageComponentElementsGetByWillLogCodeMergeDatesDefaultParams(ref WillLogCodeMergeDate);

            var items = this.context.ProjectPageComponentElementsGetByWillLogCodeMergeDates.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByWillLogCodeMergeDate] @WillLogCodeMergeDate={0}", WillLogCodeMergeDate).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByWillLogCodeMergeDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByWillLogCodeMergeDatesDefaultParams(ref bool? WillLogCodeMergeDate);

        partial void OnProjectPageComponentElementsGetByWillLogCodeMergeDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWillLogCodeMergeDate> items);
    }
}
