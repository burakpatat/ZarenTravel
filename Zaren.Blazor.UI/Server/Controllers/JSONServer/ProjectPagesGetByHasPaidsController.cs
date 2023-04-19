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
    public partial class ProjectPagesGetByHasPaidsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByHasPaidsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByHasPaidsFunc(HasPaid={HasPaid})")]
        public IActionResult ProjectPagesGetByHasPaidsFunc([FromODataUri] bool? HasPaid)
        {
            this.OnProjectPagesGetByHasPaidsDefaultParams(ref HasPaid);

            var items = this.context.ProjectPagesGetByHasPaids.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByHasPaid] @HasPaid={0}", HasPaid).ToList().AsQueryable();

            this.OnProjectPagesGetByHasPaidsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByHasPaidsDefaultParams(ref bool? HasPaid);

        partial void OnProjectPagesGetByHasPaidsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByHasPaid> items);
    }
}
