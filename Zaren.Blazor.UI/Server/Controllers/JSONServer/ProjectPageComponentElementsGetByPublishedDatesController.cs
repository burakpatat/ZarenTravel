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
    public partial class ProjectPageComponentElementsGetByPublishedDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByPublishedDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByPublishedDatesFunc(PublishedDate={PublishedDate})")]
        public IActionResult ProjectPageComponentElementsGetByPublishedDatesFunc([FromODataUri] string PublishedDate)
        {
            this.OnProjectPageComponentElementsGetByPublishedDatesDefaultParams(ref PublishedDate);

            var items = this.context.ProjectPageComponentElementsGetByPublishedDates.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByPublishedDate] @PublishedDate={0}", PublishedDate).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByPublishedDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByPublishedDatesDefaultParams(ref string PublishedDate);

        partial void OnProjectPageComponentElementsGetByPublishedDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByPublishedDate> items);
    }
}
