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
    public partial class ProjectPageComponentsGetByLastValidDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByLastValidDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByLastValidDatesFunc(LastValidDate={LastValidDate})")]
        public IActionResult ProjectPageComponentsGetByLastValidDatesFunc([FromODataUri] string LastValidDate)
        {
            this.OnProjectPageComponentsGetByLastValidDatesDefaultParams(ref LastValidDate);

            var items = this.context.ProjectPageComponentsGetByLastValidDates.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByLastValidDate] @LastValidDate={0}", LastValidDate).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByLastValidDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByLastValidDatesDefaultParams(ref string LastValidDate);

        partial void OnProjectPageComponentsGetByLastValidDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByLastValidDate> items);
    }
}
