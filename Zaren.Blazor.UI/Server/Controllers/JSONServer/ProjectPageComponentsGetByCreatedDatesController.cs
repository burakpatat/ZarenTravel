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
    public partial class ProjectPageComponentsGetByCreatedDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByCreatedDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByCreatedDatesFunc(CreatedDate={CreatedDate})")]
        public IActionResult ProjectPageComponentsGetByCreatedDatesFunc([FromODataUri] string CreatedDate)
        {
            this.OnProjectPageComponentsGetByCreatedDatesDefaultParams(ref CreatedDate);

            var items = this.context.ProjectPageComponentsGetByCreatedDates.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByCreatedDate] @CreatedDate={0}", CreatedDate).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByCreatedDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByCreatedDatesDefaultParams(ref string CreatedDate);

        partial void OnProjectPageComponentsGetByCreatedDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByCreatedDate> items);
    }
}
