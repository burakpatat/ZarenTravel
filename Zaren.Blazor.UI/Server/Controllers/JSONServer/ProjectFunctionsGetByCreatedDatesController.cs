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
    public partial class ProjectFunctionsGetByCreatedDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByCreatedDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByCreatedDatesFunc(CreatedDate={CreatedDate})")]
        public IActionResult ProjectFunctionsGetByCreatedDatesFunc([FromODataUri] string CreatedDate)
        {
            this.OnProjectFunctionsGetByCreatedDatesDefaultParams(ref CreatedDate);

            var items = this.context.ProjectFunctionsGetByCreatedDates.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByCreatedDate] @CreatedDate={0}", CreatedDate).ToList().AsQueryable();

            this.OnProjectFunctionsGetByCreatedDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByCreatedDatesDefaultParams(ref string CreatedDate);

        partial void OnProjectFunctionsGetByCreatedDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCreatedDate> items);
    }
}
