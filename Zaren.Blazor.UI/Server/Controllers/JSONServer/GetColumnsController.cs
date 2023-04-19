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
    public partial class GetColumnsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetColumnsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetColumnsFunc()")]
        public IActionResult GetColumnsFunc()
        {
            this.OnGetColumnsDefaultParams();

            var items = this.context.GetColumns.FromSqlRaw("EXEC [dbo].[GetColumns] ").ToList().AsQueryable();

            this.OnGetColumnsInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetColumnsDefaultParams();

        partial void OnGetColumnsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetColumn> items);
    }
}
