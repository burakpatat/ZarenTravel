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
    public partial class ProjectFunctionsGetByPublishedDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByPublishedDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByPublishedDatesFunc(PublishedDate={PublishedDate})")]
        public IActionResult ProjectFunctionsGetByPublishedDatesFunc([FromODataUri] string PublishedDate)
        {
            this.OnProjectFunctionsGetByPublishedDatesDefaultParams(ref PublishedDate);

            var items = this.context.ProjectFunctionsGetByPublishedDates.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByPublishedDate] @PublishedDate={0}", PublishedDate).ToList().AsQueryable();

            this.OnProjectFunctionsGetByPublishedDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByPublishedDatesDefaultParams(ref string PublishedDate);

        partial void OnProjectFunctionsGetByPublishedDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByPublishedDate> items);
    }
}