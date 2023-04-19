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
    public partial class GetTableSizesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetTableSizesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetTableSizesFunc(TableName={TableName})")]
        public IActionResult GetTableSizesFunc([FromODataUri] string TableName)
        {
            this.OnGetTableSizesDefaultParams(ref TableName);

            var items = this.context.GetTableSizes.FromSqlRaw("EXEC [dbo].[GetTableSize] @TableName={0}", TableName).ToList().AsQueryable();

            this.OnGetTableSizesInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetTableSizesDefaultParams(ref string TableName);

        partial void OnGetTableSizesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetTableSize> items);
    }
}
