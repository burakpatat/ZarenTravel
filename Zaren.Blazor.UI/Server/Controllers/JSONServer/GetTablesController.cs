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
    public partial class GetTablesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetTablesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetTablesFunc()")]
        public IActionResult GetTablesFunc()
        {
            this.OnGetTablesDefaultParams();

            var items = this.context.GetTables.FromSqlRaw("EXEC [dbo].[GetTables] ").ToList().AsQueryable();

            this.OnGetTablesInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetTablesDefaultParams();

        partial void OnGetTablesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetTable> items);
    }
}
