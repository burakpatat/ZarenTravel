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
    public partial class GetTableInfosController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetTableInfosController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetTableInfosFunc(TableName={TableName})")]
        public IActionResult GetTableInfosFunc([FromODataUri] string TableName)
        {
            this.OnGetTableInfosDefaultParams(ref TableName);

            var items = this.context.GetTableInfos.FromSqlRaw("EXEC [dbo].[GetTableInfo] @TableName={0}", TableName).ToList().AsQueryable();

            this.OnGetTableInfosInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetTableInfosDefaultParams(ref string TableName);

        partial void OnGetTableInfosInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetTableInfo> items);
    }
}
