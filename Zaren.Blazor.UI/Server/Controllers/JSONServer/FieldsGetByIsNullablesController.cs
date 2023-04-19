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
    public partial class FieldsGetByIsNullablesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public FieldsGetByIsNullablesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/FieldsGetByIsNullablesFunc(IsNullable={IsNullable})")]
        public IActionResult FieldsGetByIsNullablesFunc([FromODataUri] bool? IsNullable)
        {
            this.OnFieldsGetByIsNullablesDefaultParams(ref IsNullable);

            var items = this.context.FieldsGetByIsNullables.FromSqlRaw("EXEC [dbo].[FieldsGetByIsNullable] @IsNullable={0}", IsNullable).ToList().AsQueryable();

            this.OnFieldsGetByIsNullablesInvoke(ref items);

            return Ok(items);
        }

        partial void OnFieldsGetByIsNullablesDefaultParams(ref bool? IsNullable);

        partial void OnFieldsGetByIsNullablesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.FieldsGetByIsNullable> items);
    }
}
