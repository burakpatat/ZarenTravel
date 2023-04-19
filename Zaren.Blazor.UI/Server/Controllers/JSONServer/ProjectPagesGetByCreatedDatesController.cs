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
    public partial class ProjectPagesGetByCreatedDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByCreatedDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByCreatedDatesFunc(CreatedDate={CreatedDate})")]
        public IActionResult ProjectPagesGetByCreatedDatesFunc([FromODataUri] string CreatedDate)
        {
            this.OnProjectPagesGetByCreatedDatesDefaultParams(ref CreatedDate);

            var items = this.context.ProjectPagesGetByCreatedDates.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByCreatedDate] @CreatedDate={0}", CreatedDate).ToList().AsQueryable();

            this.OnProjectPagesGetByCreatedDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByCreatedDatesDefaultParams(ref string CreatedDate);

        partial void OnProjectPagesGetByCreatedDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByCreatedDate> items);
    }
}
