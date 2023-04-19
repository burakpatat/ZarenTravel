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
    public partial class GetTableNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetTableNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetTableNamesFunc()")]
        public IActionResult GetTableNamesFunc()
        {
            this.OnGetTableNamesDefaultParams();

            var items = this.context.GetTableNames.FromSqlRaw("EXEC [dbo].[GetTableNames] ").ToList().AsQueryable();

            this.OnGetTableNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetTableNamesDefaultParams();

        partial void OnGetTableNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetTableName> items);
    }
}
