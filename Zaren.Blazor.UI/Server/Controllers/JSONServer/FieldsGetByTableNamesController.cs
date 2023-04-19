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
    public partial class FieldsGetByTableNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public FieldsGetByTableNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/FieldsGetByTableNamesFunc(TableName={TableName})")]
        public IActionResult FieldsGetByTableNamesFunc([FromODataUri] string TableName)
        {
            this.OnFieldsGetByTableNamesDefaultParams(ref TableName);

            var items = this.context.FieldsGetByTableNames.FromSqlRaw("EXEC [dbo].[FieldsGetByTableName] @TableName={0}", TableName).ToList().AsQueryable();

            this.OnFieldsGetByTableNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnFieldsGetByTableNamesDefaultParams(ref string TableName);

        partial void OnFieldsGetByTableNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.FieldsGetByTableName> items);
    }
}
