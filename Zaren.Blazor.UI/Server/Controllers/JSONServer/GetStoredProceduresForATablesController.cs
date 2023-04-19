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
    public partial class GetStoredProceduresForATablesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetStoredProceduresForATablesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetStoredProceduresForATablesFunc(TableName={TableName})")]
        public IActionResult GetStoredProceduresForATablesFunc([FromODataUri] string TableName)
        {
            this.OnGetStoredProceduresForATablesDefaultParams(ref TableName);

            var items = this.context.GetStoredProceduresForATables.FromSqlRaw("EXEC [dbo].[GetStoredProceduresForATable] @TableName={0}", TableName).ToList().AsQueryable();

            this.OnGetStoredProceduresForATablesInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetStoredProceduresForATablesDefaultParams(ref string TableName);

        partial void OnGetStoredProceduresForATablesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetStoredProceduresForATable> items);
    }
}
