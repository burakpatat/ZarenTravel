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
    public partial class ProjectPageComponentElementsGetByCreatedDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByCreatedDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByCreatedDatesFunc(CreatedDate={CreatedDate})")]
        public IActionResult ProjectPageComponentElementsGetByCreatedDatesFunc([FromODataUri] string CreatedDate)
        {
            this.OnProjectPageComponentElementsGetByCreatedDatesDefaultParams(ref CreatedDate);

            var items = this.context.ProjectPageComponentElementsGetByCreatedDates.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByCreatedDate] @CreatedDate={0}", CreatedDate).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByCreatedDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByCreatedDatesDefaultParams(ref string CreatedDate);

        partial void OnProjectPageComponentElementsGetByCreatedDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCreatedDate> items);
    }
}
